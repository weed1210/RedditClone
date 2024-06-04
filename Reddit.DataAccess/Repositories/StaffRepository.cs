using Reddit.DataAccess.Abstractions.Interfaces;
using Reddit.Domain.Database;
using Reddit.Domain.Entities;
using Reddit.DataAccess.Repositories;

namespace Reddit.DataAccess.Abstractions;
public class StaffRepository : BaseRepository<Staff>, IStaffRepository
{
    public StaffRepository(RedditDbContext dbContext) : base(dbContext)
    {
    }
}
