using Allin.Common.Utilities;
using Allin.Common.Utilities.Mappings;
using Allin.Common.Web;
using Allin.Inventory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
//Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-FR");

// Add services to the container.
builder.Services.AddScoped<IAppSettingsAccessor, AppSettingsAccessor>();
StartupServiceHelper.LoadSettings(new AppSettingsAccessor(builder.Configuration));
builder.Services.AddBaseServices();

builder.Services.AddGeneralAutoMapper(typeof(MappingProfile));

//builder.Services.AddScoped<IRoleQueries, RoleQueries>();

builder.Services.AddDbContext<InventoryDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("Default"), config => config.UseHierarchyId()));


//.AddInterceptors(new EventInterceptor()));

//Register all IValidator<> automatically
//builder.Services.AddValidatorsFromAssembly(typeof(AddRoleCommandValidator).Assembly);

//builder.Services.AddAutoMapper(typeof(AddUserCommand).Assembly);
// language

builder.Services.AddQueries();

builder.Services.AddAllinLocalization(Assembly.GetExecutingAssembly(), "Resources");

builder.Services.AddMediator();

var app = builder.Build();

GlobalContainer.ServiceProvider = app.Services;

//app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

app.UseHttpsRedirection();

app.UseBaseFeatures();

app.Run();

public partial class Program { }
