using ITControl.Domain.Calls.Params;

namespace ITControl.Communication.Calls.Requests;

public class FindOneCallsRequest
{
    public Guid Id { get; set; } = Guid.Empty;
    public bool? IncludeUser { get; set; } = true;
    public bool? IncludeEquipment { get; set; } = true;
    public bool? IncludeSystem { get; set; } = true;

    public static implicit operator FindOneCallsRepositoryParams(FindOneCallsRequest request) =>
        new()
        {
            Id = request.Id,
            IncludeUser = request.IncludeUser,
            IncludeEquipment = request.IncludeEquipment,
            IncludeSystem = request.IncludeSystem
        };
}
