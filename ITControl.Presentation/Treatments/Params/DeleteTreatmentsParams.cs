using ITControl.Application.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Treatments.Params;

public record DeleteTreatmentsParams
{
    [FromRoute] public Guid Id { get; set; }

    public static implicit operator DeleteServiceParams(
        DeleteTreatmentsParams parameters)
        => new()
        {
            Id = parameters.Id,
        };
}