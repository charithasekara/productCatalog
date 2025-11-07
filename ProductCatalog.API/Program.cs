var builder = WebApplication.CreateBuilder(args);

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:5174", "https://localhost:5174")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithExposedHeaders("Content-Range")  // If you need pagination
               .SetIsOriginAllowed(origin => true);  // Allow any origin in development
    });
});

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

app.UseCors();

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
