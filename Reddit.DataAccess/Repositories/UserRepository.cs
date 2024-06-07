using Reddit.DataAccess.Abstractions.Interfaces;
using Reddit.DataAccess.Repositories;
using Reddit.Domain.Database;
using Reddit.Domain.Entities;

namespace Reddit.DataAccess.Abstractions;
public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(RedditDbContext dbContext) : base(dbContext)
    {
    }
}