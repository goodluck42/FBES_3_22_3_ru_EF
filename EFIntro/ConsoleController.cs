namespace EFIntro;

class ConsoleController
{
    private readonly ApplicationDbContext _dbContext;

    public ConsoleController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Start()
    {
        _dbContext.Users.Add(new User
        {
            BirthDate = DateTime.Now,
            FirstName = "Vadick",
            LastName = "Siga"
        });

        _dbContext.SaveChanges();
    }
}