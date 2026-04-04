
namespace BuildingBlocks.Messaging.Events
{
    public record IntegrationEvent
    {

        public Guid EventId => Guid.NewGuid();
        public DateTime OccurredOn => DateTime.Now;
        public string EventType => GetType().AssemblyQualifiedName;

        //shipping and Billing Address
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? EmailAddress { get; set; } = default!;
        public string AddressLine { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string State { get; set; } = default!;
        public string ZipCode { get; set; } = default!;



        //payment
        public string? CardName { get; } = default!;
        public string CardNumber { get; } = default!;
        public string Expiration { get; } = default!;
        public string CVV { get; } = default!;
        public int PaymentMethod { get; } = default!;

    }
}
