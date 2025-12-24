

namespace Catelog.API.Products.Query.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product) ;
    public class GetProductByIdHandler(IDocumentSession documentSession) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        private readonly IDocumentSession _documentSession = documentSession;
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery command, CancellationToken cancellationToken)
        {
            var product = await _documentSession.LoadAsync<Product>(command.Id, cancellationToken);
            if(product is null)
                throw new ProductNotFoundException(command.Id);

            return new GetProductByIdResult(product);
        }
    }
}
