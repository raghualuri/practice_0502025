// File: practice_0502025.Application.DTOs/OrderDto.cs
using System;
using System.Collections.Generic; // For ICollection

namespace practice_0502025.Application.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }

        // List of items in the order
        public ICollection<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
}