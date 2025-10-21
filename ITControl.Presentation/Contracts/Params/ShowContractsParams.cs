using ITControl.Application.Contracts.Params;
using ITControl.Domain.Contracts.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Contracts.Params;

public record ShowContractsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    [FromQuery]
    public bool? IncludeContacts { get; set; } = true;

    public static implicit operator FindOneContractsServiceParams(
        ShowContractsParams show)
        => new()
        {
            Id = show.Id,
            Includes = new IncludesContractsParams
            {
                Contacts = show.IncludeContacts,
            }
        };
}
