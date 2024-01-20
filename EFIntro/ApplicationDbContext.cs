using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace EFIntro;

class ApplicationDbContext : DbContext
{
    private IConfiguration _configuration;
    
#pragma warning disable CS8618
    public ApplicationDbContext(IConfiguration configuration)
#pragma warning restore CS8618
    {
        _configuration = configuration;
        
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration["ConnectionString"]);
        
        base.OnConfiguring(optionsBuilder);
    }
    
    public DbSet<User> Users { get; set; }
}