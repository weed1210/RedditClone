using Reddit.DataAccess.Abstractions.Interfaces;
using Reddit.DataAccess.Repositories;
using Reddit.Domain.Database;
using Reddit.Domain.Entities;

namespace Reddit.DataAccess.Abstractions;
public class MemberRepository(RedditDbContext dbContext) : BaseRepository<Member>(dbContext), IMemberRepository
{
}
