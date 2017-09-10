using Ecommerce.Services.Core.Logic.Concrete;
using Ecommerce.Services.Core.Logic.Contracts;
using Ecommerce.Services.Data.Concrete;
using Ecommerce.Services.Data.Concrete.dbo.Ecommerce;
using Ecommerce.Services.Data.Contracts;
using Ecommerce.Services.Data.Contracts.dbo.Ecommerce;
using Ecommerce.Services.Logic.Concrete;
using Ecommerce.Services.Logic.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Services
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // Add memory cache services.
            services.AddMemoryCache();

            // Register IConfiguration instance with ConfigurationBuilder for system configuration.
            services.AddSingleton<IConfiguration>(Configuration);

            // Add custom repositories.
            services.AddTransient<ISqlFileReaderEngine, SqlFileReaderEngine>();
            services.AddTransient<IRestaurantRepository, RestaurantRepository>();
            services.AddTransient<IMenuItemRepository, MenuItemRepository>();

            // Add custom engines.
            services.AddTransient<IRestaurantEngine, RestaurantEngine>();
            services.AddTransient<IConfigurationSettings, ConfigurationSettings>();
            services.AddTransient<IAssetEngine, AssetEngine>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseMvc();
        }
    }
}
