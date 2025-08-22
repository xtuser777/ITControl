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
    IRolesRepository RolesRepository { get; }
    IRolesPagesRepository RolesPagesRepository { get; }
    IUsersRepository UsersRepository { get; }   
    IUsersEquipmentsRepository UsersEquipmentsRepository { get; }   
    IUsersSystemsRepository UsersSystemsRepository { get; }   
    IDepartmentsRepository DepartmentsRepository { get; }
    IDivisionsRepository DivisionsRepository { get; }
    IUnitsRepository UnitsRepository { get; }
    ILocationsRepository LocationsRepository { get; }
    IContractsRepository ContractsRepository { get; }
    IContractsContactsRepository ContractsContactsRepository { get; }
    ISystemsRepository SystemsRepository { get; }
    IEquipmentsRepository EquipmentsRepository { get; }
    ICallsRepository CallsRepository { get; }
    ICallsStatusesRepository CallsStatusesRepository { get; }
    ITreatmentsRepository TreatmentsRepository { get; }
    IAppointmentsRepository AppointmentsRepository { get; }
    Task Commit(IDbContextTransaction transaction);
    void Dispose();
}