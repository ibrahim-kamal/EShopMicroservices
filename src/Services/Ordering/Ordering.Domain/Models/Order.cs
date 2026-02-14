using Ordering.Domain.ValueObject;

namespace Ordering.Domain.Models
{
    public class Order : Aggregate<OrderId>
    {
        private readonly List<OrderItem> _orderItems = new();


        public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();
        public CustomerId CustomerId { get; private set; } = default!;
        public OrderName OrderName { get; private set; } = default!;
        public Address ShippiungAddress { get; private set; } = default!;
        public Address BillingAddress { get; private set; } = default!;
        public Payment Payment { get; private set; } = default!;
        public OrderStatus Status { get; private set; } = OrderStatus.Pending;
        public decimal TotalPrice { 
            get => OrderItems.Sum(x => x.Price * x.Quantity);
            private set { }
        }

        private Order create (OrderId id, CustomerId customerId, OrderName orderName, Address shippiungAddress, Address billingAddress, Payment payment, OrderStatus status, decimal totalPrice)
        {
            var order = new Order {
                Id = id,
                CustomerId = customerId,
                OrderName = orderName,
                ShippiungAddress = shippiungAddress,
                BillingAddress = billingAddress,
                Payment = payment,
                Status = status,
                TotalPrice = totalPrice,
            };

            order.AddDomainEvents(new OrderCreatedEvent(order));

            return order;

        }


        public void Update(OrderName orderName, Address shippiungAddress, Address billingAddress, Payment payment, OrderStatus status)
        {
            OrderName = orderName;
            ShippiungAddress = shippiungAddress;
            BillingAddress = billingAddress;
            Payment = payment;
            Status = status;
            AddDomainEvents(new OrderUpdatedEvent(this));
        }

        public void Add(ProductId productId, int quantity, decimal price) {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
            var orderItem = new OrderItem(Id, productId, quantity, price);
            _orderItems.Add(orderItem);

        }
        public void Remove(ProductId productId)
        {
            var orderItem = _orderItems.FirstOrDefault(i => i.ProductId == productId);
            if(orderItem is not null) 
                _orderItems.Remove(orderItem);
        }
    }
}
