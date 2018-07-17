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
                .UseStartup<TestStartup>().UseDefaultServiceProvider(options =>
                    options.ValidateScopes = false));
        }

        //Create tests here
        [Fact]
        public void Test1()
        {
            

        }
    }
}