using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Orders.Queries.GetOrderByName
{
    public record GetOrderByNameQuery(string OrderName) : IQuery<GetOrderByNameResult>;

    public record GetOrderByNameResult(IEnumerable<OrderDto> Order);

}
