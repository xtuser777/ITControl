using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Interfaces;

public interface ITreatmentsTypesView
{
    IEnumerable<TranslatableField> FindMany();
}