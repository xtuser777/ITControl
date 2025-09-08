using ITControl.Application.Shared.Interfaces;
using ITControl.Domain.Appointments.Interfaces;
using ITControl.Domain.Calls.Interfaces;
using ITControl.Domain.Contracts.Interfaces;
using ITControl.Domain.Departments.Interfaces;
using ITControl.Domain.Divisions.Interfaces;
using ITControl.Domain.Equipments.Interfaces;
using ITControl.Domain.Locations.Interfaces;
using ITControl.Domain.Notifications.Interfaces;
using ITControl.Domain.Pages.Interfaces;
using ITControl.Domain.Positions.Interfaces;
using ITControl.Domain.Roles.Interfaces;
using ITControl.Domain.Systems.Interfaces;
using ITControl.Domain.Treatments.Interfaces;
using ITControl.Domain.Units.Interfaces;
using ITControl.Domain.Users.Interfaces;
using ITControl.Infrastructure.Appointments.Repositories;
using ITControl.Infrastructure.Calls.Repositories;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Contracts.Repositories;
using ITControl.Infrastructure.Departments.Repositories;
using ITControl.Infrastructure.Divisions.Repositories;
using ITControl.Infrastructure.Equipments.Repositories;
using ITControl.Infrastructure.Locations.Repositories;
using ITControl.Infrastructure.Notifications.Repositories;
using ITControl.Infrastructure.Pages.Repositories;
using ITControl.Infrastructure.Positions.Repositories;
using ITControl.Infrastructure.Roles.Repositories;
using ITControl.Infrastructure.Systems.Repositories;
using ITControl.Infrastructure.Treatments.Repositories;
using ITControl.Infrastructure.Units.Repositories;
using ITControl.Infrastructure.Users.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

namespace ITControl.Application.Shared.Services;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private IPositionsRepository? _positionsRepository;
    private IPagesRepository? _pagesRepository;
    private IRolesRepository? _rolesRepository;
    private IRolesPagesRepository? _rolesPagesRepository;
    private IUsersRepository? _usersRepository;
    private IUsersEquipmentsRepository? _usersEquipmentsRepository;
    private IUsersSystemsRepository? _usersSystemsRepository;
    private IDepartmentsRepository? _departmentsRepository;
    private IDivisionsRepository? _divisionsRepository;
    private IUnitsRepository? _unitsRepository;
    private ILocationsRepository? _locationsRepository;
    private IContractsRepository? _contractsRepository;
    private IContractsContactsRepository? _contractsContactsRepository;
    private ISystemsRepository? _systemsRepository;
    private IEquipmentsRepository? _equipmentsRepository;
    private ICallsRepository? _callsRepository;
    private ICallsStatusesRepository? _callsStatusesRepository;
    private ITreatmentsRepository? _treatmentsRepository;
    private IAppointmentsRepository? _appointmentsRepository;
    private INotificationsRepository? _notificationsRepository;

    public ApplicationDbContext Context => context;
    public IDbContextTransaction BeginTransaction => context.Database.BeginTransaction();
    public IPositionsRepository PositionsRepository => _positionsRepository ?? new PositionsRepository(context);
    public IPagesRepository PagesRepository => _pagesRepository ?? new PagesRepository(context);
    public IRolesRepository RolesRepository => _rolesRepository ?? new RolesRepository(context);
    public IRolesPagesRepository RolesPagesRepository => _rolesPagesRepository ?? new RolesPagesRepository(context);
    public IUsersRepository UsersRepository => _usersRepository ?? new UsersRepository(context);
    public IUsersEquipmentsRepository UsersEquipmentsRepository => _usersEquipmentsRepository ?? new UsersEquipmentsRepository(context);
    public IUsersSystemsRepository UsersSystemsRepository => _usersSystemsRepository ?? new UsersSystemsRepository(context);
    public IDepartmentsRepository DepartmentsRepository => _departmentsRepository ?? new DepartmentsRepository(context);
    public IDivisionsRepository DivisionsRepository => _divisionsRepository ?? new DivisionsRepository(context);
    public IUnitsRepository UnitsRepository => _unitsRepository ?? new UnitsRepository(context);
    public ILocationsRepository LocationsRepository => _locationsRepository ?? new LocationsRepository(context);
    public IContractsRepository ContractsRepository => _contractsRepository ?? new ContractsRepository(context);
    public IContractsContactsRepository ContractsContactsRepository => _contractsContactsRepository ?? new ContractsContactsRepository(context);
    public ISystemsRepository SystemsRepository => _systemsRepository ?? new SystemsRepository(context);
    public IEquipmentsRepository EquipmentsRepository => _equipmentsRepository ?? new EquipmentsRepository(context);
    public ICallsRepository CallsRepository => _callsRepository ?? new CallsRepository(context);
    public ICallsStatusesRepository CallsStatusesRepository => _callsStatusesRepository ?? new CallsStatusesRepository(context);
    public ITreatmentsRepository TreatmentsRepository => _treatmentsRepository ?? new TreatmentsRepository(context);
    public IAppointmentsRepository AppointmentsRepository => _appointmentsRepository ?? new AppointmentsRepository(context);
    public INotificationsRepository NotificationsRepository => _notificationsRepository ?? new NotificationsRepository(context);

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