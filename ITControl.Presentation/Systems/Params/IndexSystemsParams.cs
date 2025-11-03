using ITControl.Application.Shared.Params;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Shared.Utils;
using ITControl.Domain.Systems.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Systems.Params;

public record IndexSystemsParams : PaginationParams
{
    public string? Name { get; set; }
    public string? Version { get; set; }
    public DateOnly? ImplementedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public string? Own { get; set; }
    public Guid? ContractId { get; set; }
    
    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; init; }
    
    [FromHeader(Name = "X-Order-By-Version")]
    public string? OrderByVersion { get; init; }
    
    [FromHeader(Name = "X-Order-By-Implemented-At")]
    public string? OrderByImplementedAt { get; init; }
    
    [FromHeader(Name = "X-Order-By-Ended-At")]
    public string? OrderByEndedAt { get; init; }
    
    [FromHeader(Name = "X-Order-By-Own")]
    public string? OrderByOwn { get; init; }

    public static implicit operator OrderBySystemsParams(
        IndexSystemsParams request) =>
        new()
        {
            Name = request.OrderByName,
            Version = request.OrderByVersion,
            ImplementedAt = request.OrderByImplementedAt,
            EndedAt = request.OrderByEndedAt,
            Own = request.OrderByOwn
        };

    public static implicit operator FindManySystemsParams(
        IndexSystemsParams request) =>
        new()
        {
            Name = request.Name,
            Version = request.Version,
            ImplementedAt = request.ImplementedAt,
            EndedAt = request.EndedAt,
            Own = Parser.ToBoolOptional(request.Own),
            ContractId = request.ContractId
        };

    public static implicit operator CountSystemsParams(
        IndexSystemsParams request) =>
        new()
        {
            Name = request.Name,
            Version = request.Version,
            ImplementedAt = request.ImplementedAt,
            EndedAt = request.EndedAt,
            Own = Parser.ToBoolOptional(request.Own),
            ContractId = request.ContractId
        };

    public static implicit operator FindManyServiceParams(
        IndexSystemsParams parameters)
        => new()
        {
            FindManyProps = parameters,
            OrderByParams = parameters,
            PaginationParams = parameters
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexSystemsParams parameters)
        => new()
        {
            CountProps = parameters,
            PaginationParams = parameters
        };
}