using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using WAMA.Web;
using Xunit;

namespace WAMAcut.Integration.Tests
{
    public class UserToolControllerIntegrationTest : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;

        public UserToolControllerIntegrationTest(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task ReturnHelloWorld()
        {
            var response = await _client.GetAsync("/adminconsole/usertool");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            
            Assert.Equal("Hello World!",
                responseString);
        }
    }
}