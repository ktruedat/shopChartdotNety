using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace shopChart.Data;

public class ProductContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();

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

        Products.Add(new Product
        {
            Id = 1, Name = "Ex89", Price = 70.00M, IsActive = true,
            Description = "YOU WANT THESE SNEAKERS"
        });

        Products.Add(new Product
        {
            Id = 2, Name = "CX90", Price = 50000, IsActive = true,
            Description = "YOU WANT THIS CAR"
        });

        Products.Add(new Product
        {
            Id = 3, Name = "LEGION 5 PRO", Price = 1200.00M, IsActive = false,
            Description = "SOLD OUT"
        });

        Products.Add(new Product
        {
            Id = 4, Name = "LEGION 5 NOT SO PRO", Price = 1199.99M, IsActive = true,
            Description = "HAVENT SOLD ANYTHING YET"
        });

        Products.Add(new Product
        {
            Id = 5, Name = "LEGION 5 PRO", Price = 1200.00M, IsActive = false,
            Description = "SOLD OUT"
        });
    }
}
