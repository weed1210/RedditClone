using Microsoft.EntityFrameworkCore;
using Reddit.DataAccess.Abstractions.Interfaces;
using Reddit.DataAccess.Repositories;
using Reddit.Domain.Database;
using Reddit.Domain.Entities;

namespace Reddit.DataAccess.Abstractions;
public class PostRepository(RedditDbContext dbContext) : BaseRepository<Post>(dbContext), IPostRepository
{
    public override IQueryable<Post> Get()
    {
        return base.Get()
            .Include(x => x.Member);
    }
}