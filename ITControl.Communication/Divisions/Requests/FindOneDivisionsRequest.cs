using ITControl.Domain.Divisions.Params;

namespace ITControl.Communication.Divisions.Requests;

public class FindOneDivisionsRequest
{
    public Guid Id { get; set; } = Guid.Empty;
    public bool? IncludeDepartment { get; set; } = true;

    public static implicit operator FindOneDivisionsRepositoryParams(FindOneDivisionsRequest request)
        => new()
        {
            Id = request.Id,
            IncludeDepartment = request.IncludeDepartment ?? true
        };
}
