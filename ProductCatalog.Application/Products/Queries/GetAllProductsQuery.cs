using MediatR;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Interfaces;

namespace ProductCatalog.Application.Products.Queries
{
    // Query - Represents the request to get all products
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }

    // Handler - Processes the GetAllProductsQuery
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(ProductDto.FromEntity);
        }
    }
}
