

using Ordering.Domain.Enums;

namespace Ordering.Application.Orders.Commands.UpdateOrder
{
    class UpdateOrderHandler(IApplicationDbContext context) : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
    {
        public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            // get Order
            var orderId = OrderId.Of(command.order.Id);
            var order = await context.Orders
                .FindAsync(orderId,cancellationToken);
            if (order is null)
                throw new OrderNotFoundException(command.order.Id);
            //Update order entity from command object 
            UpdateOrderWithNewValues(order , command.order);
            //save to database
            context.Orders.Update(order);
            await context.SaveChangesAsync(cancellationToken);
            // return result
            return new UpdateOrderResult(true);
   
        }

        private void UpdateOrderWithNewValues(Order order, OrderDto orderDto) {

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

            var payment = Payment.Of(orderDto.Payment.CardName, orderDto.Payment.CardNumber, orderDto.Payment.Expiration, orderDto.Payment.CVV, orderDto.Payment.PaymentMethod)

            var orderId = OrderId.Of(Guid.NewGuid());
            var customerId = CustomerId.Of(orderDto.CustomerId);
            var orderName = OrderName.Of(orderDto.OrderName);

            order.Update(orderName,shippingAddress,billingAddress,payment,orderDto.Status);
            
        }
    }
}
