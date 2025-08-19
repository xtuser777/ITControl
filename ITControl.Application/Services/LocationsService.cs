using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Application.Utils;
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
            x => x.Id == id, 
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
        return await FindOneAsync(id, includeUnit, includeUser, includeDepartment, includeDivision) 
            ?? throw new NotFoundException("Location not found");
    }

    public async Task<IEnumerable<Location>> FindManyAsync(FindManyLocationsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.LocationsRepository.FindManyAsync(
            description: request.Description,
            unitId: Parser.ToGuidOptional(request.UnitId),
            userId: Parser.ToGuidOptional(request.UserId),
            departmentId: Parser.ToGuidOptional(request.DepartmentId),
            divisionId: Parser.ToGuidOptional(request.DivisionId),
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
            unitId: Parser.ToGuidOptional(request.UnitId),
            userId: Parser.ToGuidOptional(request.UserId),
            departmentId: Parser.ToGuidOptional(request.DepartmentId),
            divisionId: Parser.ToGuidOptional(request.DivisionId));
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Location?> CreateAsync(CreateLocationsRequest request)
    {
        await CheckExistence(
            unitId: Parser.ToGuid(request.UnitId),
            userId: Parser.ToGuid(request.UserId),
            departmentId: Parser.ToGuid(request.DepartmentId),
            divisionId: Parser.ToGuidOptional(request.DivisionId));
        var location = new Location(
            description: request.Description,
            unitId: Parser.ToGuid(request.UnitId),
            userId: Parser.ToGuid(request.UserId),
            departmentId: Parser.ToGuid(request.DepartmentId),
            divisionId: Parser.ToGuidOptional(request.DivisionId));
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.LocationsRepository.CreateAsync(location);
        await unitOfWork.Commit(transaction);
        
        return location;
    }

    public async Task UpdateAsync(Guid id, UpdateLocationsRequest request)
    {
        await CheckExistence(
            unitId: Parser.ToGuidOptional(request.UnitId),
            userId: Parser.ToGuidOptional(request.UserId),
            departmentId: Parser.ToGuidOptional(request.DepartmentId),
            divisionId: Parser.ToGuidOptional(request.DivisionId));
        var location = await FindOneOrThrowAsync(id);
        location.Update(
            description: request.Description,
            unitId: Parser.ToGuidOptional(request.UnitId),
            userId: Parser.ToGuidOptional(request.UserId),
            departmentId: Parser.ToGuidOptional(request.DepartmentId),
            divisionId: Parser.ToGuidOptional(request.DivisionId));
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.LocationsRepository.Update(location);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var location = await FindOneOrThrowAsync(id);
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
        if (divisionId.HasValue)
        {
            await CheckDivisionExistence(divisionId.Value, messages);
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
            messages.Add("the unit does not exist");
        }
    }

    private async Task CheckUserExistence(Guid userId, List<string> messages)
    {
        var user = await unitOfWork.UsersRepository.ExistsAsync(id: userId);
        if (user == false)
        {
            messages.Add("the user does not exist");
        }
    }

    private async Task CheckDepartmentExistence(Guid departmentId, List<string> messages)
    {
        var department = await unitOfWork.DepartmentsRepository.ExistsAsync(id: departmentId);
        if (department == false)
        {
            messages.Add("the department does not exist");
        }
    }

    private async Task CheckDivisionExistence(Guid divisionId, List<string> messages)
    {
        var division = await unitOfWork.DivisionsRepository.ExistsAsync(id: divisionId);
        if (division == false)
        {
            messages.Add("the division does not exist");
        }
    }
}