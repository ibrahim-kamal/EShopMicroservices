
using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace Basket.API.Basket.Commands.CheckOutBasket
{
    public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto) : ICommand<CheckoutBasketResult>;
    public record CheckoutBasketResult(bool IsSuccess);
    public class CheckoutBasketHandler 
        (IBasketRepository basketRepository,IPublishEndpoint publishEndpoint)
        : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
    {
        public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
        {
            // get existing basket with total price
            var basket = await basketRepository.GetBasket(command.BasketCheckoutDto.Username);
            if (basket == null) {
                return new CheckoutBasketResult(false);
            }
            // set totalprice on basketcheckout event message
            var eventMessage = command.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
            eventMessage.TotalPrice = command.BasketCheckoutDto.TotalPrice;
            // send basket checkout event to rabbitmq using masstransit
            await publishEndpoint.Publish(eventMessage,cancellationToken);
            // delete the bassket
            var result = await basketRepository.DeleteBasket(command.BasketCheckoutDto.Username,cancellationToken);
            return new CheckoutBasketResult(true);


        }
    }
}
