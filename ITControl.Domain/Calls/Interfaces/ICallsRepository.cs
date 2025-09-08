using ITControl.Domain.Calls.Entities;
using ITControl.Domain.Calls.Enums;

namespace ITControl.Domain.Calls.Interfaces;

public interface ICallsRepository
{
    Task<Call?> FindOneAsync(
        Guid id,
        bool? includeUser = null,
        bool? includeLocation = null,
        bool? includeEquipment = null,
        bool? includeSystem = null);
    Task<IEnumerable<Call>> FindManyAsync(
        string? title = null,
        string? description = null,
        CallReason? reason = null,
        Enums.CallStatus? status = null,
        Guid? userId = null,
        Guid? locationId = null,
        string? orderByTitle = null,
        string? orderByDescription = null,
        string? orderByReason = null,
        string? orderByStatus = null,
        string? orderByUser = null,
        string? orderByLocation = null,
        int? page = null,
        int? size = null);
    Task CreateAsync(Call call);
    void Update(Call call);
    void Delete(Call call);
    Task<int> CountAsync(
        Guid? id = null,
        string? title = null,
        string? description = null,
        CallReason? reason = null,
        Enums.CallStatus? status = null,
        Guid? userId = null,
        Guid? locationId = null);
    Task<bool> ExistsAsync(
        Guid? id = null,
        string? title = null,
        string? description = null,
        CallReason? reason = null,
        Enums.CallStatus? status = null,
        Guid? userId = null,
        Guid? locationId = null);
}
