using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace HelloWorld.Tests
{
    public class HelloWorldTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public HelloWorldTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetHello_ReturnsHelloWorld()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/hello");

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("Hello, World!!Brad", responseString);
        }
    }
}
