namespace Ordering.Application.Orders.Queries.GetOrderByCustomer
{
    public class GetOrdersByCustomerHandler(IApplicationDbContext context) 
        : IQueryHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerResult>
    {
        public async Task<GetOrdersByCustomerResult> Handle(GetOrdersByCustomerQuery qurey, CancellationToken cancellationToken)
        {
            var orders = await context.Orders
                .Include(o => o.OrderItems)
                .AsNoTracking()
                .Where(o => o.CustomerId == CustomerId.Of(qurey.CustomerId))
                .OrderBy(o => o.OrderName)
                //.ProjectToType<OrderDto>()
                .ToListAsync(cancellationToken);
            return new GetOrdersByCustomerResult(orders.ToOrderDtoList());
        }
    }
}
