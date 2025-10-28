using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Pages.Params;

public record FindManyPagesParams : FindManyParams
{
    public string? Name { get; set; } 
}