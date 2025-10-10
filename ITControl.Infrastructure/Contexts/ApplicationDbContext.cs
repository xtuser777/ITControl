using ITControl.Domain.Appointments.Entities;
using ITControl.Domain.Calls.Entities;
using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Equipments.Entities;
using ITControl.Domain.KnowledgeBases.Entities;
using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Positions.Entities;
using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Supplements.Entities;
using ITControl.Domain.SupplementsMovements.Entities;
using ITControl.Domain.Treatments.Entities;
using ITControl.Domain.Units.Entities;
using ITControl.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): DbContext(options)
{
    public DbSet<Position> Positions { get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePage> RolesPages { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Division> Divisions { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<ContractContact> ContractContacts { get; set; }
    public DbSet<Domain.Systems.Entities.System> Systems { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<UserEquipment> UsersEquipments { get; set; }
    public DbSet<UserSystem> UsersSystems { get; set; }
    public DbSet<Call> Calls { get; set; }
    public DbSet<CallStatus> CallsStatuses { get; set; }
    public DbSet<Treatment> Treatments { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Supplement> Supplements { get; set; }
    public DbSet<SupplementMovement> SupplementsMovements { get; set; }
    public DbSet<KnowledgeBase> KnowledgeBases { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext)
            .Assembly);
    }
}