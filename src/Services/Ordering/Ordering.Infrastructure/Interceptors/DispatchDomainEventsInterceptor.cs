using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Ordering.Domain.Abstractions;

namespace Ordering.Infrastructure.Interceptors
{
    internal class DispatchDomainEventsInterceptor(IMediator mediator) : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            DispatchDomainEvents(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            DispatchDomainEvents(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public async Task DispatchDomainEvents(DbContext? context) {
            if(context is null) return;
            var aggregates = context.ChangeTracker.Entries<IAggregate>().Where(a => a.Entity.DomainEvents.Any()).Select(a => a.Entity);
            var events = aggregates.SelectMany(a => a.DomainEvents).ToList();
            aggregates.ToList().ForEach(a => a.ClearDomainEvents());

            foreach (var domainEvent in events)
                await mediator.Publish(domainEvent);
        }
    }
}
