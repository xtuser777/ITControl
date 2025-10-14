using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Application.SupplementsMovements.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.SupplementsMovements.Requests;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.SupplementsMovements.Entities;

namespace ITControl.Application.SupplementsMovements.Services;

public class SupplementsMovementsService(
    IUnitOfWork unitOfWork) : ISupplementsMovementsService
{
    public async Task<SupplementMovement> FindOneAsync(Guid id, bool? includeSupplement = null, 
        bool? includeUser = null, bool? includeUnit = null, bool? includeDepartment = null, 
        bool? includeDivision = null)
    {
        return await unitOfWork.SupplementsMovementsRepository
            .FindOneAsync(id, includeSupplement, includeUser, includeUnit, includeDepartment, includeDivision)
            ?? throw new NotFoundException(Errors.SupplementMovimentNotFound);
    }

    public async Task<IEnumerable<SupplementMovement>> FindManyAsync(FindManySupplementsMovementsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.SupplementsMovementsRepository.FindManyAsync(
            quantity: request.Quantity,
            movementDate: request.MovementDate,
            observation: request.Observation,
            supplementId: request.SupplementId,
            userId: request.UserId,
            unitId: request.UnitId,
            departmentId: request.DepartmentId,
            divisionId: request.DivisionId,
            orderByQuantity: request.OrderByQuantity,
            orderByMovementDate: request.OrderByMovementDate,
            orderByObservation: request.OrderByObservation,
            orderBySupplement: request.OrderBySupplement,
            orderByUser: request.OrderByUser,
            orderByUnit: request.OrderByUnit,
            orderByDepartment: request.OrderByDepartment,
            orderByDivision: request.OrderByDivision,
            page: page,
            size: size);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManySupplementsMovementsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;

        var count = await unitOfWork.SupplementsMovementsRepository.CountAsync(
            quantity: request.Quantity,
            movementDate: request.MovementDate,
            observation: request.Observation,
            supplementId: request.SupplementId,
            userId: request.UserId,
            unitId: request.UnitId,
            departmentId: request.DepartmentId,
            divisionId: request.DivisionId);

        var pagination = Pagination.Build(request.Page, request.Size, count);

        return pagination;
    }

    public async Task<SupplementMovement> CreateAsync(CreateSupplementsMovementsRequest request)
    {
        var supplementMovement = new SupplementMovement(
            quantity: request.Quantity,
            movementDate: request.MovementDate,
            observation: request.Observation,
            supplementId: request.SupplementId,
            userId: request.UserId,
            unitId: request.UnitId,
            departmentId: request.DepartmentId,
            divisionId: request.DivisionId);
        using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.SupplementsMovementsRepository.CreateAsync(supplementMovement);
        await DecrementSupplementStock(request.SupplementId, request.Quantity);
        await unitOfWork.Commit(transaction);

        return supplementMovement;
    }

    public async Task DeleteAsync(Guid id)
    {
        var supplementMovement = await FindOneAsync(id);
        using var transaction = unitOfWork.BeginTransaction;
        await AddSupplementStock(supplementMovement.SupplementId, supplementMovement.Quantity);
        unitOfWork.SupplementsMovementsRepository.Delete(supplementMovement);
        await unitOfWork.Commit(transaction);
    }

    private async Task DecrementSupplementStock(Guid supplementId, int quantity)
    {
        var supplement = await unitOfWork.SupplementsRepository.FindOneAsync(supplementId);
        if (supplement != null)
        {
            var newQuantity = supplement.QuantityInStock - quantity;
            supplement.Update(quantityInStock: newQuantity);
            unitOfWork.SupplementsRepository.Update(supplement);
        }
    }

    private async Task AddSupplementStock(Guid supplementId, int quantity)
    {
        var supplement = await unitOfWork.SupplementsRepository.FindOneAsync(supplementId);
        if (supplement != null)
        {
            var newQuantity = supplement.QuantityInStock + quantity;
            supplement.Update(quantityInStock: newQuantity);
            unitOfWork.SupplementsRepository.Update(supplement);
        }
    }
}
