using BuildingBlocks.CQRS;
using MediatR;
using System.Windows.Input;

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
            throw new NotImplementedException();
        }
    }
}
