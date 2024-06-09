using Reddit.DataAccess.Abstractions.Interfaces;
using Reddit.DataAccess.Repositories;
using Reddit.Domain.Database;
using Reddit.Domain.Entities;

namespace Reddit.DataAccess.Abstractions;
public class UserRoleRepository(RedditDbContext dbContext) : BaseRepository<UserRole>(dbContext), IUserRoleRepository
{
}
