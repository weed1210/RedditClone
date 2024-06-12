using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reddit.Domain.Entities;
using Reddit.Domain.Enums;
using Reddit.Domain.Extensions;
using System.Reflection;
using System.Text.RegularExpressions;
using Task = Reddit.Domain.Entities.Task;

namespace Reddit.Domain.Database;
public class RedditDbContext(DbContextOptions options) : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new SoftDeleteInterceptor());
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>()
            .HasDiscriminator(x => x.Type)
            .HasValue(UserType.Base);

        builder.Entity<Member>()
            .HasDiscriminator(x => x.Type)
            .HasValue(UserType.Member);

        builder.Entity<Member>()
           .HasMany(x => x.Tasks)
           .WithOne(t => t.Member)
           .HasForeignKey(m => m.MemberId).OnDelete(DeleteBehavior.SetNull);

        builder.Entity<Member>()
           .HasMany(x => x.CoperatingTasks)
           .WithOne(t => t.Coperator)
           .HasForeignKey(m => m.CoperatorId).OnDelete(DeleteBehavior.SetNull);

        builder.Entity<Staff>()
            .HasDiscriminator(x => x.Type)
            .HasValue(UserType.Staff);

        builder.SeedUserRole();
        builder.FilterSoftDeleted();
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<User> User { get; set; }
    public DbSet<UserRole> UserRole { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Task> Tasks { get; set; }
}
