using ITControl.Domain.Notifications.Params;

namespace ITControl.Application.Notifications.Params;

public record FindOneNotificationsServiceParams
{
    public Guid Id { get; init; }
    public IncludesNotificationsParams? Includes { get; init; }

    public static implicit operator FindOneNotificationsRepositoryParams(
        FindOneNotificationsServiceParams findOneParams)
        => new ()
        {
            Id = findOneParams.Id,
            Includes = findOneParams.Includes,
        };
}