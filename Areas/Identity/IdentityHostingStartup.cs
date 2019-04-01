using System;
using FixerMovie.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FixerMovie.Areas.Identity.IdentityHostingStartup))]
namespace FixerMovie.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FixerMovieIdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("FixerMovieIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<FixerMovieIdentityDbContext>();
            });
        }
    }
}