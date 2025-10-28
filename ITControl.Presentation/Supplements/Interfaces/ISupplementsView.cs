using ITControl.Domain.Supplements.Entities;
using ITControl.Presentation.Supplements.Responses;

namespace ITControl.Presentation.Supplements.Interfaces;

public interface ISupplementsView
{
    CreateSupplementsResponse? Create(Supplement? supplement);
    FindOneSupplementsResponse? FindOne(Supplement? supplement);
    IEnumerable<FindManySupplementsResponse> FindMany(IEnumerable<Supplement>? supplements);
}
