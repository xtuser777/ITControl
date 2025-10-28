using ITControl.Application.Shared.Params;
using ITControl.Presentation.Treatments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Treatments.Params;

public record UpdateTreatmentsParams
{
    [FromRoute] public Guid Id { get; set; }
    [FromBody] public UpdateTreatmentsRequest 
        UpdateTreatmentsRequest { get; set; } = new();

    public static implicit operator UpdateServiceParams(
        UpdateTreatmentsParams parameters)
        => new()
        {
            Id = parameters.Id,
            Params = parameters.UpdateTreatmentsRequest,
        };
}