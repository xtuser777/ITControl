using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Communication.Divisions.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Services;

public class DivisionsService(IUnitOfWork unitOfWork) : IDivisionsService
{
    public async Task<Division?> FindOneAsync(Guid id, bool? includeDepartment = null, bool? includeUser = null)
    {
        return await unitOfWork.DivisionsRepository.FindOneAsync(id, includeDepartment, includeUser);
    }

    private async Task<Division> FindOneOrThrowAsync(Guid id, bool? includeDepartment = null, bool? includeUser = null)
    {
        var division = await FindOneAsync(id, includeDepartment, includeUser);
        if (division == null) 
            throw new NotFoundException("divisão não encontrada");
        
        return division;
    }
    
    public async Task<IEnumerable<Division>> FindManyAsync(FindManyDivisionsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.DivisionsRepository.FindManyAsync(
            name: request.Name,
            departmentId: request.DepartmentId != null ? Guid.Parse(request.DepartmentId) : null,
            userId: request.UserId != null ? Guid.Parse(request.UserId) : null,
            orderByName: request.OrderByName,
            orderByDepartment: request.OrderByDepartment,
            orderByUser: request.OrderByUser,
            page: page,
            size: size);
    }

    public async Task<PaginationResponse?> FindManyPaginatedAsync(FindManyDivisionsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.DivisionsRepository.CountAsync(
            name: request.Name,
            departmentId: request.DepartmentId != null ? Guid.Parse(request.DepartmentId) : null,
            userId: request.UserId != null ? Guid.Parse(request.UserId) : null);
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Division?> CreateAsync(CreateDivisionsRequest request)
    {
        var division = Division.Create(request.Name, Guid.Parse(request.DepartmentId), Guid.Parse(request.UserId));
        await unitOfWork.DivisionsRepository.CreateAsync(division);
        
        return division;
    }

    public async Task UpdateAsync(Guid id, UpdateDivisionsRequest request)
    {
        var division = await FindOneOrThrowAsync(id);
        division.Update(
            request.Name,
            request.DepartmentId != null ? Guid.Parse(request.DepartmentId) : null,
            request.UserId != null ? Guid.Parse(request.UserId) : null);
        await unitOfWork.DivisionsRepository.UpdateAsync(division);
    }

    public async Task DeleteAsync(Guid id)
    {
        var division = await FindOneOrThrowAsync(id);
        await unitOfWork.DivisionsRepository.DeleteAsync(division);
    }
}