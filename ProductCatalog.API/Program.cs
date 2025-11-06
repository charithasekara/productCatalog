var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ProductCatalog.Application.Products.Queries.GetAllProductsQuery).Assembly));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

//Create DB Connection for Dapper
builder.Services.AddSingleton(new ProductCatalog.Infrastructure.Data.DatabaseConnectionFactory(connectionString));
//Register Repository & Connects application layer with infrastructure layer
builder.Services.AddScoped<ProductCatalog.Application.Interfaces.IProductRepository, ProductCatalog.Infrastructure.Data.ProductRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
