using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using DbConnection;

namespace ASPStartUpDemo
{
    public class Startup
    {

        public IConfiguration Configuration { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            // Add Mvc as a service making it available across our entire app
            // Add framework services.
            services.Configure<MySqlOptions>(Configuration.GetSection("DBInfo"));
             // Add framework services.
            //Added DbConnector as a service
            services.AddScoped<DbConnector>();
            services.AddMvc();
        }
         
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            
            app.UseSession();
            // Use the Mvc to handle Http requests and responses
            app.UseMvc();
            /*app.UseMvc( routes =>
            {
                routes.MapRoute(
                    name: "Default", // The route's name is only for our own reference
                    template: "", // The pattern that the route matches
                    defaults: new {controller = "Hello", action = "Index"} // The controller and method to execute
                );
            });*/
        }
    }
}