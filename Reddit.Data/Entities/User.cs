using Microsoft.AspNetCore.Identity;
using Reddit.Domain.Entities.Base;

namespace Reddit.Domain.Entities;
public class User : IdentityUser<Guid>, ISoftDelete
{
    public DateTimeOffset? DeletedAt { get; set; }

    public virtual ICollection<UserRole>? UserRoles { get; set; }
}
