// File: practice_0502025.Entities/Category.cs
using System.Collections.Generic; // For ICollection

namespace practice_0502025.Entities
{
    public class Category
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } = string.Empty;

        // Navigation property: A Category can have many Products
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}