using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<int> CreateAsync(Product product);
    }
}