namespace Ordering.Application.Orders.Queries.GetOrderByName
{
    public class GetOrdersByNameHandler(IApplicationDbContext context) 
        : IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameResult>
    {
        public async Task<GetOrdersByNameResult> Handle(GetOrdersByNameQuery qurey, CancellationToken cancellationToken)
        {
            var orders = await context.Orders
                .Include(o => o.OrderItems)
                .AsNoTracking()
                .Where(o => o.OrderName.Value.Contains(qurey.OrderName))
                .OrderBy(o => o.OrderName.Value)
                //.ProjectToType<OrderDto>()
                .ToListAsync(cancellationToken);
            return new GetOrdersByNameResult(orders.ToOrderDtoList());
        }
    }
}
