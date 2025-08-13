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
    private IPagesRepository? _pagesRepository;
    private IRolesRepository? _rolesRepository;
    private IRolesPagesRepository? _rolesPagesRepository;
    private IUsersRepository? _usersRepository;
    private IDepartmentsRepository? _departmentsRepository;
    private IDivisionsRepository? _divisionsRepository;
    private IUnitsRepository? _unitsRepository;
    private ILocationsRepository? _locationsRepository;
    
    public ApplicationDbContext Context => context;
    public IDbContextTransaction BeginTransaction => context.Database.BeginTransaction();
    public IPositionsRepository PositionsRepository => _positionsRepository ?? new PositionsRepository(context);
    public IPagesRepository PagesRepository => _pagesRepository ?? new PagesRepository(context);
    public IRolesRepository RolesRepository => _rolesRepository ?? new RolesRepository(context);
    public IRolesPagesRepository RolesPagesRepository => _rolesPagesRepository ?? new RolesPagesRepository(context);
    public IUsersRepository UsersRepository => _usersRepository ?? new UsersRepository(context);
    public IDepartmentsRepository DepartmentsRepository => _departmentsRepository ?? new DepartmentsRepository(context);
    public IDivisionsRepository DivisionsRepository => _divisionsRepository ?? new DivisionsRepository(context);
    public IUnitsRepository UnitsRepository => _unitsRepository ?? new UnitsRepository(context);
    public ILocationsRepository LocationsRepository => _locationsRepository ?? new LocationsRepository(context);
    
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