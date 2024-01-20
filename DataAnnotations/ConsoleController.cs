namespace DataAnnotations;
class ConsoleController
{
    private readonly ApplicationDbContext _dbContext;

    public ConsoleController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Start()
    {
        return;
        
        bool flag = true;
        
        Console.WriteLine("0 - Exit");
        Console.WriteLine("1 - Insert a User");
        Console.WriteLine("2 - Get User by Id");
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
                    _dbContext.Users.Add(new User
                    {
                        BirthDate = DateTime.Now,
                        FirstName = Console.ReadLine()!,
                        LastName = Console.ReadLine()!
                    });

                    _dbContext.SaveChanges();

                    break;
                }

                case 2:
                {
                    Console.Write("Enter id:");

                    int id = int.Parse(Console.ReadLine()!);

                    var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

                    if (user != null)
                    {
                        Console.WriteLine(user.Id);
                        Console.WriteLine(user.BirthDate);
                        Console.WriteLine(user.FirstName);
                        Console.WriteLine(user.LastName);
                    }
                    else
                    {
                        Console.WriteLine("Not found");
                    }

                    break;
                }

                case 3:
                {
                    var users = _dbContext.Users.ToList();

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

                    _dbContext.Users.Remove(user);

                    _dbContext.SaveChanges();

                    break;
                }
                case 5:
                {
                    var id = int.Parse(Console.ReadLine()!);
                    var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

                    if (user != null)
                    {
                        user.FirstName = user.FirstName.ToUpper();
                        user.LastName = user.LastName.ToUpper();

                        _dbContext.Users.Update(user);

                        _dbContext.SaveChanges();
                    }
                    
                    break;
                }
            }
        }
    }
}