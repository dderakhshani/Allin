using Microsoft.AspNetCore.Mvc.Testing;

namespace Allin.Admin.IntegrationTest.Base
{
    public abstract class BaseIntegrationTest
    {
        protected readonly HttpClient HttpClient;
        private readonly WebApplicationFactory<Program> _factory;
        protected BaseIntegrationTest()
        {
            _factory = new WebApplicationFactory<Program>();
            HttpClient = _factory.CreateClient();
        }

        //[Fact]
        //public async Task Get_All()
        //{
        //    // Arrange


        //    // Act


        //    // Assert
        //    Assert.True(true);
        //}

        //[Fact]
        //public async Task Get_All_1()
        //{
        //    // Arrange


        //    // Act


        //    // Assert
        //    Assert.True(true);
        //}
    }
}
