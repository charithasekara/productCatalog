# Product Catalog API

A .NET 9 Web API project for managing product catalog with clean architecture.

## Project Structure

- **ProductCatalog.API**: Web API layer with controllers and configuration
- **ProductCatalog.Application**: Business logic and application services
- **ProductCatalog.Infrastructure**: Data access and external services implementation

## Prerequisites

- .NET 9 SDK
- SQLite (Database)

## Getting Started

1. Clone the repository:
```bash
git clone https://github.com/charithasekara/productCatalog.git
```

2. Navigate to the API project directory:
```bash
cd productCatalog/ProductCatalog.API
```

3. Run the application:
```bash
dotnet run
```

The API will be available at:
- http://localhost:5150
- https://localhost:7081
- Swagger UI: http://localhost:5150/swagger

## API Endpoints

- `GET /api/products`: Get all products
- `POST /api/products`: Create a new product
- `PUT /api/products/{id}`: Update a product
- `DELETE /api/products/{id}`: Delete a product

## Technologies

- .NET 9
- MediatR for CQRS pattern
- Dapper for data access
- SQLite database
- Swagger for API documentation