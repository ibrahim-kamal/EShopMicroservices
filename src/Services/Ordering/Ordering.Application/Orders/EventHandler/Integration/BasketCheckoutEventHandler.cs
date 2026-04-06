using BuildingBlocks.Messaging.Events;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Ordering.Application.Orders.Commands.CreateOrder;
using System.Net.Mail;
using System.Reflection.Emit;

namespace Ordering.Application.Orders.EventHandler.Integration
{
    public class BasketCheckoutEventHandler(ISender sender,ILogger<BasketCheckoutEventHandler> logger) : IConsumer<BasketCheckoutEvent>
    {
        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            // ToDo: Create new Order and start order fullfillment process
            logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);
            BasketCheckoutEvent data = context.Message;
            var command = MapToCreateOrderCommand(context.Message);
            await sender.Send(command);
            throw new NotImplementedException();
        }

        private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent basketcheckoutEvent)
        {
            var orderId = Guid.NewGuid();
            var command = new CreateOrderCommand (
                new OrderDto (
                    orderId,
                    basketcheckoutEvent.CustomerId,
                    basketcheckoutEvent.Username,
                    new AddressDto
                    (
                        basketcheckoutEvent.FirstName,
                        basketcheckoutEvent.LastName,
                        basketcheckoutEvent.EmailAddress,
                        basketcheckoutEvent.AddressLine,
                        basketcheckoutEvent.Country,
                        basketcheckoutEvent.State,
                        basketcheckoutEvent.ZipCode
                    ),
                    new AddressDto
                    (
                        basketcheckoutEvent.FirstName,
                        basketcheckoutEvent.LastName,
                        basketcheckoutEvent.EmailAddress,
                        basketcheckoutEvent.AddressLine,
                        basketcheckoutEvent.Country,
                        basketcheckoutEvent.State,
                        basketcheckoutEvent.ZipCode
                    ),
                    new PaymentDto (
                        basketcheckoutEvent.CardName,
                        basketcheckoutEvent.CardNumber,
                        basketcheckoutEvent.Expiration,
                        basketcheckoutEvent.CVV,
                        basketcheckoutEvent.PaymentMethod

                    ),
                    Ordering.Domain.Enums.OrderStatus.Pending,
                    new List<OrderItemDto> { 
                        new OrderItemDto(orderId,new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8"),2,500)
                        new OrderItemDto(orderId,new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27"),1,400)
                    }

                )
            );

            return command;
        }
    }
}
