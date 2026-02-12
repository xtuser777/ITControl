using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Tools;
using ITControl.Application.Units.Interfaces;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.SuppliesMovements.Props;
using ITControl.Domain.Units.Entities;
using ITControl.Domain.Units.Props;

namespace ITControl.Application.Units.Services;

public class UnitsService(IUnitOfWork unitOfWork) : IUnitsService
{
    public async Task<Unit> FindOneAsync(
        FindOneServiceParams parameters)
    {
        return await unitOfWork.UnitsRepository.FindOneAsync(parameters) 
               ?? throw new NotFoundException(Errors.UNIT_NOT_FOUND);
    }

    public async Task<IEnumerable<Unit>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        return await unitOfWork.UnitsRepository
            .FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.UnitsRepository
            .CountAsync(parameters.CountProps);
        var pagination = Pagination.Build(parameters.PaginationParams, count);
        return pagination;
    }

    public async Task<Unit?> CreateAsync(
        CreateServiceParams parameters)
    {
        var unit = new Unit((UnitProps)parameters.Props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.UnitsRepository.CreateAsync(unit);
        await unitOfWork.Commit(transaction);

        return unit;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var unit = await FindOneAsync(parameters);
        unit.Update((UnitProps)parameters.Props);
        unitOfWork.UnitsRepository.Update(unit);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var unit = await FindOneAsync(parameters);
        await CheckDependenciesAsync(unit.Id ?? Guid.Empty);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.UnitsRepository.Delete(unit);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckDependenciesAsync(Guid unitId)
    {
        await CheckSupplyMovemntDependenciesAsync(unitId);
        await CheckUserDependenciesAsync(unitId);
    }

    private async Task CheckSupplyMovemntDependenciesAsync(Guid unitId)
    {
        var suplementMovements = await unitOfWork.SuppliesMovementsRepository
            .CountAsync(new SupplyMovementProps
                {
                    UnitId = unitId
                });
        if (suplementMovements > 0)
        {
            throw new BadRequestException($"A unidade possui vínculo com {suplementMovements} movimentos de suplementos");
        }
    }

    private async Task CheckUserDependenciesAsync(Guid unitId)
    {
        var users = await unitOfWork.UsersRepository
            .CountAsync(new Domain.Users.Props.UserProps
                {
                    UnitId = unitId
                });
        if (users > 0)
        {
            throw new BadRequestException($"A unidade possui vínculo com {users} usuários");
        }
    }
}