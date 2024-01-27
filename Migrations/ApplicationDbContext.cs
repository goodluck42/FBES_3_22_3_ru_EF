using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Bogus;

namespace Migrations;

class ApplicationDbContext : DbContext
{
    private IConfiguration _configuration;

#pragma warning disable CS8618
    public ApplicationDbContext(IConfiguration configuration) : base()
#pragma warning restore CS8618
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration["ConnectionString"])
            .UseLazyLoadingProxies();

        optionsBuilder.LogTo(Console.WriteLine);
        base.OnConfiguring(optionsBuilder);
    }

    // FluentAPI
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        {
            var faker = new Faker<User>();

            int id = -1;

            faker.RuleFor(u => u.Id, _ => id--)
                .RuleFor(u => u.FirstName, f => f.Person.FirstName)
                .RuleFor(u => u.Email, f => f.Person.Email);

            var generatedData = faker.Generate(10);

            generatedData[4].UserAddressId = -1; // address
            modelBuilder.Entity<User>(entity => { entity.HasData(generatedData); });
        }

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasData(new Account()
                {
                    Id = -1,
                    PasswordHash = "my_passhash",
                    Login = "test_login",
                    UserId = -5
                },
                new Account()
                {
                    Id = -2,
                    PasswordHash = "my_testPassHash",
                    Login = "test_login2",
                    UserId = -5
                });
        });

        modelBuilder.Entity<UserAddress>(entity =>
        {
            entity.HasData(new UserAddress
            {
                Id = -1,
                UserId = -5,
                City = "Baku",
                Country = "AZ"
            });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(u => u.Email)
                .IsUnique();

            entity.Property(u => u.Email)
                .HasColumnName("mail");

            entity.HasKey(u => u.Id);
            entity.ToTable("user_table");

            entity.Property(u => u.Id)
                .HasColumnName("id");

            entity.Property(u => u.FirstName)
                .HasColumnName("name")
                .HasMaxLength(128);
            
            // one-to-one
            entity.HasOne(u => u.UserAddress)
                .WithOne(ua => ua.User)
                .HasForeignKey<User>()
                .OnDelete(DeleteBehavior.Cascade);

            // one-to-many
            entity.HasMany(u => u.Accounts)
                .WithOne(a => a.User);
        });

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserAddress> UserAddresses { get; set; }
    public DbSet<Account> Accounts { get; set; }
}