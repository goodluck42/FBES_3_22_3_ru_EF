using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluentAPI;

public class UserAddress
{
    [Key] public int Id { get; set; }

    [MaxLength(32)] public string Country { get; set; } = null!;

    [MaxLength(1024)] public string City { get; set; } = null!;
    
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
}