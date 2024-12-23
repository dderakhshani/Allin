using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Allin.Common.Web
{

    public interface IAppSettingsAccessor
    {
        public IConnectionStringModel GetConnectionString();
        public IJwtConfigurationModel GetJwtConfiguration();
        public ISwaggerConfigurationModel GetSwaggerConfiguration();
        public ICorsConfigurationModel GetCorsConfiguration();

    }

    public interface IConnectionStringModel
    {
    }

    public interface ICorsConfigurationModel
    {
        public string PolicyName { get; set; }
        public bool AllowAnyOrigin { get; set; }
        public bool AllowAnyMethod { get; set; }
        public bool AllowAnyHeader { get; set; }
    }

    public interface IJwtConfigurationModel
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? Secret { get; set; }
        public int ExpirySecondTime { get; set; }
    }

    public interface ISwaggerConfigurationModel
    {
        public string? XmlPath { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? TermsOfService { get; set; }
    }

    public interface ISwaggerContactConfigurationModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Url { get; set; }
    }

    public class AppSettingsAccessor : IAppSettingsAccessor
    {
        private readonly IConfiguration _configuration;

        public AppSettingsAccessor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IJwtConfigurationModel GetJwtConfiguration()
        {
            return _configuration.GetSection("Jwt").Get<IJwtConfigurationModel>()!;
        }


        public ISwaggerConfigurationModel GetSwaggerConfiguration()
        {
            return _configuration.GetSection("Swagger").Get<ISwaggerConfigurationModel>()!;
        }

        public ICorsConfigurationModel GetCorsConfiguration()
        {
            return _configuration.GetSection("Cors").Get<ICorsConfigurationModel>()!;
        }

        public IConnectionStringModel GetConnectionString()
        {
            return _configuration.GetSection("ConnectionStrings").Get<IConnectionStringModel>()!;
        }


    }
}
