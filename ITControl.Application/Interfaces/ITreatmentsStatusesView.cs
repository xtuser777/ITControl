using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Interfaces;

public interface ITreatmentsStatusesView
{
    IEnumerable<TranslatableField> FindMany();
}