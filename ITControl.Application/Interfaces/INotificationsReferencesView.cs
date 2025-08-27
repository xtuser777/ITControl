using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Interfaces;

public interface INotificationsReferencesView
{
    IEnumerable<TranslatableField> FindMany();
}
