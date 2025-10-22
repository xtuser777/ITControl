using ITControl.Application.Pages.Params;
using ITControl.Communication.Pages.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Pages.Params;

public record IndexPagesParams
{
    [FromQuery]
    public FindManyPagesRequest FindManyRequest { get; set; } = new();
    
    [FromHeader]
    public OrderByPagesRequest OrderByRequest { get; set; } = new();

    public static implicit operator FindManyPaginationPagesServiceParams(
        IndexPagesParams paramsModel) =>
        new()
        {
            CountParams = paramsModel.FindManyRequest,
            Page = paramsModel.FindManyRequest.Page,
            Size = paramsModel.FindManyRequest.Size,
        };

    public static implicit operator FindManyPagesServiceParams(
        IndexPagesParams paramsModel)
        => new()
        {
            FindManyParams = paramsModel.FindManyRequest,
            OrderByParams = paramsModel.OrderByRequest,
            PaginationParams = paramsModel.FindManyRequest,
        };
}
