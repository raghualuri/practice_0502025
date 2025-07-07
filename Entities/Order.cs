// File: practice_0502025.Entities/Order.cs
using System;
using System.Collections.Generic; // For ICollection
using System.ComponentModel.DataAnnotations.Schema; // For [Column]

namespace practice_0502025.Entities
{
    public class Order
    {
        public int Id { get; set; } // Primary Key
        public DateTime OrderDate { get; set; } = DateTime.UtcNow; // When the order was placed
        public int CustomerId { get; set; } // Simple customer ID (could be FK to a Customer entity)
        [Column(TypeName = "decimal(18, 2)")] // Specifies decimal precision for SQL Server
        public decimal TotalAmount { get; set; } // Total amount of the order

        // Navigation property: An Order has many OrderItems
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        // You might add a Customer navigation property if you have a Customer entity:
        // public Customer Customer { get; set; } = null!;
    }
}