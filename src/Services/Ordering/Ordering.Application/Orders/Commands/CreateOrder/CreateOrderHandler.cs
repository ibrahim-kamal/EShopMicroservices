

namespace Ordering.Application.Orders.Commands.CreateOrder
{
    class CreateOrderHandler(IApplicationDbContext context) : ICommandHandler<CreateOrderCommand, CreateOrderResult>
    {
        public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            //create order entity from command object 
            var order = CreateNewOrder(command.order);
            //save to database
            context.Orders.Add(order);
            await context.SaveChangesAsync(cancellationToken);
            // return result
            return new CreateOrderResult(order.Id.Value);
        }

        private Order CreateNewOrder(OrderDto orderDto) {

            var billingAddress = Address.Of(orderDto.BillingAddress.FirstName, 
                orderDto.BillingAddress.LastName,
                orderDto.BillingAddress.EmailAddress,
                orderDto.BillingAddress.AddressLine,
                orderDto.BillingAddress.Country,
                orderDto.BillingAddress.State,
                orderDto.BillingAddress.ZipCode);

            var shippingAddress = Address.Of(orderDto.ShippingAddress.FirstName, 
                orderDto.ShippingAddress.LastName,
                orderDto.ShippingAddress.EmailAddress,
                orderDto.ShippingAddress.AddressLine,
                orderDto.ShippingAddress.Country,
                orderDto.ShippingAddress.State,
                orderDto.ShippingAddress.ZipCode);

            var payment = Payment.Of(orderDto.Payment.CardName, orderDto.Payment.CardNumber, orderDto.Payment.Expiration, orderDto.Payment.Cvv, orderDto.Payment.PaymentMethod);

            var orderId = OrderId.Of(Guid.NewGuid());
            var customerId = CustomerId.Of(orderDto.CustomerId);
            var orderName = OrderName.Of(orderDto.OrderName);
            var order = Order.Create(orderId, customerId, orderName, shippingAddress, billingAddress, payment);

            foreach (var orderItemDto in orderDto.OrderItems)
            {
                order.Add(ProductId.Of(orderItemDto.ProductId), orderItemDto.Quantity, orderItemDto.Price);
            }

            return order;
        }
    }
}
