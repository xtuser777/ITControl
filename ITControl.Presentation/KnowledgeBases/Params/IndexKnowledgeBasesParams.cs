using ITControl.Application.KnowledgeBases.Params;
using ITControl.Communication.KnowledgeBases.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.KnowledgeBases.Params;

public record IndexKnowledgeBasesParams
{
    [FromQuery]
    public FindManyKnowledgeBasesRequest FindManyRequest { get; set; } = new();

    [FromHeader]
    public OrderByKnowledgeBasesRequest OrderByRequest { get; set; } = new();

    public static implicit operator FindManyKnowledgeBasesServiceParams(
        IndexKnowledgeBasesParams index)
        => new()
        {
            FindManyParams = index.FindManyRequest,
            OrderByParams = index.OrderByRequest,
            PaginationParams = index.FindManyRequest,
        };

    public static implicit operator FindManyPaginationKnowledgeBasesServiceParams(
        IndexKnowledgeBasesParams index)
        => new()
        {
            CountParams = index.FindManyRequest,
            Page = index.FindManyRequest.Page,
            Size = index.FindManyRequest.Size,
        };
}
