using AutoMapper;
using BLL.Services.ClientService.Contracts;
using BLL.Services.ClientService.Implementations;
using BLL.Services.OrderService.Implementations;
using BLL.Services.OrderService.Contracts;
using Data.Context;
using Data.Implementations;
using Data.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


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
            services.Add(new ServiceDescriptor(typeof(IOrderDataAccess), typeof(OrderDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IClientDataAccess), typeof(ClientDataAccess), ServiceLifetime.Transient));
            
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