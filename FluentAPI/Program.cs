using FluentAPI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.DependencyInjection;


var serviceCollection = new ServiceCollection();

{
    var configurationBuilder = new ConfigurationBuilder();

    configurationBuilder.AddJsonFile("config.json");

    IConfiguration configuration = configurationBuilder.Build();

    serviceCollection.AddSingleton<IConfiguration>(provider =>
    {
        return configuration;
    });
}
serviceCollection.AddTransient<ApplicationDbContext>();
serviceCollection.AddTransient<ConsoleController>();


var provider = serviceCollection.BuildServiceProvider();

var consoleController = provider.GetService<ConsoleController>()!;

consoleController.Start();

public static partial class Program
{
    public static string Test = "user_table";
}
