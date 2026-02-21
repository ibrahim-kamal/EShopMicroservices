namespace Ordering.Application.Orders.Queries.GetOrderByCustomer
{
    public class GetOrderByCustomerHandler(IApplicationDbContext context) 
        : IQueryHandler<GetOrderByCustomerQuery, GetOrderByCustomerResult>
    {
        public async Task<GetOrderByCustomerResult> Handle(GetOrderByCustomerQuery qurey, CancellationToken cancellationToken)
        {
            var orders = await context.Orders
                .Include(o => o.OrderItems)
                .AsNoTracking()
                .Where(o => o.CustomerId == CustomerId.Of(qurey.CustomerId))
                .OrderBy(o => o.OrderName)
                //.ProjectToType<OrderDto>()
                .ToListAsync(cancellationToken);
            return new GetOrderByCustomerResult(orders.ToOrderDtoList());
        }
    }
}
