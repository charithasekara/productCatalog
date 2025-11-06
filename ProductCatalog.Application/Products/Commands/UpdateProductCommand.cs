using MediatR;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Interfaces;

namespace ProductCatalog.Application.Products.Commands
{
    // Command - Represents the request to update a product
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public ProductDto Product { get; set; }

        public UpdateProductCommand(int id, ProductDto product)
        {
            Id = id;
            Product = product;
        }
    }

    // Handler - Processes the UpdateProductCommand
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Product.ToEntity();
            product.Id = request.Id;
            product.UpdatedAt = DateTime.UtcNow;
            await _productRepository.UpdateAsync(product);
        }
    }
}
