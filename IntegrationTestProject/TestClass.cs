using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace IntegrationTestProject
{
    public class TestClass
    {
        private readonly TestServer _server;

        public TestClass()
        {
            _server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<TestStartup>()
                .UseEnvironment("Development"));
        }
    }
}