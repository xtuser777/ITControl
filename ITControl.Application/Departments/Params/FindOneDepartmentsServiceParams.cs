using ITControl.Domain.Departments.Params;

namespace ITControl.Application.Departments.Params;

public record FindOneDepartmentsServiceParams
{
    public Guid Id { get; init; }

    public static implicit operator FindOneDepartmentsRepositoryParams(
        FindOneDepartmentsServiceParams serviceParams) =>
        new ()
        {
            Id = serviceParams.Id,
        };
}
