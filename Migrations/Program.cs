using System.Diagnostics;
using System.Reflection;
using System.Text;
using Migrations;
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

Program.ServiceProvider = provider;

var consoleController = provider.GetService<ConsoleController>()!;

consoleController.Start();

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

public static partial class Program
{
    public static string Test = "user_table";

    public static ServiceProvider ServiceProvider { get; private set; } = null!;
}
