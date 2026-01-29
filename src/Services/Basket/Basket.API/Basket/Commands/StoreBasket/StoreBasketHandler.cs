

using Discount.Grpc;

namespace Basket.API.Basket.Commands.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

    public record StoreBasketResult(string UserName);

    public class StoreBasketHandler
        (IBasketRepository basketRepository,DiscountProtoService.DiscountProtoServiceClient discountProto)
        : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            await DeductDiscount(command.Cart, cancellationToken);
            var result = basketRepository.StoreBasket(command.Cart);
            return new StoreBasketResult(command.Cart.UserName);
        }

        private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
        {
            foreach (var item in cart.Items)
            {
                var getDiscountRequest = new GetDiscountRequest { ProductName = item.ProductName };
                var coupon = await discountProto.GetDiscountAsync(getDiscountRequest, cancellationToken: cancellationToken);
                item.Price -= coupon.Amount;
            }
        }
    }
}
