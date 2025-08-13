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
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(
            "Server=localhost,1433;Database=ITControl;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;"
            )
        );

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
        services.AddScoped<ILocationsRepository, LocationsRepository>();
        services.AddScoped<ILocationsService, LocationsService>();
        services.AddScoped<ILocationsView, LocationsView>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
