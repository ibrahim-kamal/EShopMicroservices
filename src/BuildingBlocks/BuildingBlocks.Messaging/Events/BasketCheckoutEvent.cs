
namespace BuildingBlocks.Messaging.Events
{
    public record BasketCheckoutEvent : IntegrationEvent
    {
        public string Username { get; set; } = default!;
        public Guid CustomerId { get; set; } = default!;
        public decimal TotalPrice { get; set; } = default!;
    }
}
