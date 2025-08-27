using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Interfaces;

public interface INotificationsTypesView
{
    IEnumerable<TranslatableField> FindMany();
}
