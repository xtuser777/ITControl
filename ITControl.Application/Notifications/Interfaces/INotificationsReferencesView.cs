using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Notifications.Interfaces;

public interface INotificationsReferencesView
{
    IEnumerable<TranslatableField> FindMany();
}
