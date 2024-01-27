using System.ComponentModel.DataAnnotations;

namespace Migrations;

public class UserAddress
{
    [Key] public int Id { get; set; }

    [MaxLength(32)] public string Country { get; set; } = null!;

    [MaxLength(1024)] public string City { get; set; } = null!;
    
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
}