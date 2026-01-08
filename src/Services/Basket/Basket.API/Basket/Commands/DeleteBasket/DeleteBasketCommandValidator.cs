
namespace Basket.API.Basket.Commands.DeleteBasket
{
    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand> {
        public DeleteBasketCommandValidator() {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }
}
