using ITControl.Application.Shared.Params;
using ITControl.Domain.Pages.Params;
using ITControl.Domain.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Pages.Params;

public record IndexPagesParams : PaginationParams
{
    public string? Name { get; set; }
    
    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; set; }

    public static implicit operator OrderByPagesParams(
        IndexPagesParams request) => 
        new() 
        { 
            Name = request.OrderByName, 
        };

    public static implicit operator FindManyPagesParams(
        IndexPagesParams request) => 
        new() 
        { 
            Name = request.Name, 
        };

    public static implicit operator CountPagesParams(
        IndexPagesParams request) =>
        new()
        {
            Name = request.Name,
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexPagesParams paramsModel) =>
        new()
        {
            CountParams = paramsModel,
            PaginationParams = paramsModel,
        };

    public static implicit operator FindManyServiceParams(
        IndexPagesParams paramsModel)
        => new()
        {
            FindManyParams = paramsModel,
            OrderByParams = paramsModel,
            PaginationParams = paramsModel,
        };
}
