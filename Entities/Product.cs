// File: practice_0502025.Entities/Product.cs
using System.ComponentModel.DataAnnotations.Schema; // For [Column]

namespace practice_0502025.Entities
{
    public class Product
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18, 2)")] // Specifies decimal precision for SQL Server
        public decimal Price { get; set; }
        public int Stock { get; set; } // Quantity available in inventory

        // Foreign Key to Category
        public int CategoryId { get; set; }
        // Navigation property: A Product belongs to one Category
        public Category Category { get; set; } = null!;
    }
}