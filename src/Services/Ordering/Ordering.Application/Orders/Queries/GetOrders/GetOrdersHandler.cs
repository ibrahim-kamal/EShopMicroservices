using BuildingBlocks.Pagination;
using System.Linq;

namespace Ordering.Application.Orders.Queries.GetOrders
{
    public class GetOrdersHandler(IApplicationDbContext context) 
        : IQueryHandler<GetOrdersQuery, GetOrdersResult>
    {
        public async Task<GetOrdersResult> Handle(GetOrdersQuery qurey, CancellationToken cancellationToken)
        {
            var totalCount = await context.Orders.LongCountAsync(cancellationToken);
            var orders = await context.Orders
                .Include(o => o.OrderItems)
                .AsNoTracking()
                .OrderBy(o => o.OrderName.Value)
                .Skip(qurey.paginationRequest.PageIndex * qurey.paginationRequest.PageSize)
                .Take(qurey.paginationRequest.PageSize)
                .ToListAsync(cancellationToken);


            return new GetOrdersResult(
                new PaginatedResult<OrderDto>(
                    qurey.paginationRequest.PageIndex,
                    qurey.paginationRequest.PageSize,
                    totalCount,
                    orders.ToOrderDtoList())
                );
        }
    }
}
