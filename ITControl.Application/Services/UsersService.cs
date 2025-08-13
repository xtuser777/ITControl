using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Users.Requests;
using ITControl.Domain.Entities;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Services;

public class UsersService(IUnitOfWork unitOfWork) : IUsersService
{
    public async Task<User?> FindOneAsync(Guid id)
    {
        return await unitOfWork.UsersRepository.FindOneAsync(id, includePosition: true, includeRole: true);
    }

    private async Task<User> FindOneOrThrowAsync(Guid id)
    {
        var user = await FindOneAsync(id);
        if (user == null) throw new NotFoundException("Usuário não encontrado");
        
        return user;
    }

    public async Task<IEnumerable<User>> FindManyAsync(FindManyUsersRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.UsersRepository.FindManyAsync(
            username: request.Username,
            email: request.Email,
            name: request.Name,
            active: request.Active == "true",
            orderByUsername: request.OrderByUsername,
            orderByName: request.OrderByName,
            orderByEmail: request.OrderByEmail,
            orderByActive: request.OrderByActive,
            page: page,
            size: size);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyUsersRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.UsersRepository.CountAsync(
            username: request.Username,
            email: request.Email,
            name: request.Name,
            active: request.Active == "true");
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<User?> CreateAsync(CreateUsersRequest request)
    {
        var user = User.Create(
            username: request.Username,
            email: request.Email,
            name: request.Name,
            password: request.Password,
            enrollment: request.Enrollment,
            positionId: Guid.Parse(request.PositionId),
            roleId: Guid.Parse(request.RoleId));
        await unitOfWork.UsersRepository.CreateAsync(user);

        return user;
    }

    public async Task UpdateAsync(Guid id, UpdateUsersRequest request)
    {
        var user = await FindOneOrThrowAsync(id);
        user.Update(
            username: request.Username,
            email: request.Email,
            name: request.Name,
            password: request.Password,
            enrollment: request.Enrollment,
            positionId: request.PositionId != null ? Guid.Parse(request.PositionId) : null,
            roleId: request.RoleId != null ? Guid.Parse(request.RoleId) : null,
            active: request.Active);
        await unitOfWork.UsersRepository.UpdateAsync(user); 
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await FindOneOrThrowAsync(id);
        await unitOfWork.UsersRepository.DeleteAsync(user);
    }
}