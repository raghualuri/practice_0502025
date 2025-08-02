using Microsoft.EntityFrameworkCore;
using AutoMapper;
using practice_0502025.Application; // For ApplicationDbContext, IProductService
using practice_0502025.Services; // For ProductService
using practice_0502025.Application.Interfaces; // New: For IGenericRepository, IGenericService
using practice_0502025.Services.Implementations; // New: For GenericRepository, GenericService
using practice_0502025.Entities; // New: For Product entity
using practice_0502025.Application.DTOs; // New: For ProductDto
using practice_0502025.Infrastructure.Data;
using practice_0502025.Migrations; // Or where your UnitOfWork is

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// --- New: Register AutoMapper (point it to your MappingProfile's assembly) ---
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// --- New: Register Generic Repository ---
// This registers IGenericRepository<TEntity> to be implemented by GenericRepository<TEntity>
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// --- New: Register Generic Service for Product ---
// This registers IGenericService<ProductDto> to be implemented by GenericService<Product, ProductDto>
builder.Services.AddScoped<IGenericService<Product, ProductDto>, GenericService<Product, ProductDto>>();
builder.Services.AddScoped<IGenericService<Category, CategoryDto>, GenericService<Category, CategoryDto>>();
//builder.Services.AddScoped<IGenericService<Category, CategoryDto>, GenericService<Category, CategoryDto>>(); 
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// --- Update: Register Specific ProductService (ONLY if IProductService has methods beyond generic CRUD) ---
// If IProductService (and ProductService class) is *only* for generic CRUD,
// you could potentially remove the IProductService and ProductService classes
// and rely solely on IGenericService<ProductDto> injection in controllers.
// For now, keeping it as it was defined previously.
builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // --- New: Apply pending database migrations on application startup (in Development) ---
    // This ensures your database schema is up-to-date with your EF Core models.
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();