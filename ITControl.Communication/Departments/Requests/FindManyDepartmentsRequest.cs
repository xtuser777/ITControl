using Azure.Core;
using ITControl.Communication.Shared.Requests;
using ITControl.Domain.Departments.Params;

namespace ITControl.Communication.Departments.Requests;

public class FindManyDepartmentsRequest : PageableRequest
{
    public string? Alias { get; set; }
    public string? Name { get; set; }
    public string? OrderByAlias { get; set; }
    public string? OrderByName { get; set; }

    public void Deconstruct(out string? alias, out string? name, 
        out string? orderByAlias, out string? orderByName, 
        out int? page, out int? size)
    {
        alias = Alias;
        name = Name;
        orderByAlias = OrderByAlias;
        orderByName = OrderByName;
        page = Page != null ? int.Parse(Page) : null; ;
        size = Size != null ? int.Parse(Size) : null; ;
    }

    public static implicit operator FindManyDepartmentsRepositoryParams(FindManyDepartmentsRequest request)
    {
        var (alias, name, orderByAlias, orderByName, page, size) = request;
        return new FindManyDepartmentsRepositoryParams
        {
            Alias = alias,
            Name = name,
            OrderByAlias = orderByAlias,
            OrderByName = orderByName,
            Page = page,
            Size = size
        };
    }

    public static implicit operator CountDepartmentsRepositoryParams(FindManyDepartmentsRequest request)
    {
        var (alias, name, _, _, _, _) = request;
        return new CountDepartmentsRepositoryParams
        {
            Alias = alias,
            Name = name
        };
    }
}