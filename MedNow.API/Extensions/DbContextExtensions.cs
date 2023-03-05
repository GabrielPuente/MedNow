using MedNow.Infra.Auditing;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using MedNow.Infra;
using Microsoft.EntityFrameworkCore;

namespace MedNow.API.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connetcionstring = configuration.GetConnectionString();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(connetcionstring));
            services.AddScoped<IDbConnection, DbConnection>(provider =>
            {
                return new SqlConnection(connetcionstring);
            });

            services.AddScoped<IEntryAuditor, EntryAuditor>();
            return services;
        }
    }
}
