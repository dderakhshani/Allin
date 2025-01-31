using Allin.Admin.Application.Models;
using Allin.Admin.IntegrationTest.Base;
using Allin.Admin.IntegrationTest.Helpers;
using FluentAssertions;
using System.Net;

namespace Allin.Admin.IntegrationTest
{
    public class BaseValueControllerTest : BaseIntegrationTest
    {
        [Fact]
        public async Task get_all_success()
        {
            // Arrange


            // Act
            var response = await HttpClient.GetAsync("/api/Base-Value/Get-All");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var data = ApiResponseHelper.GetGeneralApiResult<IEnumerable<BaseValueModel>>(await response.Content.ReadAsStringAsync());

            data.Should().NotBeNullOrEmpty();
        }
    }
}
