using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Migrations;

public class Account
{
    public int Id { get; set; }
    public string Login { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public int Attempts { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
}