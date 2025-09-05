using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Notifications.Interfaces;

public interface INotificationsTypesView
{
    IEnumerable<TranslatableField> FindMany();
}
