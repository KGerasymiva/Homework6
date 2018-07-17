using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Mappers;
using BL.Mapper;
using DAL;
using DAL.Models;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BL.Service;
using DTO;


namespace PL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IServiceTicket, ServiceTicket>();
            services.AddTransient<IServicePlaneType, ServicePlaneType>();
            services.AddTransient<IMapper, Mapper>();
            services.AddTransient<IRepository<Entity>, Repository<Entity>>();

            //services.AddDbContext<AirportContext>(opt => opt.UseInMemoryDatabase());
            services.AddRouting();
            services.AddMvc();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            ConfigureDatabase(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            SeedData.EnsurePopulated(app);
        }

        public virtual void ConfigureDatabase(IServiceCollection services)
        {
            var connection = @"Data Source=localhost\sqlexpress;Initial Catalog=AirportDB;Integrated Security=True";
            services.AddDbContext<AirportContext>(options => options.UseSqlServer(connection));
        }
    }
}
