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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Middleware
            app.UseStaticFiles();

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
    }
}
