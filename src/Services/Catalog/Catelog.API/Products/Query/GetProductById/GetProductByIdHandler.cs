

namespace Catelog.API.Products.Query.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product) ;
    public class GetProductByIdHandler(IDocumentSession documentSession) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        private readonly IDocumentSession _documentSession = documentSession;
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _documentSession.LoadAsync<Product>(query.Id, cancellationToken);
            if(product is null)
                throw new ProductNotFoundException();

            return new GetProductByIdResult(product);
        }
    }
}
