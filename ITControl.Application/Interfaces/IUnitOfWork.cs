using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace ITControl.Application.Interfaces;

public interface IUnitOfWork
{
    ApplicationDbContext Context { get; }
    IDbContextTransaction BeginTransaction { get; }
    IPositionsRepository PositionsRepository { get; }
    IPagesRepository PagesRepository { get; }
    Task Commit(IDbContextTransaction transaction);
    void Dispose();
}