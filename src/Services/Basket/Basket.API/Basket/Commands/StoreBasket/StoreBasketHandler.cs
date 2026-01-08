namespace Basket.API.Basket.Commands.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

    public record StoreBasketResult(string UserName);

    public class StoreBasketHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            ShoppingCart cart = command.Cart;
            //TODO: Store Basket In Database (use Marten upsert - if exist = update, if not = insert )
            //TODO: update cache
            //var result = _rpository.SaveBasket(request);
            return new StoreBasketResult("swn");
        }
    }
}
