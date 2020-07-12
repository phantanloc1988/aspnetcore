using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MyeStoreProject.Models;
using MyeStoreProject.ViewModels;

namespace MyeStoreProject
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
            services.AddDbContext<eStore20Context>(option => option.UseSqlServer(Configuration.GetConnectionString("EstoreDb")));

            var AppSettingSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(AppSettingSection);

            //cách 1: phổ thông
            var secretkey = Configuration["AppSettings:MaHoaSecret"];

            //cách 2: dùng class Appsettings

            var appSetting = AppSettingSection.Get<AppSettings>();

            var keyBytes = Encoding.UTF8.GetBytes(appSetting.MaHoaSecret);


            // khai báo sử dụng Authentication dùng Token
            services.AddAuthentication(opt=>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg=> {
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {

                    // tự validate & cấp token nên false
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    // cấu hình ký
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
                };
            });
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
