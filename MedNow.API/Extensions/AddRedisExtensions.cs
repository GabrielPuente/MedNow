namespace MedNow.API.Extensions
{
    public static class AddRedisExtensions
    {
        public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(o => {
                o.InstanceName = "MedNow";
                o.Configuration = configuration.GetConnectionString("Redis");
            });

            return services;
        }
    }
}
