using ITControl.Application.Shared.Params;
using ITControl.Presentation.Treatments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Treatments.Params;

public record CreateTreatmentsParams
{
    [FromBody] public CreateTreatmentsRequest 
        CreateTreatmentsRequest { get; set; } = new();

    public static implicit operator CreateServiceParams(
        CreateTreatmentsParams parameters)
        => new()
        {
            Props = parameters.CreateTreatmentsRequest,
        };
}