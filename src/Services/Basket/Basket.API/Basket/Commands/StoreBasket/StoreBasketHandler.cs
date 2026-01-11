

namespace Basket.API.Basket.Commands.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

    public record StoreBasketResult(string UserName);

    public class StoreBasketHandler(IBasketRepository basketRepository)
        : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            ShoppingCart cart = command.Cart;
            var result = basketRepository.StoreBasket(cart);
            return new StoreBasketResult(cart.UserName);
        }
    }
}
