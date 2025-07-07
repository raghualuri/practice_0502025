// File: practice_0502025.Application.DTOs/CreateOrderDto.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // For validation attributes

namespace practice_0502025.Application.DTOs
{
    public class CreateOrderDto
    {
        [Required]
        public int CustomerId { get; set; } // Customer making the order

        [Required]
        [MinLength(1, ErrorMessage = "Order must contain at least one item.")]
        public ICollection<CreateOrderItemDto> Items { get; set; } = new List<CreateOrderItemDto>();
    }

    // DTO for individual items within the order creation
    public class CreateOrderItemDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
        // UnitPrice is usually not sent by client for security, it's looked up by server
    }
}