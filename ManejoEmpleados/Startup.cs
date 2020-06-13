using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManejoEmpleados.Middlewares;
using ManejoEmpleados.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ManejoEmpleados
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<IEmpleadoRepository, MockEmpleadoRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions opt = new DeveloperExceptionPageOptions();
                opt.SourceCodeLineCount = 4;
                app.UseDeveloperExceptionPage(opt);
            }
             else if(env.IsProduction() || env.IsStaging())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            /*app.Use(async (context, next) => {
                logger.LogInformation("MDD1: Entrada Request" + env.EnvironmentName);
                await next();
                logger.LogInformation("MDD1: Salida Response");
            });
            
            app.Use(async (context, next) => {
                logger.LogInformation("MDD2: Entrada Request");
                await next();
                logger.LogInformation("MDD2: Salida Response");
            });

            //app.UseMiddleware<CustomMiddleware>();
            app.UseCustomMiddleware();

            app.Run(async (context) => {
                await context.Response.WriteAsync("Middleware 3 ambiente:: " + env.EnvironmentName);
                logger.LogInformation("MDD3: Retorno del req/res");
            });*/
        }
    }
}
