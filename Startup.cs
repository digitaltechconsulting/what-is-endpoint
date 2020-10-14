using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using what_is_endpoint.Controllers.Services;
using what_is_endpoint.Hubs;

namespace what_is_endpoint
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
            services.AddControllersWithViews();
            services.AddControllers();//only api
            services.AddSignalR();
            services.AddSingleton<IConferenceService,ConferenceMemoryService>();
            /*services.AddCors( o => o.AddPolicy("CorsPolicy",builder =>{
                builder.AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("*");
            }));*/

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();//with this routing information is available to all middlewares, not just mvc

            app.UseAuthorization();

            //app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllerRoute("default","{controller}/{action}");
                endpoints.MapControllerRoute("api","api/{controller}/{action}");
                endpoints.MapGet("/",async context => {
                    await context.Response.Body.WriteAsync(new byte[] {48});
                });
                endpoints.MapHub<CoffeeHub>("/chathub");
            });
        }
    }
}
