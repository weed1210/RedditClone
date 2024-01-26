using Microsoft.EntityFrameworkCore.Storage;
using Reddit.DataAccess.Repositories;
using Reddit.DataAccess.Repositories.Interfaces;
using Reddit.Domain.Database;

namespace Reddit.DataAccess.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly RedditDbContext _dbContext;
    private IDbContextTransaction? _transaction;
    private IMemberRepository? _member;
    private IPostRepository? _post;
    private IStaffRepository? _staff;
    private IUserRepository? _user;

    public UnitOfWork(RedditDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task StartTransactionAsync()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        if (_transaction == null)
        {
            throw new Exception("No active transaction");
        }

        await _transaction.CommitAsync();
    }

    public async Task RollbackAsync()
    {
        if (_transaction == null)
        {
            throw new Exception("No active transaction");
        }

        await _transaction.RollbackAsync();
    }

    public IMemberRepository Member
    {
        get
        {
            return _member ??= new MemberRepository(_dbContext);
        }
    }

    public IPostRepository Post
    {
        get
        {
            return _post ??= new PostRepository(_dbContext);
        }
    }

    public IStaffRepository Staff
    {
        get
        {
            return _staff ??= new StaffRepository(_dbContext);
        }
    }

    public IUserRepository User
    {
        get
        {
            return _user ??= new UserRepository(_dbContext);
        }
    }
}
