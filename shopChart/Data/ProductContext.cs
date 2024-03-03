using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace shopChart.Data;

public class ProductContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Producer> Producers => Set<Producer>();
    public DbSet<Sale> Sales => Set<Sale>();

    public DbSet<Promotion> Promotions => Set<Promotion>();


    public string DbConnString { get; set; }

    public ProductContext(IConfiguration config)
    {
        DbConnString = config.GetConnectionString("PostgreSQLConnString");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var conn = new NpgsqlConnection(DbConnString);
            optionsBuilder.UseNpgsql(conn);
        }
    }

}