using System.Text.Json;

namespace Allin.Admin.IntegrationTest.Helpers
{
    public static class ApiResponseHelper
    {
        public static T GetGeneralApiResult<T>(string content)
        {
            return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
