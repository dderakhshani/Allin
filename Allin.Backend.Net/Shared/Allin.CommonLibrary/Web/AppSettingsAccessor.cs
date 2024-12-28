using Microsoft.Extensions.Configuration;

namespace Allin.Common.Web
{
    public interface IAppSettingsAccessor
    {
        public ConnectionStringModel GetConnectionString();
        public JwtConfigurationModel GetJwtConfiguration();
        public SwaggerConfigurationModel GetSwaggerConfiguration();
        public CorsConfigurationModel GetCorsConfiguration();
    }

    public class ConnectionStringModel
    {
    }

    public class CorsConfigurationModel
    {
        public string PolicyName { get; set; }
        public bool AllowAnyOrigin { get; set; }
        public bool AllowAnyMethod { get; set; }
        public bool AllowAnyHeader { get; set; }
    }

    public class JwtConfigurationModel
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? Secret { get; set; }
        public int ExpirySecondTime { get; set; }
    }

    public class SwaggerConfigurationModel
    {
        public string? XmlPath { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? TermsOfService { get; set; }
    }

    public class SwaggerContactConfigurationModel
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

        public JwtConfigurationModel GetJwtConfiguration()
        {
            return _configuration.GetSection("Jwt").Get<JwtConfigurationModel>()!;
        }


        public SwaggerConfigurationModel GetSwaggerConfiguration()
        {
            return _configuration.GetSection("Swagger").Get<SwaggerConfigurationModel>()!;
        }

        public CorsConfigurationModel GetCorsConfiguration()
        {
            return _configuration.GetSection("Cors").Get<CorsConfigurationModel>()!;
        }

        public ConnectionStringModel GetConnectionString()
        {
            return _configuration.GetSection("ConnectionStrings").Get<ConnectionStringModel>()!;
        }


    }
}
