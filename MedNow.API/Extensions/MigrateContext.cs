using MedNow.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MedNow.API.Extensions
{
    public static class IWebHostExtensions
    {
        public static IHost MigrateContexts(this IHost webHost)
        {
            var configuration = webHost.Services.GetRequiredService<IConfiguration>();

            try
            {
                var connectionString = configuration.GetConnectionString();
                var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

                optionsBuilder.UseSqlServer(connectionString, options =>
                {
                    options.MigrationsHistoryTable("__EFMigrationsHistory");
                });

                var dataContext = new DataContext(optionsBuilder.Options);
                dataContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                throw;
            }

            return webHost;
        }
    }
}
