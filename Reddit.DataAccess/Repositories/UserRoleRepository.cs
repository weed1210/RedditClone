using Reddit.DataAccess.Abstractions.Interfaces;
using Reddit.Domain.Database;
using Reddit.Domain.Entities;
using Reddit.DataAccess.Repositories;

namespace Reddit.DataAccess.Abstractions;
public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(RedditDbContext dbContext) : base(dbContext)
    {
    }
}
