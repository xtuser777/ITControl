using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ITControl.Application.Interfaces;
using ITControl.Application.Services;
using ITControl.Application.Views;
using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Repositories;

namespace ITControl.CrossCutting.IoC;

public static class DependencyInjectionApi
{
    public static IServiceCollection AddInfrastructureApi(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(connectionString)
        );

        services.AddSingleton<IWebSocketService, WebSocketService>();

        services.AddScoped<IPositionsRepository, PositionsRepository>();
        services.AddScoped<IPositionsService, PositionsService>();
        services.AddScoped<IPositionsView, PositionsView>();
        services.AddScoped<IPagesRepository, PagesRepository>();
        services.AddScoped<IPagesService, PagesService>();
        services.AddScoped<IPagesView, PagesView>();
        services.AddScoped<IRolesRepository, RolesRepository>();
        services.AddScoped<IRolesPagesRepository, RolesPagesRepository>();
        services.AddScoped<IRolesService, RolesService>();
        services.AddScoped<IRolesView, RolesView>();
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IUsersEquipmentsRepository, UsersEquipmentsRepository>();
        services.AddScoped<IUsersSystemsRepository, UsersSystemsRepository>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IUsersView, UsersView>();
        services.AddScoped<IDepartmentsRepository, DepartmentsRepository>();
        services.AddScoped<IDepartmentsService, DepartmentsService>();
        services.AddScoped<IDepartmentsView, DepartmentsView>();
        services.AddScoped<IDivisionsRepository, DivisionsRepository>();
        services.AddScoped<IDivisionsService, DivisionsService>();
        services.AddScoped<IDivisionsView, DivisionsView>();
        services.AddScoped<IUnitsRepository, UnitsRepository>();
        services.AddScoped<IUnitsService, UnitsService>();
        services.AddScoped<IUnitsView, UnitsView>();
        services.AddScoped<IContractsRepository, ContractsRepository>();
        services.AddScoped<IContractsContactsRepository, ContractsContactsRepository>();
        services.AddScoped<IContractsService, ContractsService>();
        services.AddScoped<IContractsView, ContractsView>();
        services.AddScoped<ISystemsRepository, SystemsRepository>();
        services.AddScoped<ISystemsService, SystemsService>();
        services.AddScoped<ISystemsView, SystemsView>();
        services.AddScoped<ILocationsRepository, LocationsRepository>();
        services.AddScoped<ILocationsService, LocationsService>();
        services.AddScoped<ILocationsView, LocationsView>();
        services.AddScoped<IEquipmentsRepository, EquipmentsRepository>();
        services.AddScoped<IEquipmentsService, EquipmentsService>();
        services.AddScoped<IEquipmentsView, EquipmentsView>();
        services.AddScoped<IEquipmentsTypesView, EquipmentsTypesView>();
        services.AddScoped<ICallsRepository, CallsRepository>();
        services.AddScoped<ICallsStatusesRepository, CallsStatusesRepository>();
        services.AddScoped<ICallsService, CallsService>();
        services.AddScoped<ICallsView, CallsView>();
        services.AddScoped<ICallsStatusesView, CallsStatusesView>();
        services.AddScoped<ICallsReasonsView, CallsReasonsView>();
        services.AddScoped<ITreatmentsRepository, TreatmentsRepository>();
        services.AddScoped<ITreatmentsService, TreatmentsService>();
        services.AddScoped<ITreatmentsView, TreatmentsView>();
        services.AddScoped<ITreatmentsStatusesView, TreatmentsStatusesView>();
        services.AddScoped<ITreatmentsTypesView, TreatmentsTypesView>();
        services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
        services.AddScoped<IAppointmentsService, AppointmentsService>();
        services.AddScoped<IAppointmentsView, AppointmentsView>();
        services.AddScoped<INotificationsRepository, NotificationsRepository>();
        services.AddScoped<INotificationsService, NotificationsService>();
        services.AddScoped<INotificationsView, NotificationsView>();
        services.AddScoped<INotificationsTypesView, NotificationsTypesView>();
        services.AddScoped<INotificationsReferencesView, NotificationsReferencesView>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
