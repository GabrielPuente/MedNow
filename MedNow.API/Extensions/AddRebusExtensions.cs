using Microsoft.EntityFrameworkCore;
using Rebus.Config;
using Rebus.Retry.Simple;
using Rebus.Bus;
using MedNow.Application;
using MedNow.Application.InternalEvent;

namespace MedNow.API.Extensions
{
    public static class AddRebusExtensions
    {
        public static IServiceCollection AddRebus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AutoRegisterHandlersFromAssembly(typeof(ApplicationModule).Assembly);

            services.AddRebus(configure => configure
               .Transport(t =>
               {
                   var opt = t.UseRabbitMq(configuration.GetConnectionString("RabbitMQ"), $"MedNow");
               })
               .Options(c =>
               {
                   c.SimpleRetryStrategy(secondLevelRetriesEnabled: true, maxDeliveryAttempts: 2, errorQueueAddress: "MedNowError");
               }));

            return services;
        }

        public static void UseRebus(this IServiceProvider service)
        {
            var bus = service.GetService<IBus>();

            Task.WaitAll(new Task[]
            {
               bus.Subscribe<TestInternalEvent>()
            });
        }
    }
}
