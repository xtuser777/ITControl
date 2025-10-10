using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Users.Requests;
using ITControl.Domain.Users.Entities;

namespace ITControl.Application.Users.Interfaces;

public interface IUsersService
{
    Task<User> FindOneAsync(FindOneUsersRequest request);
    Task<IEnumerable<User>> FindManyAsync(FindManyUsersRequest request);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyUsersRequest request);
    Task<User?> CreateAsync(CreateUsersRequest request);
    Task UpdateAsync(Guid id, UpdateUsersRequest request);
    Task DeleteAsync(Guid id);
}