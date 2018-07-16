using System;
using AutoMapper.Configuration;
using DAL;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PL;
using Xunit;

namespace IntegrationTestProject
{
    public class TestStartup: Startup
    {
        
        public TestStartup(Microsoft.Extensions.Configuration.IConfiguration configuration) : base(configuration)
        {
            
        }

        public override void ConfigureDatabase(IServiceCollection services)
        {
            var connection = @"Data Source=localhost\sqlexpress;Initial Catalog=AirportTestDB;Integrated Security=True";
            services.AddDbContext<AirportContext>(options => options.UseSqlServer(connection));
        }
   

        [Fact]
        public void Test1()
        {

        }
    }
}
