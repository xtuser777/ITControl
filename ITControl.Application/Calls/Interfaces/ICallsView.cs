using ITControl.Communication.Calls.Responses;
using ITControl.Domain.Calls.Entities;

namespace ITControl.Application.Calls.Interfaces;
public interface ICallsView
{
    CreateCallsResponse? Create(Call? call);
    FindOneCallsResponse? FindOne(Call? call);
    IEnumerable<FindManyCallsResponse> FindMany(IEnumerable<Call>? calls);
}
