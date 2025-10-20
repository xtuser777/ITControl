namespace ITControl.Application.Departments.Params;

public record DeleteDepartmentsServiceParams
{
    public Guid Id { get; init; }

    public static implicit operator FindOneDepartmentsServiceParams(
        DeleteDepartmentsServiceParams params_) =>
        new()
        {
            Id = params_.Id,
        };
}
