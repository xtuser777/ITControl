namespace ITControl.Domain.Notifications.Params;

public record FindOneNotificationsRepositoryParams
{
    public Guid Id { get; set; }
    public IncludesNotificationsParams? Includes { get; set; } = null;

    public void Deconstruct(out Guid id, out IncludesNotificationsParams? includes)
    {
        id = Id;
        includes = Includes;
    }
}
