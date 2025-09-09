using ITControl.Communication.Supplements.Responses;
using ITControl.Domain.Supplements.Entities;

namespace ITControl.Application.Supplements.Interfaces;

public interface ISupplementsView
{
    CreateSupplementsResponse? Create(Supplement? supplement);
    FindOneSupplementsResponse? FindOne(Supplement? supplement);
    IEnumerable<FindManySupplementsResponse> FindMany(IEnumerable<Supplement>? supplements);
}
