using MedNow.API.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MedNow.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webhost = CreateHostBuilder(args)
             .Build();

            webhost
                   .MigrateContexts()
                   .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
