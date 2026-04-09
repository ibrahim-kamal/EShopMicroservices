using MassTransit;

namespace Ordering.Application.Orders.EventHandler.Domain
{
    public class OrderCreatedEventHandler(IPublishEndpoint publishEndpoint,ILogger<OrderCreatedEventHandler> logger) : INotificationHandler<OrderCreatedEvent>
    {
        public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);

            var orderCreateIntegrationEvent = domainEvent.order.ToOrderDto();

            await publishEndpoint.Publish(orderCreateIntegrationEvent,cancellationToken);
        }
    }
}
