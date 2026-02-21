using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator() {
            RuleFor(o => o.order.OrderName).NotEmpty().WithMessage("OrderName is Required");
            RuleFor(o => o.order.CustomerId).NotEmpty().WithMessage("CustomerId is Required");
            RuleFor(o => o.order.OrderItems).NotEmpty().WithMessage("OrderName should Not Be empty");
        }
    }
}
