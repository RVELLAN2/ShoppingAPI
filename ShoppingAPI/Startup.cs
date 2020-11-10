using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShoppingAPI.Data;
using ShoppingAPI.Profiles;
using ShoppingAPI.Services;

namespace ShoppingAPI
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

            services.AddDbContext<ShoppingDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("shopping"))
            );

            services.AddScoped<ILookupProducts, EfSqlShopping>();
            services.AddScoped<IProductCommands, EfSqlShopping>();

            var pricingConfig = new PricingConfiguration();
            Configuration.GetSection(pricingConfig.SectionName).Bind(pricingConfig);
            // Makes this injectable into services using IOptions<T>
            services.Configure<PricingConfiguration>(Configuration.GetSection(pricingConfig.SectionName));

            var mapperConfig = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new ProductProfile(pricingConfig));
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton<IMapper>(mapper);
            services.AddSingleton<MapperConfiguration>(mapperConfig);

            services.AddScoped<ICurbsideCommands, EfSqlSynchCurbside>();
            services.AddScoped<ICurbsideLookups, EfSqlSynchCurbside>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
