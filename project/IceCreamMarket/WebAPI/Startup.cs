using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Services.ClientService.Implementations;
using BLL.Services.ClientService.Repositories;
using BLL.Services.OrderService.Implementations;
using BLL.Services.OrderService.Repositories;
using Data.Context;
using Data.Implementations;
using Data.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WebAPI
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
            services.AddControllers();
            
            // AutoMapper config
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // BLL Order
            services.Add(new ServiceDescriptor(typeof(IOrderService), typeof(OrderService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IUpdateOrderService), typeof(UpdateOrderService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IDiscountService), typeof(DiscountService), ServiceLifetime.Scoped));
            
            // BLL Client
            services.Add(new ServiceDescriptor(typeof(ICreateClientService), typeof(CreateClientService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IGetClientService), typeof(GetClientService), ServiceLifetime.Scoped));

            // Data
            services.Add(new ServiceDescriptor(typeof(IRepository<Order>), typeof(OrderDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IRepository<Client>), typeof(ClientDataAccess), ServiceLifetime.Transient));
            
            // Use a PostgreSQL database 
            var sqlConnectionString = Configuration.GetConnectionString("DataAccessPostgreSqlProvider");
 
            services.AddDbContext<DatabaseContext>(options =>
                options.UseNpgsql(sqlConnectionString)
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}