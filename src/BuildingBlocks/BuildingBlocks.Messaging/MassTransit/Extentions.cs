
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingBlocks.Messaging.MassTransit
{
    public static class Extentions
    {
        public static IServiceProvider AddMessageBroker
            (this IServiceCollection services,IConfiguration configuration, Assembly? assembly =null) 
        {

            //Implement RabbitMq MassTransit configuration
            services.AddMassTransit(config =>
            {
                config.SetKebabCaseEndpointNameFormatter();
                if (assembly != null)
                    config.AddConsumers(assembly);

                config.UsingRabbitMq((context, Configurator) =>
                {
                    Configurator.Host(new Uri(configuration["MessageBroker:Host"]!), host =>
                    {
                    });
                });


            });

            


            return services;
        }
    }
}
