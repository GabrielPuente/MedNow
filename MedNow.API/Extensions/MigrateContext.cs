using MedNow.Infra;
using Microsoft.EntityFrameworkCore;

namespace MedNow.API.Extensions
{
    public static class IWebHostExtensions
    {
        public static IServiceCollection MigrateContexts(this IServiceCollection services, IConfiguration configuration)
        {
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

            return services;
        }
    }
}
