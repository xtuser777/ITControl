using ITControl.Domain.Entities;
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
    public DbSet<Location> Locations { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<ContractContact> ContractContacts { get; set; }
    public DbSet<Domain.Entities.System> Systems { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<UserEquipment> UsersEquipments { get; set; }
    public DbSet<UserSystem> UsersSystems { get; set; }
    public DbSet<Call> Calls { get; set; }
    public DbSet<CallStatus> CallsStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext)
            .Assembly);
    }
}