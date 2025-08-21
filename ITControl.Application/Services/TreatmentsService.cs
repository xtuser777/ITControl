using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Application.Utils;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Treatments.Requests;
using ITControl.Domain.Entities;
using ITControl.Domain.Enums;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Services;

public class TreatmentsService(
    IUnitOfWork unitOfWork) : ITreatmentsService
{
    public async Task<Treatment> FindOneAsync(
        Guid id, 
        bool? includeCall = null, 
        bool? includeUser = null)
    {
        return await unitOfWork
            .TreatmentsRepository
            .FindOneAsync(id, includeCall, includeUser) 
            ?? throw new NotFoundException("Atendimento não encontrado");
    }

    public async Task<IEnumerable<Treatment>> FindManyAsync(FindManyTreatmentsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.TreatmentsRepository.FindManyAsync(
            request.Description,
            request.Protocol,
            request.StartedAt,
            request.EndedAt,
            request.StartedIn,
            request.EndedIn,
            Parser.ToEnumOptional<TreatmentStatus>(request.Status),
            Parser.ToEnumOptional<TreatmentType>(request.Type),
            request.Observation,
            request.ExternalProtocol,
            request.CallId,
            request.UserId,
            request.OrderByDescription,
            request.OrderByProtocol,
            request.OrderByStartedAt,
            request.OrderByEndedAt,
            request.OrderByStartedIn,
            request.OrderByEndedIn,
            request.OrderByStatus,
            request.OrderByType,
            request.OrderByObservation,
            request.OrderByExternalProtocol,
            request.OrderByCall,
            request.OrderByUser,
            page,
            size);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyTreatmentsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;

        var count = await unitOfWork.TreatmentsRepository.CountAsync(
            null,
            request.Description,
            request.Protocol,
            request.StartedAt,
            request.EndedAt,
            request.StartedIn,
            request.EndedIn,
            Parser.ToEnumOptional<TreatmentStatus>(request.Status),
            Parser.ToEnumOptional<TreatmentType>(request.Type),
            request.Observation,
            request.ExternalProtocol,
            request.CallId,
            request.UserId);

        var pagination = Pagination.Build(request.Page, request.Size, count);

        return pagination;
    }

    public async Task<Treatment?> CreateAsync(CreateTreatmentsRequest request)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var treatment = new Treatment(
            request.Description,
            Guid.NewGuid().ToString().ToUpper().Replace("-", ""),
            request.StartedAt,
            request.EndedAt,
            request.StartedIn,
            request.EndedIn,
            Parser.ToEnum<TreatmentStatus>(request.Status),
            Parser.ToEnum<TreatmentType>(request.Type),
            request.Observation,
            request.ExternalProtocol,
            request.CallId,
            request.UserId);
        await unitOfWork.TreatmentsRepository.CreateAsync(treatment);
        await unitOfWork.Commit(transaction);

        return treatment;
    }

    public async Task UpdateAsync(Guid id, UpdateTreatmentsRequest request)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var treatment = await FindOneAsync(id);
        treatment.Update(
            request.Description,
            null,
            request.StartedAt,
            request.EndedAt,
            request.StartedIn,
            request.EndedIn,
            Parser.ToEnumOptional<TreatmentStatus>(request.Status),
            Parser.ToEnumOptional<TreatmentType>(request.Type),
            request.Observation,
            request.ExternalProtocol,
            request.CallId,
            request.UserId);
        unitOfWork.TreatmentsRepository.Update(treatment);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var treatment = await FindOneAsync(id);
        unitOfWork.TreatmentsRepository.Delete(treatment);
        await unitOfWork.Commit(transaction);
    }
}
