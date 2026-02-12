using ITControl.Domain.Supplies.Entities;
using ITControl.Presentation.Supplies.Responses;

namespace ITControl.Presentation.Supplies.Interfaces;

public interface ISuppliesView
{
    CreateSuppliesResponse? Create(Supply? supply);
    FindOneSuppliesResponse? FindOne(Supply? supply);
    IEnumerable<FindManySuppliesResponse> FindMany(IEnumerable<Supply>? supplies);
}
