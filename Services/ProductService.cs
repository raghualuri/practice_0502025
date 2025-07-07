using AutoMapper;
using practice_0502025.Application; // Assuming ApplicationDbContext is here if needed
using practice_0502025.Application.DTOs; // For ProductDto
using practice_0502025.Application.Interfaces; // For IGenericRepository, IUnitOfWork, IProductService
using practice_0502025.Entities; // For Product entity


namespace practice_0502025.Services.Implementations
{
    // ProductService inherits from GenericService, fulfilling the IProductService contract
    public class ProductService : GenericService<Product, ProductDto>, IProductService
    {
        // No need to redeclare _repository, _unitOfWork, _mapper as they are in the base class.
        // You can access them via 'base._repository', etc. if needed, but usually not directly.

        public ProductService(
            IGenericRepository<Product> repository, // Injects IGenericRepository for Product
            IUnitOfWork unitOfWork,
            IMapper mapper)
            : base(repository, mapper, unitOfWork) // Passes dependencies to the base GenericService constructor
        {
            // Any Product-specific initialization can go here.
            // If IProductService had unique methods, they would be implemented here.
        }

        // Example of a Product-specific method if IProductService were extended:
        /*
        public async Task<IEnumerable<ProductDto>> GetProductsByCategory(int categoryId)
        {
            var products = await base._repository.FindAsync(p => p.CategoryId == categoryId);
            return base._mapper.Map<IEnumerable<ProductDto>>(products);
        }
        */
    }
}