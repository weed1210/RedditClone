using Microsoft.EntityFrameworkCore;
using Reddit.DataAccess.Abstractions.Interfaces;
using Reddit.Domain.Database;
using Reddit.Domain.Entities;
using Reddit.DataAccess.Repositories;

namespace Reddit.DataAccess.Abstractions;
public class PostRepository : BaseRepository<Post>, IPostRepository
{
    public PostRepository(RedditDbContext dbContext) : base(dbContext)
    {
    }

    public override IQueryable<Post> Get()
    {
        return base.Get()
            .Include(x => x.Member);
    }
}