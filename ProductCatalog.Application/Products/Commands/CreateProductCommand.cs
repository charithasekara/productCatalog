using MediatR;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Interfaces;

namespace ProductCatalog.Application.Products.Commands
{
    // Command - Represents the request to create a product
    public class CreateProductCommand : IRequest<int>
    {
        public ProductDto Product { get; set; }

        public CreateProductCommand(ProductDto product)
        {
            Product = product;
        }
    }

    // Handler - Processes the CreateProductCommand
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Product.ToEntity();
            product.CreatedAt = DateTime.UtcNow;
            return await _productRepository.CreateAsync(product);
        }
    }
}
