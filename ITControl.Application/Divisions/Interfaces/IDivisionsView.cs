using ITControl.Communication.Divisions.Responses;
using ITControl.Domain.Divisions.Entities;

namespace ITControl.Application.Divisions.Interfaces;

public interface IDivisionsView
{
    CreateDivisionsResponse? Create(Division? division);
    FindOneDivisionsResponse? FindOne(Division? division);
    IEnumerable<FindManyDivisionsResponse> FindMany(IEnumerable<Division>? divisions);
}