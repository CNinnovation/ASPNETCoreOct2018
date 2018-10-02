using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyFirstMVCApp.Services;

namespace MyFirstMVCApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddTransient<IMathService, MathService>();
            services.AddTransient<IBooksService, BooksService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            // app.UseMvcWithDefaultRoute();
            app.UseMvc(route =>
            {
                route.MapRoute(
                    "default", 
                    "{controller}/{action}/{id?}", 
                    defaults: new { controller="Home", action="Index" });


                route.MapRoute(
                    "math", 
                    "/math/{controller}/{action}/{x?}/{y?}");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
