using BuildingBlocks.Behaviors;
using Carter;

namespace Ordering.Api
{
    public static class DepandencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddCarter();
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(Program).Assembly),
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
                config.AddOpenBehavior(typeof(LoggingBehavior<,>));

            });
            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app) {
            app.MapCarter();
            return app;
        }
    }
}
