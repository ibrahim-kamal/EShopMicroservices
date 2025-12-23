using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BuildingBlocks.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
    {

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any()) {
                var context = new ValidationContext<TRequest>(request);
                var validationRequests = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationRequests.SelectMany(x => x.Errors).Where(r => r != null).ToList();

                if (failures.Any()) {
                    throw new ValidationException(failures);
                }

            }


            return await next();
        }
    }
}
