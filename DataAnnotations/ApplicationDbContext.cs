using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Bogus;

namespace DataAnnotations;

class ApplicationDbContext : DbContext
{
    private IConfiguration _configuration;

#pragma warning disable CS8618
    public ApplicationDbContext(IConfiguration configuration) : base()
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

    // FluentAPI
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var faker = new Faker<User>("az");

        int id = -1;

        faker.RuleFor(u => u.Id, _ => id--)
            .RuleFor(u => u.FirstName, f => f.Person.FirstName)
            .RuleFor(u => u.LastName, f => f.Person.LastName)
            .RuleFor(u => u.BirthDate, f => f.Person.DateOfBirth)
            .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber());

        // modelBuilder.Entity<User>(entity => { entity.HasData(faker.Generate(10)); });
        //
        // modelBuilder.Entity<Account>(entity =>
        // {
        //     entity.HasData(new Account()
        //         {
        //             Id = -1,
        //             PasswordHash = "my_passhash",
        //             Login = "test_login",
        //             UserId = -5
        //         },
        //         new Account()
        //         {
        //             Id = -2,
        //             PasswordHash = "my_testPassHash",
        //             Login = "test_login2",
        //             UserId = -5
        //         });
        // });

        //modelBuilder.Entity<UserGame>(entity => { entity.HasKey(e => new { e.UserId, e.GameId }); });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasMany(u => u.Games)
                .WithMany(g => g.Users);
        });

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserAddress> UserAddresses { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Game> Games { get; set; }
    //public DbSet<UserGame> UserGames { get; set; }
}