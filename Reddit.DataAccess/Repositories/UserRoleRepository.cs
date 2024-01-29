using Reddit.DataAccess.Base;
using Reddit.DataAccess.Repositories.Interfaces;
using Reddit.Domain.Database;
using Reddit.Domain.Entities;

namespace Reddit.DataAccess.Repositories;
public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(RedditDbContext dbContext) : base(dbContext)
    {
    }
}
