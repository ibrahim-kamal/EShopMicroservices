namespace Ordering.Application.Orders.Queries.GetOrderByName
{
    public class GetOrderByNameHandler(IApplicationDbContext context) 
        : IQueryHandler<GetOrderByNameQuery, GetOrderByNameResult>
    {
        public async Task<GetOrderByNameResult> Handle(GetOrderByNameQuery qurey, CancellationToken cancellationToken)
        {
            var orders = await context.Orders
                .Include(o => o.OrderItems)
                .AsNoTracking()
                .Where(o => o.OrderName.Value.Contains(qurey.OrderName))
                .OrderBy(o => o.OrderName)
                //.ProjectToType<OrderDto>()
                .ToListAsync(cancellationToken);
            return new GetOrderByNameResult(orders.ToOrderDtoList());
        }
    }
}
