using Reddit.DataAccess.Base;
using Reddit.DataAccess.Repositories.Interfaces;
using Reddit.Domain.Database;
using Reddit.Domain.Entities;

namespace Reddit.DataAccess.Repositories;
public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(RedditDbContext dbContext) : base(dbContext)
    {
    }
}