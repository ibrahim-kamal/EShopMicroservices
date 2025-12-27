
namespace Catelog.API.Products.Query.GetProductsByCategory
{
    public record GetProductsByCategoryQuery(string Category):IQuery<GetProductsByCategoryResult>;
    public record GetProductsByCategoryResult(IEnumerable<Product> Products);
    public class GetProductsByCategoryHandler
        (IDocumentSession documentSession) 
        : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
    {
        private readonly IDocumentSession _documentSession = documentSession;
        public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
        {

            var products = await _documentSession.Query<Product>()
                    .Where(p => p.Category.Contains(query.Category))
                    .ToListAsync(cancellationToken);

            return new GetProductsByCategoryResult(products);
        }
    }
}
