using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParkManagment.Context;
using ParkManagment.Implementation.Repositries;
using ParkManagment.Implementation.Services;
using ParkManagment.Implemention.Repositries;
using ParkManagment.Interfaces;
using ParkManagment.Implemention.DriverService;
using ParkManagment.Implementions;
using ParkManagment.Implementions.Service;
using ParkManagment.Interfaces.Repositries;
using ParkManagmentMVC.Implementions.DriverRepostory;
using ParkManagmentMVC.Implementions.DriverService;

namespace ParkManagment
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
            services.AddScoped<IMotorsRepository, MotorRepo>();
            services.AddScoped<IMotorService, MotorService>();
            services.AddScoped<IParkRepository, ParkRepo>();
            services.AddScoped<IParkService, ParkService>();
            services.AddScoped<IDriverRepository, DriverRepo>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IPaymentRepository,PaymentRepo>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IStaffRepository, StaffRepo>();
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<IAdminRepository, AdminRepo>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(config =>
            {
                config.LoginPath = "/staff/login";
                
            });
            services.AddAuthorization();
            services.AddSession();
            services.AddControllersWithViews();
            string connectionString = "server=localhost;user=root;database=ParkManagment;port=3306;password=Pencil_1";
            services.AddDbContext<ApplicationContext>(option => option.UseMySQL(connectionString));
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
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
    
}