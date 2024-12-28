using Allin.Admin.Application.Commands.Users.Add;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using Allin.Common.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAppSettingsAccessor, AppSettingsAccessor>();
StartupServiceHelper.LoadSettings(new AppSettingsAccessor(builder.Configuration));
builder.Services.AddBaseServices();
builder.Services.AddGeneralAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<AdminDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
//.AddInterceptors(new EventInterceptor()));



var app = builder.Build();

app.UseHttpsRedirection();

app.UseBaseFeatures();

app.Run();
