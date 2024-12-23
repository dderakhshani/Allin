using System.Configuration;
using Allin.Common.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAppSettingsAccessor, AppSettingsAccessor>(); 
StartupServiceHelper.LoadSettings(new AppSettingsAccessor(builder.Configuration));
builder.Services.AddBaseServices();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseBaseFeatures();

app.Run();
