// File: practice_0502025.Entities/OrderItem.cs
using System.ComponentModel.DataAnnotations.Schema; // For [Column]

namespace practice_0502025.Entities
{
    public class OrderItem
    {
        public int Id { get; set; } // Primary Key

        // Foreign Key to Order
        public int OrderId { get; set; }
        // Navigation property: An OrderItem belongs to one Order
        public Order Order { get; set; } = null!;

        // Foreign Key to Product
        public int ProductId { get; set; }
        // Navigation property: An OrderItem references one Product
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; } // Quantity of the product in this order item
        [Column(TypeName = "decimal(18, 2)")] // Price of the product at the time of purchase
        public decimal UnitPrice { get; set; }
    }
}