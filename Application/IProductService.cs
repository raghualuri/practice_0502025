
//using practice_0502025.Entities.ProductDto
    using practice_0502025.Application.DTO;
using practice_0502025.Application.Interfaces;

namespace practice_0502025.Application
{
    public interface IProductService: IGenericService<ProductDto>
    {

        //Task<IEnumerable<ProductDto>> GetAllAsync();
        //Task<ProductDto> GetByIdAsync(int id);
        //Task<ProductDto> CreateAsync(ProductDto product);
        //Task UpdateAsync(ProductDto product);
        //Task DeleteAsync(int id);
    }
}
