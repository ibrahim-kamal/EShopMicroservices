
namespace Catelog.API.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);

    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand> {
        public DeleteProductCommandValidator(){
            RuleFor(x => x)
                .NotEmpty().WithMessage("Product Id is required");
        }
    }
    public class DeleteProductHandler(IDocumentSession documentSession,ILogger<DeleteProductHandler> logger)
        :ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        private readonly IDocumentSession _documentSession = documentSession;
        private readonly ILogger<DeleteProductHandler> _logger = logger;

        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("DeleteProductHandler.Handle called with (@command)", command);
            _documentSession.Delete<Product>(command.Id);
            await _documentSession.SaveChangesAsync();
            
            return new DeleteProductResult(true);
        }
    }
}
