using ITControl.Application.Locations.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Locations.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Exceptions;
using ITControl.Domain.Locations.Entities;

namespace ITControl.Application.Locations.Services;

public class LocationsService(IUnitOfWork unitOfWork) : ILocationsService
{
    public async Task<Location> FindOneAsync(
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
            includeDivision) 
               ?? throw new NotFoundException(Errors.LOCATION_NOT_FOUND);
    }

    public async Task<IEnumerable<Location>> FindManyAsync(FindManyLocationsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.LocationsRepository.FindManyAsync(
            description: request.Description,
            unitId: request.UnitId,
            userId: request.UserId,
            departmentId: request.DepartmentId,
            divisionId: request.DivisionId,
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
            unitId: request.UnitId,
            userId: request.UserId,
            departmentId: request.DepartmentId,
            divisionId: request.DivisionId);
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Location?> CreateAsync(CreateLocationsRequest request)
    {
        await CheckExistence(
            unitId: request.UnitId,
            userId: request.UserId,
            departmentId: request.DepartmentId,
            divisionId: request.DivisionId);
        var location = new Location(
            description: request.Description,
            unitId: request.UnitId,
            userId: request.UserId,
            departmentId: request.DepartmentId,
            divisionId: request.DivisionId);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.LocationsRepository.CreateAsync(location);
        await unitOfWork.Commit(transaction);
        
        return location;
    }

    public async Task UpdateAsync(Guid id, UpdateLocationsRequest request)
    {
        await CheckExistence(
            unitId: request.UnitId,
            userId: request.UserId,
            departmentId: request.DepartmentId,
            divisionId: request.DivisionId);
        var location = await FindOneAsync(id);
        location.Update(
            description: request.Description,
            unitId: request.UnitId,
            userId: request.UserId,
            departmentId: request.DepartmentId,
            divisionId: request.DivisionId);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.LocationsRepository.Update(location);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var location = await FindOneAsync(id);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.LocationsRepository.Delete(location);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckExistence(
        Guid? unitId, Guid? userId, Guid? departmentId, Guid? divisionId)
    {
        var messages = new List<string>();
        if (unitId.HasValue)
        {
            await CheckUnitExistence(unitId.Value, messages);
        }   
        if (userId.HasValue)
        {
            await CheckUserExistence(userId.Value, messages);
        }
        if (departmentId.HasValue)
        {
            await CheckDepartmentExistence(departmentId.Value, messages);
        }
        if (messages.Count > 0)
        {
            throw new NotFoundException(string.Join(", ", messages));
        }
    }

    private async Task CheckUnitExistence(Guid unitId, List<string> messages)
    {
        var unit = await unitOfWork.UnitsRepository.ExistsAsync(id: unitId);
        if (unit == false)
        {
            messages.Add(Errors.UNIT_NOT_FOUND);
        }
    }

    private async Task CheckUserExistence(Guid userId, List<string> messages)
    {
        var user = await unitOfWork.UsersRepository.ExistsAsync(new() { Id = userId });
        if (user == false)
        {
            messages.Add(Errors.USER_NOT_FOUND);
        }
    }

    private async Task CheckDepartmentExistence(Guid departmentId, List<string> messages)
    {
        var department = await unitOfWork.DepartmentsRepository.ExistsAsync(new() { Id = departmentId });
        if (department == false)
        {
            messages.Add(Errors.DEPARTMENT_NOT_FOUND);
        }
    }
}