

using FluentValidation;

namespace Catelog.API.Products.Commands.CreateProduct
{
    public record CreateProductCommand(
        string Name,List<string> Category ,string Description,string ImgaeFile,decimal Price
        ) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler(IDocumentSession documentSession,IValidator<CreateProductCommand> validator) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IDocumentSession _documentSession = documentSession;
        private readonly IValidator<CreateProductCommand> _validator = validator;
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(command,cancellationToken);
            var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
            if (errors.Any()) { 
                throw new ValidationException(errors.FirstOrDefault());
            }
            var product = command.Adapt<Product>();
            _documentSession.Store(product);
            await _documentSession.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(product.Id);

        }
    }
}
