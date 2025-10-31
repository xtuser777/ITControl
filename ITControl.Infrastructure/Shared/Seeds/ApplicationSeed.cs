using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Positions.Entities;
using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Shared.Utils;
using ITControl.Domain.Units.Entities;
using ITControl.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ITControl.Infrastructure.Shared.Seeds;

public class ApplicationSeed
{
    private List<Page> _pages;
    private List<Role> _roles;
    private List<RolePage> _rolesPages;
    private List<Unit> _units;
    private List<User> _users;
    private List<Position> _positions;
    private List<Department> _departments;
    private List<Division> _divisions;

    public ApplicationSeed(IConfiguration configuration)
    {
        _pages = [
            new () { Name = "users", DisplayName = "Usuários" },
            new () { Name = "roles", DisplayName = "Perfis" },
            new () { Name = "pages", DisplayName = "Páginas" },
            new () { Name = "positions", DisplayName = "Cargos" },
            new () { Name = "departments", DisplayName = "Secretarias" },
            new () { Name = "divisions", DisplayName = "Divisões" },
            new () { Name = "units", DisplayName = "Unidades" },
            new () { Name = "contracts", DisplayName = "Contratos" },
            new () { Name = "equipments", DisplayName = "Equipamentos" },
            new () { Name = "systems", DisplayName = "Systemas" },
            new () { Name = "calls", DisplayName = "Chamados" },
            new () { Name = "appointments", DisplayName = "Agendamentos" },
            new () { Name = "treatments", DisplayName = "Atendimentos" },
            new () { Name = "notifications", DisplayName = "Notificações" },
            new () { Name = "knowledge-bases", DisplayName = "Bases de Conhecimento" },
            new () { Name = "profile", DisplayName = "Perfil do Usuário" },
            new () { Name = "supplements", DisplayName = "Suplementos" },
            new () { Name = "supplements-movements", DisplayName = "Movimentos de Suplementos" }
        ];
        _roles = [
            new Role(new() { Name = "Master", Active = true })
        ];
        _rolesPages = _pages.Select(p => new RolePage(
            _roles[0].Id, p.Id)).ToList();
        _positions = [
            new(new() { Name = "Analista de Sistemas" })
        ];
        _units = [
            new(new()
            {
                Name = "Paço Municipal",
                StreetName = "Rua Marcílio Dias",
                AddressNumber = "719",
                Neighborhood = "Centro",
                PostalCode = "19600000",
                Phone = "1832659200"
            })
        ];
        _departments = [
            new(new()
            {
                Alias = "SEMAD",
                Name = "Secretaria Municipal de Administração",
            }),
            new(new()
            {
                Alias = "SEGOV",
                Name = "Secretaria Municipal de Governo",
            }),
            new(new()
            {
                Alias = "SEPLAD",
                Name = "Secretaria Municipal de Planejamento e Desenvolvimento Econômico",
            }),
            new(new()
            {
                Alias = "SEDUC",
                Name = "Secretaria Municipal de Educação",
            }),
            new(new()
            {
                Alias = "SEMSA",
                Name = "Secretaria Municipal de Saúde",
            }),
            new(new()
            {
                Alias = "SEMAG",
                Name = "Secretaria Municipal de Serviços Gerais",
            }),
            new(new()
            {
                Alias = "SECULT",
                Name = "Secretaria Municipal de Cultura e Turismo",
            }),
            new(new()
            {
                Alias = "SEACT",
                Name = "Secretaria Municipal de Assistência Social e Cidadania",
            }),
            new(new()
            {
                Alias = "SEMEL",
                Name = "Secretaria Municipal de Esporte e Lazer",
            }),
            new(new()
            {
                Alias = "SEFAZ",
                Name = "Secretaria Municipal de Finanças",
            }),
            new(new()
            {
                Alias = "SEMAJ",
                Name = "Secretaria Municipal de Assuntos Jurídicos",
            }),
            new(new()
            {
                Alias = "SEMAM",
                Name = "Secretaria Municipal de Agricultura e Meio ambiente",
            }),
            new(new()
            {
                Alias = "SMSP",
                Name = "Secretaria Municipal de Segurança Pública",
            }),
            new(new()
            {
                Alias = "SOURB",
                Name = "Secretaria Municipal de Infraestrutura",
            }),
            new(new()
            {
                Alias = "COINTER",
                Name = "Controladoria Interna",
            }),
            new(new()
            {
                Alias = "GABINETE",
                Name = "Gabinete do Prefeito",
            }),
        ];
        _divisions = [
            new(new()
            {
                Name = "Divisão Municipal de Informática",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMAD")?.Id
                               ?? Guid.Empty
            })
        ];
        _users = [
            new(new()
            {
                Name = "Informática",
                Username = configuration["InfoUser:Username"] ?? "",
                Password = Crypt.HashPassword(configuration["InfoUser:Password"] ?? ""),
                Document = "02912383005",
                Email = configuration["InfoUser:Email"] ?? "",
                Enrollment = 9999,
                RoleId = _roles[0].Id,
                PositionId = _positions[0].Id,
                UnitId = _units[0].Id,
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMAD")?.Id
                               ?? Guid.Empty,
                DivisionId = _divisions[0].Id,
            })
        ];
    }
    
    public void Seed(DbContext context)
    {
        if (!context.Set<Page>().Any())
        {
            context.Set<Page>().AddRange(_pages);
        }

        if (!context.Set<Role>().Any())
        {
            context.Set<Role>().AddRange(_roles);
        }

        if (!context.Set<RolePage>().Any())
        {
            context.Set<RolePage>().AddRange(_rolesPages);
        }

        if (!context.Set<Position>().Any())
        {
            context.Set<Position>().AddRange(_positions);
        }

        if (!context.Set<Unit>().Any())
        {
            context.Set<Unit>().AddRange(_units);
        }

        if (!context.Set<Department>().Any())
        {
            context.Set<Department>().AddRange(_departments);
        }

        if (!context.Set<Division>().Any())
        {
            context.Set<Division>().AddRange(_divisions);
        }

        if (!context.Set<User>().Any())
        {
            context.Set<User>().AddRange(_users);
        }
        context.SaveChanges();
    }
    
    public async Task SeedAsync(DbContext context, CancellationToken cancellationToken)
    {
        if (!await context.Set<Page>().AnyAsync(cancellationToken))
        {
            context.Set<Page>().AddRange(_pages);
        }

        if (!await context.Set<Role>().AnyAsync(cancellationToken))
        {
            context.Set<Role>().AddRange(_roles);
        }

        if (!await context.Set<RolePage>().AnyAsync(cancellationToken))
        {
            context.Set<RolePage>().AddRange(_rolesPages);
        }

        if (!await context.Set<Position>().AnyAsync(cancellationToken))
        {
            context.Set<Position>().AddRange(_positions);
        }

        if (!await context.Set<Unit>().AnyAsync(cancellationToken))
        {
            context.Set<Unit>().AddRange(_units);
        }

        if (!await context.Set<Department>().AnyAsync(cancellationToken))
        {
            context.Set<Department>().AddRange(_departments);
        }

        if (!await context.Set<Division>().AnyAsync(cancellationToken))
        {
            context.Set<Division>().AddRange(_divisions);
        }

        if (!await context.Set<User>().AnyAsync(cancellationToken))
        {
            context.Set<User>().AddRange(_users);
        }
        await context.SaveChangesAsync(cancellationToken);
    }
}