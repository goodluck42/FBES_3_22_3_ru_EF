using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnnotations;

public class Account
{
    public int Id { get; set; }
    [MaxLength(128)]
    public string Login { get; set; } = null!;
    [MaxLength(256)]
    public string PasswordHash { get; set; } = null!;
    [Range(0, 4)]
    public int Attempts { get; set; }
    
    // variant 1
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}