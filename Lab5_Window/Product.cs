using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Lab5_Window
{
    public class Product
    {
        [Key] public int Id { get; set; }
        [Required, MaxLength(30)] public string Name { get; set; }
        [MaxLength(500)] public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
    }

    public class StoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}