using Microsoft.EntityFrameworkCore;
using Reddit.Domain.Entities;

namespace Reddit.Domain.Database;
public static class ModelBuilderExtensions
{
    public static void FilterSoftDeleted(this ModelBuilder builder)
    {
        builder.Entity<User>().HasQueryFilter(x => x.DeletedAt == null);
        builder.Entity<Member>().HasQueryFilter(x => x.DeletedAt == null);
        builder.Entity<Staff>().HasQueryFilter(x => x.DeletedAt == null);
        builder.Entity<Post>().HasQueryFilter(x => x.DeletedAt == null);
    }
}
