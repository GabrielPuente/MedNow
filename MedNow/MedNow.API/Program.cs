using MedNow.API.Extensions;

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
