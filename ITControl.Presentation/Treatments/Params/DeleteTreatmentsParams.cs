using ITControl.Application.Shared.Params;
using ITControl.Presentation.Shared.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Treatments.Params;

public record DeleteTreatmentsParams
{
    [FromRoute] public Guid Id { get; set; }

    [ModelBinder(BinderType = typeof(UserIdAttribute))]
    public Guid UserId { get; set; }

    public static implicit operator DeleteServiceParams(
        DeleteTreatmentsParams parameters)
        => new()
        {
            Id = parameters.Id,
        };
}