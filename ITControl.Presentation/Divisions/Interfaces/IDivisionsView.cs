using ITControl.Domain.Divisions.Entities;
using ITControl.Presentation.Divisions.Responses;

namespace ITControl.Presentation.Divisions.Interfaces;

public interface IDivisionsView
{
    CreateDivisionsResponse? Create(Division? division);
    FindOneDivisionsResponse? FindOne(Division? division);
    IEnumerable<FindManyDivisionsResponse> FindMany(IEnumerable<Division>? divisions);
}