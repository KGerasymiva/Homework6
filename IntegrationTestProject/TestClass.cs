using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using PL;
using Xunit;

namespace IntegrationTestProject
{
    public class TestClass
    {
        private readonly TestServer _server;

        public TestClass()
        {
            _server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>().UseDefaultServiceProvider(options =>
                    options.ValidateScopes = false));
        }

        [Fact]
        public void Test1()
        {

        }
    }
}