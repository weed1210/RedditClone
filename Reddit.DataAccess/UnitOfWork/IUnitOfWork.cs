using Reddit.DataAccess.Abstractions.Interfaces;
using Reddit.DataAccess.Repositories.Abstractions;

namespace Reddit.DataAccess.UnitOfWork;
public interface IUnitOfWork
{
    IMemberRepository Members { get; }
    IPostRepository Posts { get; }
    IStaffRepository Staffs { get; }
    IUserRepository Users { get; }
    IUserRoleRepository UserRoles { get; }
    IRoleRepository Roles { get; }
    ITaskRepository Tasks { get; }

    Task SaveAsync();
    Task StartTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
