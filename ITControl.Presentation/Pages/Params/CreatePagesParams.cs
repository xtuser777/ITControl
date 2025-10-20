using ITControl.Application.Pages.Params;
using ITControl.Communication.Pages.Requests;

namespace ITControl.Presentation.Pages.Params;

public record CreatePagesParams
{
    public CreatePagesRequest Request { get; set; } = new();

    public static implicit operator CreatePagesServiceParams
        (CreatePagesParams paramsModel) =>
        new()
        {
            Params = paramsModel.Request
        };
}
