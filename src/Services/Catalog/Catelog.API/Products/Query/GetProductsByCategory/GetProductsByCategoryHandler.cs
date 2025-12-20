
namespace Catelog.API.Products.Query.GetProductsByCategory
{
    public record GetProductsByCategoryQuery(string Category):IQuery<GetProductsByCategoryResult>;
    public record GetProductsByCategoryResult(IEnumerable<Product> Products);
    public class GetProductsByCategoryHandler
        (IDocumentSession documentSession,ILogger<GetProductsByCategoryHandler> logger) 
        : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
    {
        private readonly IDocumentSession _documentSession = documentSession;
        private readonly ILogger<GetProductsByCategoryHandler> _logger = logger;
        public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetProductByCategoryQuery.Handle Called with {@query}", query);

            var products = await _documentSession.Query<Product>()
                    .Where(p => p.Category.Contains(query.Category))
                    .ToListAsync(cancellationToken);

            return new GetProductsByCategoryResult(products);
        }
    }
}
