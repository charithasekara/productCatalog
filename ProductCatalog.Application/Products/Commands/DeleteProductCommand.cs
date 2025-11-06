using MediatR;
using ProductCatalog.Application.Interfaces;

namespace ProductCatalog.Application.Products.Commands
{
    // Command - Represents the request to delete a product
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }

    // Handler - Processes the DeleteProductCommand
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteAsync(request.Id);
        }
    }
}
