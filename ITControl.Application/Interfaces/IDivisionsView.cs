using ITControl.Communication.Divisions.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IDivisionsView
{
    CreateDivisionsResponse? Create(Division? division);
    FindOneDivisionsResponse? FindOne(Division? division);
    IEnumerable<FindManyDivisionsResponse> FindMany(IEnumerable<Division>? divisions);
}