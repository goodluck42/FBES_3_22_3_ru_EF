using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnnotations;

public class UserGame
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public int GameId { get; set; }
    public Game Game { get; set; } = null!;
}