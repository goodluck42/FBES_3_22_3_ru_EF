using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace FluentAPI;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string Phone { get; set; } = null!;
    public virtual ICollection<Account> Accounts { get; set; } = null!;
    public int? UserAddressId { get; set; }
    public virtual UserAddress? UserAddress { get; set; }
    public virtual ICollection<Game>? Games { get; set; }
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