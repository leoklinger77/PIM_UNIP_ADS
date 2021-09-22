using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Net.Mail;
using UnipPim.Hotel.Infra.Data;

namespace UnipPim.Hotel.Configuration
{
    public static class WebAppConfig
    {
        public static void WebAppConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddDbContext<HotelContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("Connection")));

            services.AddControllersWithViews();
            services.AddRazorPages();

            //SMTP
            services.AddScoped<SmtpClient>(option =>
            {
                SmtpClient smtp = new SmtpClient()
                {
                    Host = configuration.GetValue<string>("Email:ServerSMTP"),
                    Port = configuration.GetValue<int>("Email:Port"),
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(configuration.GetValue<string>("Email:UserName"), configuration.GetValue<string>("Email:Password")),
                    EnableSsl = true
                };

                return smtp;
            });
        }

        public static void AppConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/500");
                app.UseStatusCodePagesWithRedirects("/erro/{0}");

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
                        name: "areas",
                        pattern: "{area:exists}/{controller=Cargo}/{action=Index}/{id?}"
                      );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
