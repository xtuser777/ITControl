using ITControl.Domain.Treatments.Entities;
using ITControl.Presentation.Treatments.Responses;

namespace ITControl.Presentation.Treatments.Interfaces;

public interface ITreatmentsView
{
    CreateTreatmentsResponse? Create(Treatment? treatment);
    FindOneTreatmentsResponse? FindOne(Treatment? treatment);
    IEnumerable<FindManyTreatmentsResponse> FindMany(IEnumerable<Treatment>? treatments);
}
