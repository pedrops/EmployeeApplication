using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Factory;
using Core.Interfaces.DL;
using Core.Interfaces.DTO;
using Core.Interfaces.Factory;
using Core.Interfaces.Service;
using Core.Service;
using Data.DTO;
using Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {            
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public int EmployeeService { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddTransient<IEmployeeClientService, EmployeeClientService>();
            services.AddTransient<IEmployeeFactory, EmployeeFactory>();            
            services.AddTransient<IEmployeeClientRepository, EmployeeClientRepository>();
            services.AddTransient<IEmployeeClientRepository, EmployeeClientRepository>();
            services.AddTransient<IEmployeeDTO, EmployeeDTO>();
            


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            //}

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Employee}/{action=Index}");
            });
        }
    }
}
