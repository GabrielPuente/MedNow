using IdempotentAPI.Cache.DistributedCache.Extensions.DependencyInjection;
using MediatR;
using MedNow.API.Extensions;
using MedNow.Application;
using Rebus.Config;

namespace MedNow.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //                            .AllowAnyMethod()
            //                            .AllowAnyHeader());
            //});

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services
                    .AddAuthenticationServices(builder.Configuration)
                    .AddSwaggerServices()
                    .AddServices()
                    .AddQueries()
                    .AddRepositories()
                    .AddRebus(builder.Configuration)
                    .AddDbContext(builder.Configuration)
                    .AddMigrateContexts(builder.Configuration)
                    .AddRedis(builder.Configuration)
                    .AddDistributedMemoryCache()
                    .AddIdempotentAPIUsingDistributedCache()
                    .AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(ApplicationModule).Assembly));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Services.UseRebus();

            app.Run();
        }
    }
}