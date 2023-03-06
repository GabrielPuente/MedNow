using Microsoft.EntityFrameworkCore;

namespace MedNow.API.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetConnectionString(this IConfiguration configuration)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (env == "Development")
            {
                return configuration.GetConnectionString("Connection");
            }

            var connectionEncript = configuration.GetConnectionString("Connection");
            return Cryptography.Decrypt(connectionEncript);
        }
    }
}
