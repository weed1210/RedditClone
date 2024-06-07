using Microsoft.AspNetCore.Identity;

namespace Reddit.Domain.Entities;
public class Role : IdentityRole<Guid>
{
    public virtual ICollection<UserRole>? UserRoles { get; set; }
}
