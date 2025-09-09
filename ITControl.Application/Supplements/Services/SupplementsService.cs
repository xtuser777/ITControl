using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Application.Shared.Utils;
using ITControl.Application.Supplements.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Supplements.Requests;
using ITControl.Domain.Exceptions;
using ITControl.Domain.Supplements.Entities;
using ITControl.Domain.Supplements.Enums;

namespace ITControl.Application.Supplements.Services;

public class SupplementsService(
    IUnitOfWork unitOfWork) : ISupplementsService
{
    public async Task<Supplement> FindOneAsync(Guid id)
    {
        return await unitOfWork.SupplementsRepository.FindOneAsync(id) 
            ?? throw new NotFoundException(Errors.SUPPLEMENT_NOT_FOUND);
    }

    public async Task<IEnumerable<Supplement>> FindManyAsync(FindManySupplementsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.SupplementsRepository.FindManyAsync(
            brand: request.Brand,
            model: request.Model,
            type: Parser.ToEnumOptional<SupplementType>(request.Type),
            stock: request.Stock,
            orderByBrand: request.OrderByBrand,
            orderByModel: request.OrderByModel,
            orderByType: request.OrderByType,
            orderByStock: request.OrderByStock,
            page: page,
            size: size);
    }

    public async Task<PaginationResponse?> FindManyPagination(FindManySupplementsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;

        var count = await unitOfWork.SupplementsRepository.CountAsync(
            brand: request.Brand,
            model: request.Model,
            type: Parser.ToEnumOptional<SupplementType>(request.Type),
            stock: request.Stock);

        var pagination = Pagination.Build(request.Page, request.Size, count);

        return pagination;
    }

    public async Task<Supplement?> CreateAsync(CreateSupplementsRequest request)
    {
        var supplement = new Supplement(
            brand: request.Brand,
            model: request.Model,
            type: Parser.ToEnum<SupplementType>(request.Type),
            quantityInStock: request.Stock);
        using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.SupplementsRepository.CreateAsync(supplement);
        await unitOfWork.Commit(transaction);

        return supplement;
    }

    public async Task UpdateAsync(Guid id, UpdateSupplementsRequest request)
    {
        var supplement = await FindOneAsync(id);
        supplement.Update(
            brand: request.Brand,
            model: request.Model,
            type: Parser.ToEnumOptional<SupplementType>(request.Type),
            quantityInStock: request.Stock);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SupplementsRepository.Update(supplement);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var supplement = await FindOneAsync(id);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SupplementsRepository.Delete(supplement);
        await unitOfWork.Commit(transaction);
    }
}
