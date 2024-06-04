using Reddit.DataAccess.Abstractions.Interfaces;
using Reddit.Domain.Database;
using Reddit.Domain.Entities;
using Reddit.DataAccess.Repositories;

namespace Reddit.DataAccess.Abstractions;
public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(RedditDbContext dbContext) : base(dbContext)
    {
    }
}