using Reddit.DataAccess.Base;
using Reddit.DataAccess.Repositories.Interfaces;
using Reddit.Domain.Database;
using Reddit.Domain.Entities;

namespace Reddit.DataAccess.Repositories;
public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(RedditDbContext dbContext) : base(dbContext)
    {
    }
}
