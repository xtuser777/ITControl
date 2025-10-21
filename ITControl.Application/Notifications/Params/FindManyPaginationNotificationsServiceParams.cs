using ITControl.Domain.Notifications.Params;

namespace ITControl.Application.Notifications.Params;

public record FindManyPaginationNotificationsServiceParams
{
    public CountNotificationsRepositoryParams  CountParams { get; init; } = new();
    public string? Page { get; init; } = null;
    public string? Size { get; init; } = null;

    public void Deconstruct(out string? page, out string? size)
    {
        page = Page;
        size = Size;
    }
}