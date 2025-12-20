namespace Catelog.API.Products.Query.GetProducts
{

    public record GetProductsQuery() : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
    public class GetProductsHandler(IDocumentSession documentSession,ILogger<GetProductsHandler> logger): IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        private readonly IDocumentSession _documentSession = documentSession;
        private readonly ILogger<GetProductsHandler> _logger = logger;
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsQueryHandler.Handle Called with {@Query}",query);
            var products = await documentSession.Query<Product>()
                    .ToListAsync(cancellationToken);
            return new GetProductsResult(products);
        }
    }
}
