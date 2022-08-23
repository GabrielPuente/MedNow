using MedNow.Infra;
using Microsoft.EntityFrameworkCore;

namespace MedNow.API.Extensions
{
    public static class IWebHostExtensions
    {
        public static IHost MigrateContexts(this IHost webHost)
        {
            var configuration = webHost.Services.GetRequiredService<IConfiguration>();

            try
            {
                var connectionString = string.Format(configuration.GetConnectionString("Connection"));

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
