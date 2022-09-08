using Dk.BankApp.Web.Data.Context;
using Dk.BankApp.Web.Data.Interfaces;
using Dk.BankApp.Web.Data.Repositories;
using Dk.BankApp.Web.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dk.BankApp.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BankContext>(opt =>
            {
                opt.UseSqlServer("server=DESKTOP-U8RG37D\\SQLSERVER; database=BankDb; integrated security=true;");
            });

            
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>(); // Dependency Injection uygulayabilmek için öncelikle Interface ve Classýmýzý Scopedledik.
            services.AddScoped<IAccountRepository, AccountRepository>(); // Dependency Injection uygulayabilmek için öncelikle Interface ve Classýmýzý Scopedledik.
            services.AddScoped<IUserMapper, UserMapper>();
            services.AddScoped<IAccountMapper, AccountMapper>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // Generic Class ve Interface Scoped iþlemi yaparken typeOf kullanýlýr. !!

            services.AddControllersWithViews(); // Uygulamamda Controller ve View dosyalarýný kullanacaðýmý belirttim.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(); // wwwroot'u dýþarýya açtýk.

            app.UseStaticFiles(
                new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine
                (Directory.GetCurrentDirectory(),"node_modules")),
                RequestPath = "/node_modules"
            }); // node_modules açtýk.

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute(); // Klasik "controller/action/id?" routesini projeme uyguladým
            });
        }
    }
}
