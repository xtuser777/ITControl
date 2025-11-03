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
            new Page { Name = "users", DisplayName = "Usuários" },
            new Page { Name = "roles", DisplayName = "Perfis" },
            new Page { Name = "pages", DisplayName = "Páginas" },
            new Page { Name = "positions", DisplayName = "Cargos" },
            new Page { Name = "departments", DisplayName = "Secretarias" },
            new Page { Name = "divisions", DisplayName = "Divisões" },
            new Page { Name = "units", DisplayName = "Unidades" },
            new Page { Name = "contracts", DisplayName = "Contratos" },
            new Page { Name = "equipments", DisplayName = "Equipamentos" },
            new Page { Name = "systems", DisplayName = "Systemas" },
            new Page { Name = "calls", DisplayName = "Chamados" },
            new Page { Name = "appointments", DisplayName = "Agendamentos" },
            new Page { Name = "treatments", DisplayName = "Atendimentos" },
            new Page { Name = "notifications", DisplayName = "Notificações" },
            new Page { Name = "knowledge-bases", DisplayName = "Bases de Conhecimento" },
            new Page { Name = "profile", DisplayName = "Perfil do Usuário" },
            new Page { Name = "supplements", DisplayName = "Suplementos" },
            new Page { Name = "supplements-movements", DisplayName = "Movimentos de Suplementos" }
        ];
        _roles = [
            new Role(new() { Name = "Master", Active = true })
        ];
        _rolesPages = _pages.Select(p => new RolePage(
            _roles[0].Id, p.Id)).ToList();
        _positions = [
            new Position { Name = "Analista de Sistemas" }
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
            new Department
            {
                Alias = "SEMAD",
                Name = "Secretaria Municipal de Administração",
            },
            new Department
            {
                Alias = "SEGOV",
                Name = "Secretaria Municipal de Governo",
            },
            new Department
            {
                Alias = "SEPLAD",
                Name = "Secretaria Municipal de Planejamento e Desenvolvimento Econômico",
            },
            new Department
            {
                Alias = "SEDUC",
                Name = "Secretaria Municipal de Educação",
            },
            new Department
            {
                Alias = "SEMSA",
                Name = "Secretaria Municipal de Saúde",
            },
            new Department
            {
                Alias = "SEMAG",
                Name = "Secretaria Municipal de Serviços Gerais",
            },
            new Department
            {
                Alias = "SECULT",
                Name = "Secretaria Municipal de Cultura e Turismo",
            },
            new Department
            {
                Alias = "SEACT",
                Name = "Secretaria Municipal de Assistência Social e Cidadania",
            },
            new Department
            {
                Alias = "SEMEL",
                Name = "Secretaria Municipal de Esporte e Lazer",
            },
            new Department
            {
                Alias = "SEFAZ",
                Name = "Secretaria Municipal de Finanças",
            },
            new Department
            {
                Alias = "SEMAJ",
                Name = "Secretaria Municipal de Assuntos Jurídicos",
            },
            new Department
            {
                Alias = "SEMAM",
                Name = "Secretaria Municipal de Agricultura e Meio ambiente",
            },
            new Department
            {
                Alias = "SMSP",
                Name = "Secretaria Municipal de Segurança Pública",
            },
            new Department
            {
                Alias = "SOURB",
                Name = "Secretaria Municipal de Infraestrutura",
            },
            new Department
            {
                Alias = "COINTER",
                Name = "Controladoria Interna",
            },
            new Department
            {
                Alias = "GABINETE",
                Name = "Gabinete do Prefeito",
            },
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