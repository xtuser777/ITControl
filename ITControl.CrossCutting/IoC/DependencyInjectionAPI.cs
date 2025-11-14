using ITControl.Application.Appointments.Interfaces;
using ITControl.Application.Appointments.Services;
using ITControl.Application.Auth.Interfaces;
using ITControl.Application.Auth.Services;
using ITControl.Application.Calls.Interfaces;
using ITControl.Application.Calls.Services;
using ITControl.Application.Contracts.Interfaces;
using ITControl.Application.Contracts.Services;
using ITControl.Application.Departments.Interfaces;
using ITControl.Application.Departments.Services;
using ITControl.Application.Divisions.Interfaces;
using ITControl.Application.Divisions.Services;
using ITControl.Application.Equipments.Interfaces;
using ITControl.Application.Equipments.Services;
using ITControl.Application.KnowledgeBases.Interfaces;
using ITControl.Application.KnowledgeBases.Services;
using ITControl.Application.Notifications.Interfaces;
using ITControl.Application.Notifications.Services;
using ITControl.Application.Pages.Interfaces;
using ITControl.Application.Pages.Services;
using ITControl.Application.Positions.Interfaces;
using ITControl.Application.Positions.Services;
using ITControl.Application.Roles.Interfaces;
using ITControl.Application.Roles.Services;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Services;
using ITControl.Application.Supplements.Interfaces;
using ITControl.Application.Supplements.Services;
using ITControl.Application.SupplementsMovements.Interfaces;
using ITControl.Application.SupplementsMovements.Services;
using ITControl.Application.Systems.Interfaces;
using ITControl.Application.Systems.Services;
using ITControl.Application.Treatments.Interfaces;
using ITControl.Application.Treatments.Services;
using ITControl.Application.Units.Interfaces;
using ITControl.Application.Units.Services;
using ITControl.Application.Users.Interfaces;
using ITControl.Application.Users.Services;
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
using ITControl.Infrastructure.Appointments.Repositories;
using ITControl.Infrastructure.Calls.Repositories;
using ITControl.Infrastructure.Contracts.Repositories;
using ITControl.Infrastructure.Departments.Repositories;
using ITControl.Infrastructure.Divisions.Repositories;
using ITControl.Infrastructure.Equipments.Repositories;
using ITControl.Infrastructure.KnowledgeBases.Repositories;
using ITControl.Infrastructure.Notifications.Repositories;
using ITControl.Infrastructure.Pages.Repositories;
using ITControl.Infrastructure.Positions.Repositories;
using ITControl.Infrastructure.Roles.Repositories;
using ITControl.Infrastructure.Shared.Contexts;
using ITControl.Infrastructure.Shared.Seeds;
using ITControl.Infrastructure.Supplements.Repositories;
using ITControl.Infrastructure.SupplementsMovements.Repositories;
using ITControl.Infrastructure.Systems.Repositories;
using ITControl.Infrastructure.Treatments.Repositories;
using ITControl.Infrastructure.Units.Repositories;
using ITControl.Infrastructure.Users.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITControl.CrossCutting.IoC;

public static class DependencyInjectionApi
{
    public static IServiceCollection AddInfrastructureApi(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>((options) =>
            {
                options
                    .UseSqlServer(connectionString)
                    .UseAsyncSeeding(async (context, _, cancellationToken) =>
                        await new ApplicationSeed(configuration)
                            .SeedAsync(context, cancellationToken))
                    .UseSeeding((context, _) =>
                        new ApplicationSeed(configuration).Seed(context));
            }
        );

        services.AddSingleton<IWebSocketService, WebSocketService>();

        services.AddSingleton<ICryptService, CryptService>();
        services.AddScoped<IPositionsRepository, PositionsRepository>();
        services.AddScoped<IPositionsService, PositionsService>();
        services.AddScoped<IPagesRepository, PagesRepository>();
        services.AddScoped<IPagesService, PagesService>();
        services.AddScoped<IRolesRepository, RolesRepository>();
        services.AddScoped<IRolesPagesRepository, RolesPagesRepository>();
        services.AddScoped<IRolesService, RolesService>();
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IUsersEquipmentsRepository, UsersEquipmentsRepository>();
        services.AddScoped<IUsersSystemsRepository, UsersSystemsRepository>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IDepartmentsRepository, DepartmentsRepository>();
        services.AddScoped<IDepartmentsService, DepartmentsService>();
        services.AddScoped<IDivisionsRepository, DivisionsRepository>();
        services.AddScoped<IDivisionsService, DivisionsService>();
        services.AddScoped<IUnitsRepository, UnitsRepository>();
        services.AddScoped<IUnitsService, UnitsService>();
        services.AddScoped<IContractsRepository, ContractsRepository>();
        services.AddScoped<IContractsContactsRepository, ContractsContactsRepository>();
        services.AddScoped<IContractsService, ContractsService>();
        services.AddScoped<ISystemsRepository, SystemsRepository>();
        services.AddScoped<ISystemsService, SystemsService>();
        services.AddScoped<IEquipmentsRepository, EquipmentsRepository>();
        services.AddScoped<IEquipmentsService, EquipmentsService>();
        services.AddScoped<ICallsRepository, CallsRepository>();
        services.AddScoped<ICallsStatusesRepository, CallsStatusesRepository>();
        services.AddScoped<ICallsService, CallsService>();
        services.AddScoped<ITreatmentsRepository, TreatmentsRepository>();
        services.AddScoped<ITreatmentsService, TreatmentsService>();
        services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
        services.AddScoped<IAppointmentsService, AppointmentsService>();
        services.AddScoped<INotificationsRepository, NotificationsRepository>();
        services.AddScoped<INotificationsService, NotificationsService>();
        services.AddScoped<ISupplementsRepository, SupplementsRepository>();
        services.AddScoped<ISupplementsService, SupplementsService>();
        services.AddScoped<ISupplementsMovementsRepository, SupplementsMovementsRepository>();
        services.AddScoped<ISupplementsMovementsService, SupplementsMovementsService>();
        services.AddScoped<IKnowledgeBasesRepository, KnowledgeBasesRepository>();
        services.AddScoped<IKnowledgeBasesService, KnowledgeBasesService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
