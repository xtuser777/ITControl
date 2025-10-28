using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Notifications.Interfaces;

public interface INotificationsReferencesView
{
    IEnumerable<TranslatableField> FindMany();
}
