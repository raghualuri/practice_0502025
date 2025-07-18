﻿
using practice_0502025.Entities;
using practice_0502025.Application.DTOs;
using practice_0502025.Application.Interfaces;

namespace practice_0502025.Application
{
    public interface IProductService: IGenericService<Product,ProductDto>
    {

        //Task<IEnumerable<ProductDto>> GetAllAsync();
        //Task<ProductDto> GetByIdAsync(int id);
        //Task<ProductDto> CreateAsync(ProductDto product);
        //Task UpdateAsync(ProductDto product);
        //Task DeleteAsync(int id);
    }
}
