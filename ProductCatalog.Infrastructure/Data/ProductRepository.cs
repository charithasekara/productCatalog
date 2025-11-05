using Dapper;
using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseConnectionFactory _connectionFactory;

        public ProductRepository(DatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryAsync<Product>("SELECT * FROM Products");
        }

        public async Task<int> CreateAsync(Product product)
        {
            using var connection = _connectionFactory.CreateConnection();
            var sql = @"INSERT INTO Products (Name, Description, Price, StockQuantity, Category, CreatedAt, UpdatedAt)
                       VALUES (@Name, @Description, @Price, @StockQuantity, @Category, @CreatedAt, @UpdatedAt);
                       SELECT last_insert_rowid();";

            return await connection.ExecuteScalarAsync<int>(sql, product);
        }
    }
}