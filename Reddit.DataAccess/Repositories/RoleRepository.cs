using Reddit.DataAccess.Abstractions.Interfaces;
using Reddit.Domain.Database;
using Reddit.Domain.Entities;
using Reddit.DataAccess.Repositories;

namespace Reddit.DataAccess.Abstractions;
public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(RedditDbContext dbContext) : base(dbContext)
    {
    }
}
