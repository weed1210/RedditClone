using Microsoft.AspNetCore.Identity;
using Reddit.Domain.Entities.Abstractions;
using Reddit.Domain.Enums;

namespace Reddit.Domain.Entities;
public class User : IdentityUser<Guid>, ISoftDelete
{
    public DateTimeOffset? DeletedAt { get; set; }
    public UserType Type { get; set; }

    public virtual ICollection<UserRole>? UserRoles { get; set; }
}
