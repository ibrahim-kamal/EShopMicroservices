using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator() {
            RuleFor(o => o.order.Id).NotEmpty().WithMessage("Id is Required");
            RuleFor(o => o.order.OrderName).NotEmpty().WithMessage("OrderName is Required");
            RuleFor(o => o.order.CustomerId).NotEmpty().WithMessage("CustomerId is Required");
        }
    }
}
