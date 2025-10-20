using ITControl.Application.Departments.Params;
using ITControl.Communication.Departments.Requests;

namespace ITControl.Presentation.Departments.Params;

public record CreateDepartmentsParams
{
    public CreateDepartmentsRequest Request { get; set; } = null!;

    public static implicit operator CreateDepartmentsServiceParams(CreateDepartmentsParams paramsModel) =>
        new()
        {
            Params = paramsModel.Request
        };
}
