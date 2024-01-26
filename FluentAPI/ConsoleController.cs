using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.Extensions.Configuration;

namespace FluentAPI;
class ConsoleController(ApplicationDbContext dbContext, IConfiguration configuration)
{
    public void Start()
    {
        bool flag = true;
        
        Console.WriteLine("0 - Exit");
        Console.WriteLine("1 - Insert a User");
        Console.WriteLine("2 - Get User by Id (Lazy)");
        Console.WriteLine("20 - Get User by Id (Eager)");
        Console.WriteLine("3 - Get all Users");
        Console.WriteLine("4 - Delete User by Id");
        Console.WriteLine("5 - Update User by Id");
        
        while (flag)
        {
            int operation = int.Parse(Console.ReadLine()!);

            switch (operation)
            {
                case 0:
                    flag = false;
                    break;
                case 1:
                {
                    dbContext.Users.Add(new User
                    {
                        BirthDate = DateTime.Now,
                        FirstName = Console.ReadLine()!,
                        LastName = Console.ReadLine()!
                    });

                    dbContext.SaveChanges();

                    break;
                }

                case 2:
                {
                    Console.Write("Enter id:");

                    using var userDbContext = new ApplicationDbContext(configuration);
                
                    int id = int.Parse(Console.ReadLine()!);

                    var user = dbContext.Users.FirstOrDefault(u => u.Id == id);

                    if (user != null)
                    {
                        Console.WriteLine(user.Id);
                        Console.WriteLine(user.BirthDate);
                        Console.WriteLine(user.FirstName);
                        Console.WriteLine(user.LastName);
                        Console.WriteLine(user.UserAddress == null ? "does not have address" : "has address");

                        foreach (var account in user.Accounts)
                        {
                            Console.WriteLine($"Login: {account.Login}");
                            Console.WriteLine($"PasswordHash: {account.PasswordHash}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not found");
                    }

                    break;
                }

                case 20:
                {
                    Console.Write("Enter id:");

                    var arr = new int[3] { 1, 2, 3};
                    using var userDbContext = new ApplicationDbContext(configuration);

                    userDbContext.ChangeTracker.LazyLoadingEnabled = false;
                    
                    int id = int.Parse(Console.ReadLine()!);

                    // Eager loading

                    var user = dbContext.Users
                        .Include(u => u.Accounts)
                        .ThenInclude(a => a.User)
                        .Include(u => u.UserAddress)
                        .FirstOrDefault(u => u.Id == id);
                    
                    if (user != null)
                    {
                        Console.WriteLine(user.Id);
                        Console.WriteLine(user.BirthDate);
                        Console.WriteLine(user.FirstName);
                        Console.WriteLine(user.LastName);
                        Console.WriteLine(user.UserAddress == null ? "does not have address" : "has address");

                        foreach (var account in user.Accounts)
                        {
                            Console.WriteLine($"Login: {account.Login}");
                            Console.WriteLine($"PasswordHash: {account.PasswordHash}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not found");
                    }

                    break;
                }

                case 3:
                {
                    var users = dbContext.Users.ToList();

                    users.ForEach(Console.WriteLine);

                    break;
                }
                case 4:
                {
                    //// Variant 1 (non-optimized)
                    // Console.Write("Enter id: ");
                    // var id = int.Parse(Console.ReadLine()!);
                    // var result = _dbContext.Users.FirstOrDefault(u => u.Id == id);
                    //
                    // if (result != null)
                    // {
                    //     _dbContext.Users.Remove(result);
                    //
                    //     _dbContext.SaveChanges();
                    // }

                    //// Variant 2 (test)
                    Console.Write("Enter id: ");

                    User user = new User
                    {
                        Id = int.Parse(Console.ReadLine()!)
                    };

                    dbContext.Users.Remove(user);

                    dbContext.SaveChanges();

                    break;
                }
                case 5:
                {
                    var id = int.Parse(Console.ReadLine()!);
                    var user = dbContext.Users.FirstOrDefault(u => u.Id == id);

                    if (user != null)
                    {
                        user.FirstName = user.FirstName.ToUpper();
                        user.LastName = user.LastName.ToUpper();

                        dbContext.Users.Update(user);

                        dbContext.SaveChanges();
                    }
                    
                    break;
                }
            }
        }
    }
}