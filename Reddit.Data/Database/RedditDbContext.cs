using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reddit.Domain.Entities;
using System.Reflection;

namespace Reddit.Domain.Database;
public class RedditDbContext : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
{
    public RedditDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .AddInterceptors(new SoftDeleteInterceptor());

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>(entity => entity.ToTable("Users"));
        builder.Entity<Member>(entity => entity.ToTable("Members"));
        builder.Entity<Staff>(entity => entity.ToTable("Staffs"));

        builder.FilterSoftDeleted();
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<User> User { get; set; }
    public DbSet<UserRole> UserRole { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<Post> Posts { get; set; }
}
