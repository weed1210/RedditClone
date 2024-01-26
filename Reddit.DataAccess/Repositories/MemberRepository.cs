using Reddit.DataAccess.Base;
using Reddit.DataAccess.Repositories.Interfaces;
using Reddit.Domain.Database;
using Reddit.Domain.Entities;

namespace Reddit.DataAccess.Repositories;
public class MemberRepository : BaseRepository<Member>, IMemberRepository
{
    public MemberRepository(RedditDbContext dbContext) : base(dbContext)
    {
    }
}
