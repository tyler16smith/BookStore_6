 using BookStoreTyler.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStoreTyler
{
    public class Startup
    {
        // constructor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //create a configuration object from the IConfiguration class
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // void means it's not going to return anything; it's just for adding services
        public void ConfigureServices(IServiceCollection services)
        {
            // sets up the MVC system
            services.AddControllersWithViews();

            // Gets the options being configured; adding the context database to the program, uses UseSqlServer
            services.AddDbContext<BooksDbContext>(options =>
            {
                // configures the context to the Microsoft SQL Server Database
                options.UseSqlServer(Configuration["ConnectionStrings:BooksConnection"]);
            });

            // Each session/request will get their own personal 'scoped' database to do whatever they need to do
            // The service itself = IBooksRepository
            // Implementation of that service = EFBooksRepository
            services.AddScoped<IBooksRepository, EFBooksRepository>();
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
            
            // jumps directly to the Default Files - app.UseDefaultFiles() FIRST (app.UseStaticFiles() SECOND)
            // app.UseDefaultFiles();

            // to access the '.cshtml' files
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // pass in categories, etc.
            app.UseEndpoints(endpoints =>
            {
                // page and category
                endpoints.MapControllerRoute("catpage",
                    "{category}/{page:int}",
                    new { Controller = "Home", action = "Index" });

                // page
                endpoints.MapControllerRoute("page",
                    "Projects/{page:int}",
                    new { Controller = "Home", action = "Index" });

                // category
                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", page = 1});

                // changes the URL
                endpoints.MapControllerRoute("pagination",
                    "P{page}",
                    new { Controller = "Home", action = "Index" });

                // default endpoint
                endpoints.MapDefaultControllerRoute();
            });

            // ensure the database is populated -- see "SeedData.cs"
            SeedData.EnsurePopulated(app);

            //.UseDefaultFiles - allow default file mapping to files (such as index.cshtml) without specifying a directory
            //app.UseNodeModules() identifies dependencies such as jQuery
        }
    }
}
