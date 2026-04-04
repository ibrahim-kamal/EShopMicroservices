using Microsoft.Extensions.Configuration;

namespace BuildingBlocks.Messaging.MassTransit
{
    public static class Extentions
    {
        public static IServiceProvider AddMessageBroker(this IServiceProvider service,IConfiguration configuration, AssemblyLoadEventArgs? assembly =null) { 
            
            //Implement RabbitMq MassTransit configuration
            return service;
        }
    }
}
