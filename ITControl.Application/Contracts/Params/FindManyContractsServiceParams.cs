using ITControl.Domain.Contracts.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Application.Contracts.Params;

public record FindManyContractsServiceParams
{
    public FindManyContractsRepositoryParams FindManyParams { get; set; } = new();
    public OrderByContractsRepositoryParams OrderByParams { get; set; } = new();
    public PaginationParams PaginationParams { get; set; } = new();
}
