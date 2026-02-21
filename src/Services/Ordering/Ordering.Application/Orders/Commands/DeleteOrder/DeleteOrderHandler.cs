namespace Ordering.Application.Orders.Commands.DeleteOrder
{
    class DeleteOrderHandler(IApplicationDbContext context) : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
    {
        public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            // get Order
            var orderId = OrderId.Of(command.OrderId);
            var order = await context.Orders
                .FindAsync(orderId,cancellationToken);
            if (order is null)
                throw new OrderNotFoundException(command.OrderId);
            //save to database
            context.Orders.Remove(order);
            await context.SaveChangesAsync(cancellationToken);
            // return result
            return new DeleteOrderResult(true);
   
        }

    }
}
