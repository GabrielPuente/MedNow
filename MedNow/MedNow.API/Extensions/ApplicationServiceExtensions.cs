using MedNow.Application.Services;
using MedNow.Domain.Contracts.Repositories;
using MedNow.Domain.Contracts.Services;
using MedNow.Infra.Auditing;
using MedNow.Infra.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.Common;

namespace MedNow.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDbConnection, DbConnection>(provider =>
            {
                string connectionString = configuration.GetConnectionString("Connection");
                return new SqlConnection(connectionString);
            });

            services.AddScoped<IEntryAuditor, EntryAuditor>();

            return services;
        }

    }
}
