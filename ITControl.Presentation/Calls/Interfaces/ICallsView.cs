using ITControl.Domain.Calls.Entities;
using ITControl.Presentation.Calls.Responses;

namespace ITControl.Presentation.Calls.Interfaces;
public interface ICallsView
{
    CreateCallsResponse? Create(Call? call);
    FindOneCallsResponse? FindOne(Call? call);
    IEnumerable<FindManyCallsResponse> FindMany(IEnumerable<Call>? calls);
}
