﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using userCase.Entity;
using userCase.Models;

namespace userCase
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
            //services.AddDistributedMemoryCache(); 
            services.AddSession(options =>
            { 
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true; 
                options.Cookie.IsEssential = true;
                options.Cookie.Name = ".AdventureWorks.Session";  
            });

            services.AddDbContext<UserContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
               // options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            // SESSION section
            services.AddMemoryCache();
            //services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));            
            services.AddMvc();             
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           // dbContext.Database.EnsureCreated();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
             
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseAuthentication();
            //app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Register}/{id?}");
            });
            //CityDistrictDefaultAdd.CityDistrictList(app);
        }
    }
}
