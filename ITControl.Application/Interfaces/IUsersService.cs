using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Users.Requests;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IUsersService
{
    Task<User> FindOneAsync(
        Guid id, 
        bool? includePosition, 
        bool? includeRole, 
        bool? includeUsersEquipments,
        bool? includeUsersSystems);
    Task<IEnumerable<User>> FindManyAsync(FindManyUsersRequest request);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyUsersRequest request);
    Task<User?> CreateAsync(CreateUsersRequest request);
    Task UpdateAsync(Guid id, UpdateUsersRequest request);
    Task DeleteAsync(Guid id);
}