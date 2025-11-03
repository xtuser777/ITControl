using ITControl.Domain.Departments.Props;

namespace ITControl.Domain.Departments.Entities;

public class Department : DepartmentProps
{
    public Department() { }

    public Department(DepartmentProps @params)
    {
        Assign(@params);
    }

    public void Update(DepartmentProps @params)
    {
        AssignUpdate(@params);
    }
}
