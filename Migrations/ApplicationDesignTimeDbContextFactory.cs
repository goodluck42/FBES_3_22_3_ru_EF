using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Migrations;

class ApplicationDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder();

        configurationBuilder.AddJsonFile("config.json");
        
        return new ApplicationDbContext(configurationBuilder.Build());
    }
}