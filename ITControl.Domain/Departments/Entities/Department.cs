using ITControl.Domain.Departments.Props;

namespace ITControl.Domain.Departments.Entities;

public class Department : DepartmentProps
{
    public Department()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Department(DepartmentProps @params)
    {
        Assign(@params);
    }

    public void Update(DepartmentProps @params)
    {
        AssignUpdate(@params);
    }
}
