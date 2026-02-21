using BuildingBlocks.CQRS;
using Ordering.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ordering.Application.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand(OrderDto order) : ICommand<CreateOrderResult>;
    public record CreateOrderResult(Guid Id);

}
