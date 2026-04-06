
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingBlocks.Messaging.MassTransit
{
    public static class Extentions
    {
        public static IServiceCollection AddMessageBroker
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
                        host.Username(configuration["MessageBroker:UserName"]!);
                        host.Password(configuration["MessageBroker:Password"]!);
                    });
                    Configurator.ConfigureEndpoints(context);
                });


            });

            


            return services;
        }
    }
}
