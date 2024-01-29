using Microsoft.EntityFrameworkCore;
using Reddit.DataAccess.Base;
using Reddit.DataAccess.Repositories.Interfaces;
using Reddit.Domain.Database;
using Reddit.Domain.Entities;

namespace Reddit.DataAccess.Repositories;
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