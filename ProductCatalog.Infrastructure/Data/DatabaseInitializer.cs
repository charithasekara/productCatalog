namespace ProductCatalog.Infrastructure.Data
{
    public class DatabaseInitializer
    {
        private readonly DatabaseConnectionFactory _connectionFactory;

        public DatabaseInitializer(DatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Initialize()
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Products (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Description TEXT,
                    Price DECIMAL(18,2) NOT NULL,
                    StockQuantity INTEGER NOT NULL,
                    Category TEXT NOT NULL,
                    CreatedAt DATETIME NOT NULL,
                    UpdatedAt DATETIME
                );";

            command.ExecuteNonQuery();
        }
    }
}