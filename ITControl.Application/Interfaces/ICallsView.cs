using ITControl.Communication.Calls.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;
public interface ICallsView
{
    CreateCallsResponse? Create(Call? call);
    FindOneCallsResponse? FindOne(Call? call);
    IEnumerable<FindManyCallsResponse> FindMany(IEnumerable<Call>? calls);
}
