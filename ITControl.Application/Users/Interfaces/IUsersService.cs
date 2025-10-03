using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Users.Requests;
using ITControl.Domain.Users.Entities;
using ITControl.Domain.Users.Params;

namespace ITControl.Application.Users.Interfaces;

public interface IUsersService
{
    Task<User> FindOneAsync(FindOneUsersRepositoryParams @params);
    Task<IEnumerable<User>> FindManyAsync(FindManyUsersRepositoryParams @params);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyUsersRepositoryParams @params);
    Task<User?> CreateAsync(CreateUsersRequest request);
    Task UpdateAsync(Guid id, UpdateUsersRequest request);
    Task DeleteAsync(Guid id);
}