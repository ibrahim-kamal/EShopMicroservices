
namespace Basket.API.Basket.Commands.CheckOutBasket
{
    public class CheckoutBasketValidator : AbstractValidator<CheckoutBasketCommand> {
        public CheckoutBasketValidator()
        {
            RuleFor(b => b.BasketCheckoutDto).NotNull().WithMessage("BasketCheckoutDto is Required");
            RuleFor(b => b.BasketCheckoutDto.Username)
                .NotEmpty().WithMessage("Username is Required");
        }
    }
}
