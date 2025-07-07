using AutoMapper;
using practice_0502025.Application; // Assuming ApplicationDbContext is here if needed
using practice_0502025.Application.DTOs; // For ProductDto
using practice_0502025.Application.Interfaces; // For IGenericRepository, IUnitOfWork, IProductService
using practice_0502025.Entities; // For Product entity

namespace practice_0502025.Services.Implementations
{
    public class CategoryService : GenericService<Category, CategoryDto>, ICategoryService
    {
        public CategoryService(
            IGenericRepository<Category> repository,
            IUnitOfWork unitOfWork,
            IMapper mapper):
            base(repository , mapper, unitOfWork)
        {
            // ...
        }
        // ...
    }
}
