using Reddit.DataAccess.Abstractions.Interfaces;
using Reddit.Domain.Database;
using Reddit.Domain.Entities;
using Reddit.DataAccess.Repositories;

namespace Reddit.DataAccess.Abstractions;
public class MemberRepository : BaseRepository<Member>, IMemberRepository
{
    public MemberRepository(RedditDbContext dbContext) : base(dbContext)
    {
    }
}
