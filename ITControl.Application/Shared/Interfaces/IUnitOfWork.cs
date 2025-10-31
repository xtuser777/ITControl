using ITControl.Domain.Appointments.Interfaces;
using ITControl.Domain.Calls.Interfaces;
using ITControl.Domain.Contracts.Interfaces;
using ITControl.Domain.Departments.Interfaces;
using ITControl.Domain.Divisions.Interfaces;
using ITControl.Domain.Equipments.Interfaces;
using ITControl.Domain.KnowledgeBases.Interfaces;
using ITControl.Domain.Notifications.Interfaces;
using ITControl.Domain.Pages.Interfaces;
using ITControl.Domain.Positions.Interfaces;
using ITControl.Domain.Roles.Interfaces;
using ITControl.Domain.Supplements.Interfaces;
using ITControl.Domain.SupplementsMovements.Interfaces;
using ITControl.Domain.Systems.Interfaces;
using ITControl.Domain.Treatments.Interfaces;
using ITControl.Domain.Units.Interfaces;
using ITControl.Domain.Users.Interfaces;
using ITControl.Infrastructure.Shared.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace ITControl.Application.Shared.Interfaces;

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
    IContractsRepository ContractsRepository { get; }
    IContractsContactsRepository ContractsContactsRepository { get; }
    ISystemsRepository SystemsRepository { get; }
    IEquipmentsRepository EquipmentsRepository { get; }
    ICallsRepository CallsRepository { get; }
    ICallsStatusesRepository CallsStatusesRepository { get; }
    ITreatmentsRepository TreatmentsRepository { get; }
    IAppointmentsRepository AppointmentsRepository { get; }
    INotificationsRepository NotificationsRepository { get; }
    ISupplementsRepository SupplementsRepository { get; }
    ISupplementsMovementsRepository SupplementsMovementsRepository { get; }
    IKnowledgeBasesRepository KnowledgeBasesRepository { get; }
    Task Commit(IDbContextTransaction transaction);
    void Dispose();
}