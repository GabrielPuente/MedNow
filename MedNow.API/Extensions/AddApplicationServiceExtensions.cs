using MedNow.Application.Queries;
using MedNow.Application.Services;
using MedNow.Application.Contracts.Queries;
using MedNow.Infra.Contracts.Repositories;
using MedNow.Application.Contracts.Services;
using MedNow.Infra.Auditing;
using MedNow.Infra.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using MedNow.Infra;
using Microsoft.EntityFrameworkCore;

namespace MedNow.API.Extensions
{
    public static class AddApplicationServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICachingService, CachingService>();

            return services;
        }

        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddScoped<IProductQuery, ProductQuery>();
            services.AddScoped<IOrderQuery, OrderQuery>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
