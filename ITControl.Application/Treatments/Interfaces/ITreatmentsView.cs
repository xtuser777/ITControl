using ITControl.Communication.Treatments.Responses;
using ITControl.Domain.Treatments.Entities;

namespace ITControl.Application.Treatments.Interfaces;

public interface ITreatmentsView
{
    CreateTreatmentsResponse? Create(Treatment? treatment);
    FindOneTreatmentsResponse? FindOne(Treatment? treatment);
    IEnumerable<FindManyTreatmentsResponse> FindMany(IEnumerable<Treatment>? treatments);
}
