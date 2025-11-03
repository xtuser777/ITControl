using ITControl.Application.Shared.Params;
using ITControl.Domain.Contracts.Params;
using ITControl.Domain.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Contracts.Params;

public record IndexContractsParams : PaginationParams
{
    public string? Enterprise { get; set; }
    public string? ObjectName { get; set; }
    public DateOnly? StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    
    [FromHeader(Name = "X-Order-By-Enterprise")]
    public string? OrderByEnterprise { get; set; }
    
    [FromHeader(Name = "X-Order-By-Object-Name")]
    public string? OrderByObjectName { get; set; }

    [FromHeader(Name = "X-Order-By-Started-At")]
    public string? OrderByStartedAt { get; set; } 
    
    [FromHeader(Name = "X-Order-By-Ended-At")]
    public string? OrderByEndedAt { get; set; }

    public static implicit operator OrderByContractsParams(
        IndexContractsParams request)
    {
        return new OrderByContractsParams
        {
            Enterprise = request.OrderByEnterprise,
            ObjectName = request.OrderByObjectName,
            StartedAt = request.OrderByStartedAt,
            EndedAt = request.OrderByEndedAt
        };
    }

    public static implicit operator FindManyContractsParams(
        IndexContractsParams request) =>
        new()
        {
            Enterprise = request.Enterprise,
            ObjectName = request.ObjectName,
            StartedAt = request.StartedAt,
            EndedAt = request.EndedAt,
        };

    public static implicit operator CountContractsParams(
        IndexContractsParams request) =>
        new()
        {
            Enterprise = request.Enterprise,
            ObjectName = request.ObjectName,
            StartedAt = request.StartedAt,
            EndedAt = request.EndedAt
        };

    public static implicit operator FindManyServiceParams(
        IndexContractsParams index)
        => new()
        {
            FindManyProps= index,
            OrderByParams = index,
            PaginationParams = index,
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexContractsParams index)
        => new()
        {
            CountProps = index,
            PaginationParams = index,
        };
}
