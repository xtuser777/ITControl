using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Communication.Locations.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Services;

public class LocationsService(IUnitOfWork unitOfWork) : ILocationsService
{
    public async Task<Location?> FindOneAsync(
        Guid id, 
        bool? includeUnit = null, 
        bool? includeUser = null, 
        bool? includeDepartment = null,
        bool? includeDivision = null)
    {
        return await unitOfWork.LocationsRepository.FindOneAsync(
            id, 
            includeUnit, 
            includeUser, 
            includeDepartment, 
            includeDivision);
    }

    public async Task<Location> FindOneOrThrowAsync(
        Guid id,
        bool? includeUnit = null,
        bool? includeUser = null,
        bool? includeDepartment = null,
        bool? includeDivision = null)
    {
        var location = await FindOneAsync(id, includeUnit, includeUser, includeDepartment, includeDivision);
        if (location == null)
            throw new NotFoundException("Location not found");
        
        return location;
    }

    public async Task<IEnumerable<Location>> FindManyAsync(FindManyLocationsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.LocationsRepository.FindManyAsync(
            description: request.Description,
            unitId: request.UnitId != null ? Guid.Parse(request.UnitId) : null,
            userId: request.UserId != null ? Guid.Parse(request.UserId) : null,
            departmentId: request.DepartmentId != null ? Guid.Parse(request.DepartmentId) : null,
            divisionId: request.DivisionId != null ? Guid.Parse(request.DivisionId) : null,
            orderByDescription: request.OrderByDescription,
            orderByUnit: request.OrderByUnit,
            orderByUser: request.OrderByUser,
            orderByDepartment: request.OrderByDepartment,
            orderByDivision: request.OrderByDivision,
            page: page,
            size: size);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyLocationsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.LocationsRepository.CountAsync(
            description: request.Description,
            unitId: request.UnitId != null ? Guid.Parse(request.UnitId) : null,
            userId: request.UserId != null ? Guid.Parse(request.UserId) : null,
            departmentId: request.DepartmentId != null ? Guid.Parse(request.DepartmentId) : null,
            divisionId: request.DivisionId != null ? Guid.Parse(request.DivisionId) : null);
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Location?> CreateAsync(CreateLocationsRequest request)
    {
        var location = new Location(
            description: request.Description,
            unitId: Guid.Parse(request.UnitId),
            userId: Guid.Parse(request.UserId),
            departmentId: Guid.Parse(request.DepartmentId),
            divisionId: request.DivisionId != null ? Guid.Parse(request.DivisionId) : null);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.LocationsRepository.CreateAsync(location);
        await unitOfWork.Commit(transaction);
        
        return location;
    }

    public async Task UpdateAsync(Guid id, UpdateLocationsRequest request)
    {
        var location = await FindOneOrThrowAsync(id);
        location.Update(
            description: request.Description,
            unitId: request.UnitId != null ? Guid.Parse(request.UnitId) : null,
            userId: request.UserId != null ? Guid.Parse(request.UserId) : null,
            departmentId: request.DepartmentId != null ? Guid.Parse(request.DepartmentId) : null,
            divisionId: request.DivisionId != null ? Guid.Parse(request.DivisionId) : null);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.LocationsRepository.UpdateAsync(location);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var location = await FindOneOrThrowAsync(id);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.LocationsRepository.DeleteAsync(location);
        await unitOfWork.Commit(transaction);
    }
}