using ITControl.Domain.KnowledgeBases.Params;

namespace ITControl.Application.KnowledgeBases.Params;

public record FindManyPaginationKnowledgeBasesServiceParams
{
    public CountKnowledgeBasesRepositoryParams CountParams { get; set; } = new();
    public string? Page {  get; set; } = null;
    public string? Size { get; set; } = null;

    public void Deconstruct(out string? page, out string? size)
    {
        page = Page;
        size = Size;
    }
}
