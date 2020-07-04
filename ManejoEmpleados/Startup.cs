using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManejoEmpleados.Middlewares;
using ManejoEmpleados.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ManejoEmpleados
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            this._config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();//config =>
            /*{
                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });*/


            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(_config.GetConnectionString("EmpleadosDBConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            //services.AddSingleton<IEmpleadoRepository, MockEmpleadoRepository>();
            services.AddScoped<IEmpleadoRepository, SqlEmpleadoRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {

            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions opt = new DeveloperExceptionPageOptions();
                opt.SourceCodeLineCount = 4;
                app.UseDeveloperExceptionPage(opt);
            }
            else if (env.IsProduction() || env.IsStaging())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseDefaultFiles();
            //app.UseAuthentication();
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
