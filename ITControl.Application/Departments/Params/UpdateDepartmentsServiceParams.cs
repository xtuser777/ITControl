using ITControl.Domain.Departments.Params;

namespace ITControl.Application.Departments.Params;

public record UpdateDepartmentsServiceParams
{
    public Guid Id { get; set; }
    public UpdateDepartmentParams Params { get; set; } = null!;

    public static implicit operator UpdateDepartmentParams(UpdateDepartmentsServiceParams serviceParams)
        => serviceParams.Params;

    public static implicit operator FindOneDepartmentsServiceParams(UpdateDepartmentsServiceParams serviceParams)
        => new()
        {
            Id = serviceParams.Id
        };
}
