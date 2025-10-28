using ITControl.Application.Shared.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Users.Entities;

namespace ITControl.Application.Users.Interfaces;

public interface IUsersService
{
    Task<User> FindOneAsync(
        FindOneServiceParams parameters);
    Task<IEnumerable<User>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters);
    Task<User?> CreateAsync(
        CreateServiceParams parameters);
    Task UpdateAsync(
        UpdateServiceParams parameters);
    Task DeleteAsync(DeleteServiceParams parameters);
}