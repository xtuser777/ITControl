using ITControl.Domain.Pages.Params;

namespace ITControl.Communication.Pages.Requests;

public record OrderByPagesRequest
{
    public string? Name { get; set; }

    public static implicit operator OrderByPagesRepositoryParams(OrderByPagesRequest request) => 
        new() 
        { 
            Name = request.Name, 
        };
}