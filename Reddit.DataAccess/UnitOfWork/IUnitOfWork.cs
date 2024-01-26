using Reddit.DataAccess.Repositories.Interfaces;

namespace Reddit.DataAccess.UnitOfWork;
public interface IUnitOfWork
{
    IMemberRepository Member { get; }
    IPostRepository Post { get; }
    IStaffRepository Staff { get; }
    IUserRepository User { get; }

    Task SaveAsync();
    Task StartTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
