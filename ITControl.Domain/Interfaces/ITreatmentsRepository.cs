using ITControl.Domain.Entities;

namespace ITControl.Domain.Interfaces;

public interface ITreatmentsRepository
{
    Task<Treatment?> FindOneAsync(Guid id);
}