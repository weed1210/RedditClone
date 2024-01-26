using Reddit.DataAccess.Base;
using Reddit.DataAccess.Repositories.Interfaces;
using Reddit.Domain.Database;
using Reddit.Domain.Entities;

namespace Reddit.DataAccess.Repositories;
public class StaffRepository : BaseRepository<Staff>, IStaffRepository
{
    public StaffRepository(RedditDbContext dbContext) : base(dbContext)
    {
    }
}
