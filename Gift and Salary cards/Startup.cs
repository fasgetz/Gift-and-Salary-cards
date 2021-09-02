using Gift_and_Salary_cards.Middlewares;
using Gift_and_Salary_cards.Models.DataBase;
using Gift_and_Salary_cards.Models.Identity;
using Gift_and_Salary_cards.Services;
using Gift_and_Salary_cards.Services.ComissionService;
using Gift_and_Salary_cards.Services.EmailServiceAccount;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards
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

            services.AddDbContext<ContextUsers>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UsersIdentityConnection")));

            services.AddDbContext<GiftCardsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(opts =>
                {
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.User.RequireUniqueEmail = true;    // уникальный email
                    opts.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz"; // допустимые символы
                })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ContextUsers>();


            services.AddScoped<IUKassaServicePayout, UKassaServicePayout>();
            services.AddScoped<IUkassaServicePayment, UKassaServicePayment>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IComissionService, Gift_and_Salary_cards.Services.ComissionService.ComissionService>();
            services.AddScoped<IEmailServiceAccount, EmailServiceAccount>();

            services.AddControllersWithViews();
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
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Home/Error");
                //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.ApplicationServices.SetupNLogServiceLocator();

            app.UseRouting();

            app.UseAuthentication();    // подключение аутентификации
            app.UseAuthorization();

            app.UseMiddleware<LoggerMiddleWare>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
