using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataAnnotations;

[Table("user_table"), Index(nameof(User.Phone))]
public class User
{
    [Column("id"), Key]
    public int Id { get; set; }
    [Column("name"), MaxLength(128)]
    public string FirstName { get; set; } = null!;
    [Column("surname"), MaxLength(128)]
    public string LastName { get; set; } = null!;
    [Column("date_of_birth")]
    public DateTime BirthDate { get; set; }

    [MaxLength(64)]
    public string Phone { get; set; } = null!;
    
    public ICollection<Account> Accounts { get; set; } = null!; // one-to-many

    [ForeignKey(nameof(UserAddress))]
    public int UserAddressId { get; set; }
    public UserAddress UserAddress { get; set; } = null!;

    public ICollection<Game> Games { get; set; } = null!; // many-to-many
    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.Append(Id.ToString());
        builder.Append('\n');
        builder.Append(FirstName);
        builder.Append('\n');
        builder.Append(LastName);
        
        return builder.ToString();
    }
}