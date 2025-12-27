
namespace Catelog.API.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImgaeFile, decimal Price) : ICommand<UpdateProductResult>;
    public record UpdateProductResult(bool IsSuccess);
    public class UpdateProductHandler(IDocumentSession documentSession)
        :ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        private readonly IDocumentSession _documentSession = documentSession;

        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _documentSession.LoadAsync<Product>(command.Id, cancellationToken);
            if (product is null)
                throw new ProductNotFoundException(command.Id);
            command.Adapt(product);
            _documentSession.Update(product);
            await _documentSession.SaveChangesAsync();
            
            return new UpdateProductResult(true);
        }
    }
}
