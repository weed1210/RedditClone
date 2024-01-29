using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Reddit.Domain.Entities;

namespace Reddit.Domain.Extensions;
public static class SeederExtension
{
    public static void SeedUserRole(this ModelBuilder builder)
    {
        var hasher = new PasswordHasher<User>();
        List<Guid> seedGuids = new()
        {
            new Guid("57ffb575-7c79-4133-8433-aebbcd71f824"),
            new Guid("4716f673-cef5-4edd-b67d-9c71599b9fab"),
            new Guid("1abb6e28-793d-460f-8a24-745998356da8"),
            new Guid("2e3566a9-02b1-4ec4-a2d4-b3bb3c4f2b45"),
            new Guid("01fc684c-d9d0-4fcc-b0a7-56fea6945928")
        };

        builder.Entity<Role>().HasData(new Role
        {
            Id = seedGuids[0],
            Name = "Member"
        });
        builder.Entity<Role>().HasData(new Role
        {
            Id = seedGuids[1],
            Name = "Admin",
        });
        builder.Entity<Role>().HasData(new Role
        {
            Id = seedGuids[2],
            Name = "Mod",
        });

        const string username = "super";
        const string phoneNumber = "0985097145";

        builder.Entity<User>().HasData(new User
        {
            Id = seedGuids[0],
            UserName = username,
            NormalizedUserName = username,
            Email = username + "@gmail.com",
            NormalizedEmail = username + "@gmail.com",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null!, "P@ssword123"),
            SecurityStamp = string.Empty,
            PhoneNumber = phoneNumber,
        });

        for (var i = 1; i <= 3; i++)
        {
            builder.Entity<UserRole>().HasData(new UserRole
            {
                RoleId = seedGuids[i - 1],
                UserId = seedGuids[0],
            });
        }
    }
}
