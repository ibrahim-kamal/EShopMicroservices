namespace Ordering.Application.Orders.EventHandler.Domain
{
    internal class OrderUpdatedEventHandler(ILogger<OrderUpdatedEventHandler> logger) 
        : INotificationHandler<OrderUpdatedEvent>
    {
        Task INotificationHandler<OrderUpdatedEvent>.Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
    
}
