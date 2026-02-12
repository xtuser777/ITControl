using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Positions.Entities;
using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Units.Entities;
using ITControl.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ITControl.Infrastructure.Shared.Seeds;

public class ApplicationSeed
{
    private readonly List<Page> _pages;
    private readonly List<Role> _roles;
    private readonly List<RolePage> _rolesPages;
    private readonly List<Unit> _units;
    private readonly List<User> _users;
    private readonly List<Position> _positions;
    private readonly List<Department> _departments;
    private readonly List<Division> _divisions;

    public ApplicationSeed(
        IConfiguration configuration)
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
            new Page { Name = "systems", DisplayName = "Sistemas" },
            new Page { Name = "calls", DisplayName = "Chamados" },
            new Page { Name = "appointments", DisplayName = "Agendamentos" },
            new Page { Name = "treatments", DisplayName = "Atendimentos" },
            new Page { Name = "notifications", DisplayName = "Notificações" },
            new Page { Name = "knowledge-bases", DisplayName = "Bases de Conhecimento" },
            new Page { Name = "profile", DisplayName = "Perfil do Usuário" },
            new Page { Name = "supplies", DisplayName = "Suprimentos" },
            new Page { Name = "supplies-movements", DisplayName = "Movimentos de Suprimentos" }
        ];
        _roles = [
            new Role(new() { Name = "Master", Active = true })
        ];
        _rolesPages = [.. _pages.Select(p => new RolePage(
            _roles[0].Id, p.Id))];
        _positions = [
            new Position { Name = "Analista de Sistemas" },
            new Position { Name = "Técnico de TI" },
            new Position { Name = "Monitor(a) de Informática" },
            new Position { Name = "Auxiliar Administrativo" },
            new Position { Name = "Secretário(a)" },
            new Position { Name = "Subsecretário(a)" },
            new Position { Name = "Coordenador(a)" },
            new Position { Name = "Estagiário(a)" },
            new Position { Name = "Emfermeiro(a)" },
            new Position { Name = "Médico(a)" },
            new Position { Name = "Dentista" },
            new Position { Name = "ACS" },
            new Position { Name = "Serviços Gerais" },
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
            new Department
            {
                Alias = "OUVIDORIA",
                Name = "Ouvidoria Geral do Município",
            },
            new Department
            {
                Alias = "CONSELHOS",
                Name = "Conselhos Municipais",
            },
        ];
        _divisions = [
            new(new()
            {
                Name = "Divisão de Tecnologia da Informação",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMAD")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Patrimônio e Arquivo Público",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMAD")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Recursos Humanos",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMAD")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Almoxarifado",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMAD")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Imprensa e Comunicação Oficial",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEGOV")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Convênios",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEPLAD")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Desenvolvimento Econômico",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEPLAD")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Alimentação Escolar",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEDUC")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão Administrativa de Educação",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEDUC")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Educação Infantil",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEDUC")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Educação Especial",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEDUC")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Ensino Fundamental",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEDUC")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Transporte Escolar",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEDUC")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Formação",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEDUC")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Controle de Vetores",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMSA")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão Administrativa de Saúde",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMSA")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Enfermagem",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMSA")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Enfermagem ESFs",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMSA")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de ESF",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMSA")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Saúde Bucal",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMSA")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão Técnica da Saúde",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMSA")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Vigilância Sanitária",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMSA")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Vigilância Epidemiológica",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMSA")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Farmácia",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMSA")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Transporte Sanitário",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMSA")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Saúde Mental",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMSA")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Manutenção de Vias Públicas e Estradas",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMAG")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Transportes e Manutenção de Frotas",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMAG")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Limpeza Pública, Manutenção e Limpeza do Balneário",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMAG")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão dos Distritos de Ajicê e Gardênia",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMAG")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Cultura",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SECULT")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Turismo",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SECULT")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Assistência Social",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEACT")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Vigilância Socioassistencial, Cadastro Único e Bolsa Família",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEACT")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Proteção Social Básica - CRAS",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEACT")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Proteção Social Especial - CREAS",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEACT")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Esportes e Lazer",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMEL")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Arrecadação",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEFAZ")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Compras",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEFAZ")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Fiscalização",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEFAZ")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Contabilidade",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEFAZ")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Cadastro Imobiliário Urbano e Rural",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEFAZ")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "PROCON",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMAJ")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "PROCURADORIA DO MUNICÍPIO",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMAJ")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Licitação",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMAJ")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Produção, Abastecimento e Comercialização - Agronegócios",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMAM")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Meio Ambiente e Micro Bacias",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMAM")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Defesa Animal",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMAM")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Defesa Civil, Corpo de Bombeiros e Vigilância",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SMSP")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Mobilidade Urbana",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SMSP")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Guarda Civil",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SMSP")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Planejamento Urbano, Habitação e Fiscalização de Obras Públicas",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SOURB")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Equipamentos Públicos Urbanos e Comunitários",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SOURB")?.Id
                               ?? Guid.Empty
            }),
            new(new()
            {
                Name = "Divisão de Serviços de Água e Esgoto",
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SOURB")?.Id
                               ?? Guid.Empty
            }),
        ];
        _users = [
            new()
            {
                Name = "Informática",
                Username = configuration["InfoUser:Username"] ?? "",
                Password = configuration["InfoUser:Password"] ?? "",
                Document = "02912383005",
                Email = configuration["InfoUser:Email"] ?? "",
                Enrollment = 9999,
                Active = true,
                RoleId = _roles[0].Id,
                PositionId = _positions[0].Id,
                UnitId = _units[0].Id,
                DepartmentId = _departments
                                   .Find(x => x.Alias == "SEMAD")?.Id
                               ?? Guid.Empty,
                DivisionId = _divisions[0].Id,
            }
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