using Allin.Admin.Application.Commands.Users.Add;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAppSettingsAccessor, AppSettingsAccessor>();
StartupServiceHelper.LoadSettings(new AppSettingsAccessor(builder.Configuration));
builder.Services.AddBaseServices();
builder.Services.AddDbContext();

builder.Services.AddDbContext<AdminDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
//.AddInterceptors(new EventInterceptor()));

builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(AddUserCommand).Assembly));
builder.Services.AddAutoMapper(typeof(AddUserCommand).Assembly);


var app = builder.Build();

app.UseHttpsRedirection();

app.UseBaseFeatures();

app.Run();
