using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Notifications.Interfaces;

public interface INotificationsTypesView
{
    IEnumerable<TranslatableField> FindMany();
}
