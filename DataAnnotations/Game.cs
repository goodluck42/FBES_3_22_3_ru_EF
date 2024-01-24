using System.ComponentModel.DataAnnotations;

namespace DataAnnotations;

public class Game
{
    public int Id { get; set; }
    [MaxLength(32)]
    public string Genre { get; set; } = null!;
    [MaxLength(32)]
    public string Name { get; set; } = null!;
    
    public ICollection<User> Users { get; set; } = null!;
}