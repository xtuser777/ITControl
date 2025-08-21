using ITControl.Communication.Treatments.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface ITreatmentsView
{
    CreateTreatmentsResponse? Create(Treatment? treatment);
    FindOneTreatmentsResponse? FindOne(Treatment? treatment);
    IEnumerable<FindManyTreatmentsResponse> FindMany(IEnumerable<Treatment>? treatments);
}
