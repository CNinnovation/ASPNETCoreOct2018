using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFirstASPNETCoreApp.Middleware;
using MyFirstASPNETCoreApp.Models;
using MyFirstASPNETCoreApp.MyControllers;
using MyFirstASPNETCoreApp.Services;
using Newtonsoft.Json;

namespace MyFirstASPNETCoreApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddTransient<IHelloService, HelloService>();
            services.AddTransient<MyHomeController>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession();
            app.UseMyCustomMiddleware();

            // Middleware
            app.UseStaticFiles();

            app.Map("/session", app1 =>
            {
                app1.Run(async context =>
                {
                    await SessionSampleAsync(context);
                });
            });

            app.Map("/json", app1 =>
            {
                app1.Run(async context =>
                {
                    var book = new Book { Isbn = "37843743", Title = "Professional C# 8", Publisher = "Wrox Press" };

                    string json = JsonConvert.SerializeObject(book);

                    await context.Response.WriteAsync(json);
                });
            });

            app.Map("/mycontroller", app1 =>
            {
                app1.Run(async context =>
                {
                    var name = context.Request.Query["name"];
                    var controller = app1.ApplicationServices.GetService<MyHomeController>();
                    string result = controller.Index(name);
                    await context.Response.WriteAsync(result);
                });
            });

            app.Map("/echo", app1 =>
            {
                app1.Run(async context =>
                {
                    var x = context.Request.Query["hello"];
                   // x = HtmlEncoder.Default.Encode(x);
                    await context.Response.WriteAsync(x);
                });
            });

            app.MapWhen(context => context.Request.Path.Value.Contains("bar"), app1 =>
            {
                app1.Run(async context =>
                {
                    await context.Response.WriteAsync($"<h1>bar in path</h1> <div>path: {context.Request.Path}/div>");
                });
            });

            app.Map("/foo", app1 =>
            {
                app1.Run(async context =>
                {
                    await context.Response.WriteAsync($"<h1>Foo invoked</h1> <div>path: {context.Request.Path}/div>");
                });
            });

            app.Run(async (context) =>
            {
              
                await context.Response.WriteAsync("<h1>Hello World!</h1>");
            });
        }

        public async Task SessionSampleAsync(HttpContext context)
        {
            int visits = context.Session.GetInt32("NumberVisits") ?? 0;
            visits++;
            context.Session.SetInt32("NumberVisits", visits);
            await context.Response.WriteAsync($"number of visits: {visits}");
        }
    }
}
