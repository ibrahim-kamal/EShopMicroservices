

namespace Catelog.API.Products.Commands.CreateProduct
{
    public record CreateProductCommand(
        string Name,List<string> Category ,string Description,string ImgaeFile,decimal Price
        ) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler(IDocumentSession documentSession) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IDocumentSession _documentSession = documentSession;
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // create Product entity from command object 
            // save to database
            //return CreateProductResult result

            //var product = new Product
            //{
            //    Name = command.Name,
            //    Category = command.Category,
            //    Description = command.Description,
            //    ImgaeFile = command.ImgaeFile,
            //    Price = command.Price
            //};
            var product = command.Adapt<Product>();
            _documentSession.Store(product);
            await _documentSession.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(product.Id);

        }
    }
}
