using ITControl.Domain.Notifications.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Application.Notifications.Params;

public record FindManyNotificationsServiceParams
{
    public FindManyNotificationsRepositoryParams FindManyParams { get; init; } = new();
    public OrderByNotificationsRepositoryParams OrderByParams { get; init; } = new();
    public PaginationParams PaginationParams { get; init; } = new();
}