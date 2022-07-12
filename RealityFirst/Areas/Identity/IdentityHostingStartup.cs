using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealityFirst.Areas.Identity.Data;
using RealityFirst.Data;

[assembly: HostingStartup(typeof(RealityFirst.Areas.Identity.IdentityHostingStartup))]
namespace RealityFirst.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RealityFirstDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("RealityFirstDBContextConnection")));

                services.AddDefaultIdentity<RealityFirstUser>(options => 
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<RealityFirstDBContext>();
            });
        }
    }
}