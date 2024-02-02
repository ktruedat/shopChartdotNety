using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using shopChart.Areas.Identity.Data;

namespace shopChart.Data;

public class UserContext : IdentityDbContext<User>
{
    private readonly string _dbConnString;

    public UserContext(IConfiguration config)
    {
        _dbConnString = config.GetConnectionString("PostgreSQLConnString");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            var conn = new NpgsqlConnection(_dbConnString);
            options.UseNpgsql(conn);
        }
    }

}
