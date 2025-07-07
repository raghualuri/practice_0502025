// File: practice_0502025.Application.DTOs/ProductDto.cs
namespace practice_0502025.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; } // Include stock if relevant for display

        public int CategoryId { get; set; }
        public CategoryDto? Category { get; set; } // To include category details when fetching product
    }
}