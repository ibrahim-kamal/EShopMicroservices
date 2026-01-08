namespace Basket.API.Basket.Commands.StoreBasket
{
    public class StoreBasketValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketValidator() { 
            RuleFor(x => x.cart).NotNull().WithMessage("Cart can not be null");
            RuleFor(x => x.cart.UserName).NotEmpty().WithMessage("UserName is required");
                
        }
    }
}
