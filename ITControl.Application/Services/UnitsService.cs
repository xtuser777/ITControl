using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Units.Requests;
using ITControl.Domain.Entities;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Services;

public class UnitsService(IUnitOfWork unitOfWork) : IUnitsService
{
    public async Task<Unit?> FindOneAsync(Guid id)
    {
        return await unitOfWork.UnitsRepository.FindOneAsync( x => x.Id == id);
    }
    
    public async Task<Unit> FindOneOrThrowAsync(Guid id)
    {
        return await FindOneAsync(id) ?? throw new NotFoundException("Unit not found");
    }

    public async Task<IEnumerable<Unit>> FindManyAsync(FindManyUnitsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.UnitsRepository.FindManyAsync(
            name: request.Name,
            orderByName: request.OrderByName,
            page: page,
            size: size);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyUnitsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.UnitsRepository.CountAsync(
            name: request.Name);
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Unit?> CreateAsync(CreateUnitsRequest request)
    {
        var unit = new Unit(
            name: request.Name,
            addressNumber: request.AddressNumber,
            neighborhood: request.Neighborhood,
            streetName: request.StreetName,
            postalCode: request.PostalCode,
            phone: request.Phone);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.UnitsRepository.CreateAsync(unit);
        await unitOfWork.Commit(transaction);

        return unit;
    }

    public async Task UpdateAsync(Guid id, UpdateUnitsRequest request)
    {
        var unit = await FindOneOrThrowAsync(id);
        unit.Update(
            name: request.Name,
            addressNumber: request.AddressNumber,
            neighborhood: request.Neighborhood,
            streetName: request.StreetName,
            postalCode: request.PostalCode,
            phone: request.Phone);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.UnitsRepository.Update(unit);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var unit = await FindOneOrThrowAsync(id);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.UnitsRepository.Delete(unit);
        await unitOfWork.Commit(transaction);
    }
}