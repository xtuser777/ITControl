using ITControl.Application.Interfaces;
using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

namespace ITControl.Application.Services;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private IPositionsRepository? _positionsRepository;
    
    public ApplicationDbContext Context => context;
    public IDbContextTransaction BeginTransaction => context.Database.BeginTransaction();
    public IPositionsRepository PositionsRepository => _positionsRepository ?? new PositionsRepository(context);
    
    public async Task Commit(IDbContextTransaction transaction)
    {
        await context.SaveChangesAsync();
        await transaction.CommitAsync();

    }

    public void Dispose()
    {
        context.Dispose();
    }
}