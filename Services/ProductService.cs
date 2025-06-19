// practice_0502025/Services/ProductService.cs
using AutoMapper;
using practice_0502025.Application; // For ApplicationDbContext (indirectly via repository)
using practice_0502025.Application.DTO; // For ProductDto
using practice_0502025.Entities; // For Product entity
using practice_0502025.Application.Interfaces; // For IGenericRepository and IGenericService
using practice_0502025.Services.Implementations; // For GenericService

namespace practice_0502025.Services
{
    // ProductService now inherits from GenericService, passing Product and ProductDto types.
    // It also implements IProductService (which in turn inherits from IGenericService).
    public class ProductService : GenericService<Product, ProductDto>, IProductService
    {
        // This constructor passes the injected IGenericRepository<Product> and IMapper
        // to the base GenericService. The base class handles all the generic CRUD logic.
        public ProductService(IGenericRepository<Product> repository, IMapper mapper)
            : base(repository, mapper)
        {
            // You would only add Product-specific methods here if IProductService
            // defined methods *beyond* the generic CRUD operations.
            // For example: Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(string category);
            // If there are no such specific methods, this constructor body can be empty.
        }

        // REMOVE any old/custom implementations of GetAllAsync, GetByIdAsync, CreateAsync,
        // UpdateAsync, DeleteAsync, as they are now inherited and implemented by GenericService.
    }
}