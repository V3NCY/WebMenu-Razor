using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebMenu_Razor.Areas.Identity.Data;
using WebMenu_Razor.Data;

[assembly: HostingStartup(typeof(WebMenu_Razor.Areas.Identity.IdentityHostingStartup))]
namespace WebMenu_Razor.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WebMenu_RazorContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("HospitalConnectionString")));

                services.AddDefaultIdentity<WebMenu_RazorUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<WebMenu_RazorContext>();

            });
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthDbContextConnection")));
                ...
}
        }
    }
}