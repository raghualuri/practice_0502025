// File Path: practice_0502025/Mapping/MappingProfile.cs

using AutoMapper;
using practice_0502025.Application.DTO; // Make sure this path is correct for your DTOs
using practice_0502025.Entities;      // Make sure this path is correct for your Entities

namespace practice_0502025.Mapping // This namespace should match your new folder
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map from ProductDto (source, e.g., from API request body) to Product entity (destination, for DB)
            CreateMap<ProductDto, Product>();

            // Map from Product entity (source, e.g., from DB) to ProductDto (destination, for API response)
            CreateMap<Product, ProductDto>();

            // If you want to map in both directions for Product and it's always symmetrical:
            // CreateMap<Product, ProductDto>().ReverseMap();

            // Add mappings for Car if you have a CarDto and Car entity:
            // CreateMap<CarDto, Car>();
            // CreateMap<Car, CarDto>();
            // Or: CreateMap<Car, CarDto>().ReverseMap();
        }
    }
}