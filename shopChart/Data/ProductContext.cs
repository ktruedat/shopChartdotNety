using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace shopChart.Data;

public class ProductContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Host=localhost;Port=5432;Database=shopchart;Username=postgres;Password=admin;";
            var conn = new NpgsqlConnection(connectionString);
            optionsBuilder.UseNpgsql(conn);
        }
    }

    public void SeedInitialData()
    {
        if (Products.Any())
        {
            Products.RemoveRange(Products);
            SaveChanges();
        }

        if (Categories.Any())
        {
            Categories.RemoveRange(Categories);
            SaveChanges();
        }

        var footwearCategory = new Category { Id = 1, Name = "Footwear" };
        var equipmentCategory = new Category { Id = 2, Name = "Equipment" };

        Products.Add(new Product
        {
            Id = 1, Name = "Ex89", Price = 70.00M, IsActive = true,
            Category = footwearCategory,
            Description = "YOU WANT THESE SNEAKERS"
        });

        Products.Add(new Product
        {
            Id = 2, Name = "CX90", Price = 50000, IsActive = true,
            Category = equipmentCategory,
            Description = "YOU WANT THIS CAR"
        });

        Products.Add(new Product
        {
            Id = 3, Name = "LEGION 5 PRO", Price = 1200.00M, IsActive = false,
            Category = equipmentCategory,
            Description = "SOLD OUT"
        });

        Products.Add(new Product
        {
            Id = 4, Name = "LEGION 5 NOT SO PRO", Price = 1199.99M, IsActive = true,
            Category = equipmentCategory,
            Description = "HAVENT SOLD ANYTHING YET"
        });

        Products.Add(new Product
        {
            Id = 5, Name = "HUMAN WATER", Price = 999999, IsActive = true,
            Category = equipmentCategory,
            Description = "HUMANLY WATER"
        });
        Products.Add(new Product
        {
            Id = 6, Name = "INHUMAN WATER", Price = 1, IsActive = true,
            Category = footwearCategory,
            Description = "INHUMANLY WATER"
        });

        Categories.Add(footwearCategory);
        Categories.Add(equipmentCategory);

        SaveChanges();
    }
}
