using System.Text;

namespace Migrations;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public virtual ICollection<Account> Accounts { get; set; } = null!;
    public int? UserAddressId { get; set; }
    public virtual UserAddress? UserAddress { get; set; }
    
    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.Append(Id.ToString());
        builder.Append('\n');
        builder.Append(FirstName);
        builder.Append('\n');
        
        return builder.ToString();
    }
}