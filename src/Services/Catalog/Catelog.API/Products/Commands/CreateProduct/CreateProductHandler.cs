using BuildingBlocks.CQRS;
using Catelog.API.Models;

namespace Catelog.API.Products.Commands.CreateProduct
{
    public record CreateProductCommand(
        string Name,List<string> Category ,string Description,string ImgaeFile,decimal Price
        ) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // create Product entity from command object 
            // save to database
            //return CreateProductResult result

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImgaeFile = command.ImgaeFile,
                Price = command.Price
            };

            return Task.FromResult(new CreateProductResult(Guid.NewGuid()));

        }
    }
}
