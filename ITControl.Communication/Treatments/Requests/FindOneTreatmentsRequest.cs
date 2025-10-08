using ITControl.Domain.Treatments.Params;

namespace ITControl.Communication.Treatments.Requests;

public class FindOneTreatmentsRequest
{
    public Guid Id { get; set; } = Guid.Empty;
    public bool? IncludeCall { get; set; } = null;
    public bool? IncludeUser { get; set; } = null;

    public static implicit operator FindOneTreatmentsRepositoryParams(FindOneTreatmentsRequest request)
        => new()
        {
            Id = request.Id,
            IncludeCall = request.IncludeCall,
            IncludeUser = request.IncludeUser
        };
}
