using Allin.Common.Utilities.CustomBindings;
using Allin.Common.Validations;
using Allin.CommonLibrary.Localizations;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ServiceStack;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Text.RegularExpressions;

namespace Allin.Common.Web
{
    public static partial class StartupServiceHelper
    {
        private static IAppSettingsAccessor? _appSettingsAccessor;
        private static IAppSettingsAccessor AppSettingsAccessor
        {
            get
            {
                if (_appSettingsAccessor == null)
                    throw new Exception(@"You need to inject AppSettingsAccessor in your Startup.cs, and then provide it. \n
                    The code snippet is like: \n
                    services.AddScoped<IAppSettingsAccessor, IAppSettingsAccessor>(); \n
                    StartupServiceHelper.LoadSettings(new AppSettingsAccessor(Configuration)); \n");
                return _appSettingsAccessor;
            }
        }
        public static void LoadSettings(IAppSettingsAccessor appSettings)
        {
            _appSettingsAccessor = appSettings;
        }


        public static void AddBaseServices(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
            }).AddJsonOptions(o =>
            {
                // o.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                o.JsonSerializerOptions.Converters.Add(new TypeIncludedJsonConverter<DateTime>());
                o.JsonSerializerOptions.Converters.Add(new TypeIncludedJsonConverter<DateTime?>());
                o.JsonSerializerOptions.Converters.Add(new TypeIncludedJsonConverter<DateTimeOffset>());
                o.JsonSerializerOptions.Converters.Add(new TypeIncludedJsonConverter<DateTimeOffset?>());
                o.JsonSerializerOptions.Converters.Add(new DateOnlyConverter());
                o.JsonSerializerOptions.Converters.Add(new NullableDateOnlyConverter());
                o.JsonSerializerOptions.Converters.Add(new TimeOnlyConverter());
                o.JsonSerializerOptions.Converters.Add(new NullableTimeOnlyConverter());
                o.JsonSerializerOptions.Converters.Add(new TimeSpanConverter());
                o.JsonSerializerOptions.Converters.Add(new NullableTimeSpanConverter());
                o.JsonSerializerOptions.TypeInfoResolver = new DefaultJsonTypeInfoResolver
                {
                    Modifiers = { IgnoreInverseProperty },
                };
            });



            services.AddMvc();
            services.AddHttpContextAccessor();

            services.AddValidation();
            services.AddOAuth();
            services.AddCorsPolicy();
            services.AddSwagger();
            services.AddMediator();
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddValidationException();
        }

        public static void UseBaseFeatures(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => { c.SwaggerEndpoint($"/swagger/{AppSettingsAccessor.GetSwaggerConfiguration().Name}/swagger.json", $"{AppSettingsAccessor.GetSwaggerConfiguration().Title} {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}"); });
            }

            app.UseRouting();
            app.UseCors(AppSettingsAccessor.GetCorsConfiguration().PolicyName);
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
        }

        private static void AddValidation(this IServiceCollection services)
        {
            //Register all IValidator<> automatically
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());


            var types = AppDomain.CurrentDomain.GetAssemblies()
                       .Where(a => !a.IsDynamic)
                       .SelectMany(a => a.GetExportedTypes());

            var servicesTypes = (from t in types
                                 where t.GetInterfaces().Any(i =>
                                       i.IsGenericType
                                       && i.GetGenericTypeDefinition() == typeof(IBusinessRuleValidator<>))
                                       && !t.IsAbstract
                                 select t).ToList();

            foreach (var type in servicesTypes)
            {
                services.AddTransient(type.GetInterfaces().FirstOrDefault(), type);
            }
        }

        private static void AddOAuth(this IServiceCollection services)
        {
            var jwtSecret = AppSettingsAccessor.GetJwtConfiguration().Secret;
            if (jwtSecret == null)
            {
                throw new Exception("JWT token is invalid");
            }
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = AppSettingsAccessor.GetJwtConfiguration().Issuer,
                        ValidAudience = AppSettingsAccessor.GetJwtConfiguration().Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret!)),
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }

        private static void AddValidationException(this IServiceCollection services)
        {
            services.AddScoped<IExceptionProvider, ExceptionProvider>();
        }

        private static void AddCorsPolicy(this IServiceCollection services)
        {
            // allows cross origin access to the resources
            services.AddCors(o => o.AddPolicy(AppSettingsAccessor.GetCorsConfiguration().PolicyName, builder =>
            {
                if (Convert.ToBoolean(AppSettingsAccessor.GetCorsConfiguration().AllowAnyOrigin))
                    builder.AllowAnyOrigin();
                if (Convert.ToBoolean(AppSettingsAccessor.GetCorsConfiguration().AllowAnyMethod))
                    builder.AllowAnyMethod();
                if (Convert.ToBoolean(AppSettingsAccessor.GetCorsConfiguration().AllowAnyHeader))
                    builder.AllowAnyHeader();
            }));
        }

        private static void AddSwagger(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(AppSettingsAccessor.GetSwaggerConfiguration().Name, new OpenApiInfo
                {
                    Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString(),
                    Title = AppSettingsAccessor.GetSwaggerConfiguration().Title,
                    Description = AppSettingsAccessor.GetSwaggerConfiguration().Description,
                    //TermsOfService = new Uri(ConfigurationAccessor.GetSwaggerConfiguration().TermsOfService),
                    //Contact = new OpenApiContact
                    //{
                    //    Name = AppSettingsAccessor.GetSwaggerConfiguration().Contact!.Name,
                    //    Email = AppSettingsAccessor.GetSwaggerConfiguration().Contact!.Email,
                    //    Url = new Uri(AppSettingsAccessor.GetSwaggerConfiguration().Contact!.Url!)
                    //}
                });

                c.AddSecurityDefinition("Authorization", new()
                {
                    Description = "",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Type = SecuritySchemeType.Http
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme, // or ReferenceType.Parameter
                                Id = "Authorization"
                            }
                        },
                        new string[] {}
                    }
                });

                //c.OperationFilter<SwaggerWebsiteMappingHeaderParameter>();
            });
        }

        public static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                {
                    config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
                });
        }

        public static void AddAllinLocalization(this IServiceCollection services, Assembly assembly, string resourcePath)
        {
            services.AddLocalization(options => options.ResourcesPath = resourcePath);
            //services.AddSingleton<ILocalizationService, LocalizationService>();

            services.AddSingleton<ILocalizator>(x =>
            {
                var factory = x.GetRequiredService<IStringLocalizerFactory>();
                var assemblyName = new AssemblyName(assembly.FullName);
                return new Localizator()
                {
                    Localizer = factory.Create("Localization", assemblyName.Name)
                };
            });
        }

        public static void AddGeneralAutoMapper(this IServiceCollection services, Type mappingProfileType)
        {
            services.AddAutoMapper(mappingProfileType);

        }

        public static void AddQueries(this IServiceCollection services)
        {
            services.Scan(source => source.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                  .AddClasses(type => type.AssignableTo(typeof(Allin.Common.Data.QueryBase<>)))
                  .AsImplementedInterfaces()
                  .WithTransientLifetime());
        }

        static void IgnoreInverseProperty(JsonTypeInfo typeInfo)
        {
            //Exclude value types
            if (typeInfo.Type.IsValueType)
                return;

            foreach (JsonPropertyInfo propertyInfo in typeInfo.Properties)
            {
                //Ignore the decorated properties by InverseProperty.
                if (propertyInfo.AttributeProvider?.IsDefined(typeof(InversePropertyAttribute), false) ?? false)
                {
                    propertyInfo.ShouldSerialize = static (obj, value) => false;
                }
            }
        }
    }

    internal class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string? TransformOutbound(object? value)
        {
            if (value is null)
            {
                return null;
            }

            return Regex.Replace(
                value.ToString()!,
                    "([a-z])([A-Z])",
                "$1-$2",
                RegexOptions.CultureInvariant,
                TimeSpan.FromMilliseconds(100))
                .ToLowerInvariant();
        }
    }

}
