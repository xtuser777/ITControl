using ITControl.Application.Shared.Params;
using ITControl.Domain.Treatments.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Treatments.Params;

public record ShowTreatmentsParams
{
    [FromRoute] public Guid Id { get; set; }
    [FromQuery] public bool? IncludeCall { get; set; } = true;
    [FromQuery] public bool? IncludeUser { get; set; } = true;

    public static implicit operator FindOneServiceParams(
        ShowTreatmentsParams parameters)
        => new()
        {
            Id = parameters.Id,
            Includes = new IncludesTreatmentsParams()
            {
                Call = parameters.IncludeCall,
                User = parameters.IncludeUser
            }
        };
}