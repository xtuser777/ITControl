namespace ITControl.Application.Calls.Params;

public record DeleteCallsServiceParams
{
    public Guid Id { get; set; }

    public static implicit operator FindOneCallsServiceParams(
        DeleteCallsServiceParams deleteCallsServiceParams)
        => new ()
        {
            Id = deleteCallsServiceParams.Id,
        };
}