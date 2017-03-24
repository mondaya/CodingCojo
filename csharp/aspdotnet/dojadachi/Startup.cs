using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
 
namespace DojoDachiDemo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            // Add Mvc as a service making it available across our entire app
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