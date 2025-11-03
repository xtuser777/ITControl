using ITControl.Domain.Shared.Extensions;
using ITControl.Domain.Treatments.Entities;
using ITControl.Presentation.Shared.Responses;
using ITControl.Presentation.Treatments.Interfaces;
using ITControl.Presentation.Treatments.Responses;

namespace ITControl.Presentation.Treatments.Views;

public class TreatmentsView : ITreatmentsView
{
    public CreateTreatmentsResponse? Create(Treatment? treatment)
    {
        if (treatment == null) return null;

        return new CreateTreatmentsResponse()
        {
            Id = treatment.Id,
        };
    }

    public IEnumerable<FindManyTreatmentsResponse> FindMany(IEnumerable<Treatment>? treatments)
    {
        if (treatments == null) return [];

        return from treatment in treatments
               select
               new FindManyTreatmentsResponse()
               {
                   Id = treatment.Id,
                   Description = treatment.Description,
                   Protocol = treatment.Protocol,
                   StartedAt = treatment.StartedAt,
                   EndedAt = treatment.EndedAt,
                   StartedIn = treatment.StartedIn,
                   EndedIn = treatment.EndedIn,
                   Status = new TranslatableField()
                   {
                       Value = treatment.Status.ToString()!,
                       DisplayValue = treatment.Status!.GetDisplayValue()
                   },
                   Type = new TranslatableField()
                   {
                       Value = treatment.Type.ToString()!,
                       DisplayValue = treatment.Type!.GetDisplayValue()
                   },
                   Observation = treatment.Observation,
                   ExternalProtocol = treatment.ExternalProtocol,
                   CallId = treatment.CallId,
                   UserId = treatment.UserId,
               };
    }

    public FindOneTreatmentsResponse? FindOne(Treatment? treatment)
    {
        if (treatment == null) return null;

        return new FindOneTreatmentsResponse()
        {
            Id = treatment.Id,
            Description = treatment.Description,
            Protocol = treatment.Protocol,
            StartedAt = treatment.StartedAt,
            EndedAt = treatment.EndedAt,
            StartedIn = treatment.StartedIn,
            EndedIn = treatment.EndedIn,
            Status = new TranslatableField()
            {
                Value = treatment.Status.ToString()!,
                DisplayValue = treatment.Status!.GetDisplayValue()
            },
            Type = new TranslatableField()
            {
                Value = treatment.Type.ToString()!,
                DisplayValue = treatment.Type!.GetDisplayValue()
            },
            Observation = treatment.Observation,
            ExternalProtocol = treatment.ExternalProtocol,
            CallId = treatment.CallId,
            UserId = treatment.UserId,
            Call = treatment.Call != null
                ? new FindOneTreatmentsCallResponse()
                {
                    Id = treatment.Call.Id,
                    Title = treatment.Call.Title,
                    Description = treatment.Call.Description,
                    Reason = treatment.Call.Reason!.GetDisplayValue(),
                    User = new ()
                    {
                        Id = treatment.Call.User!.Id,
                        Name = treatment.Call.User!.Name,
                        Unit = treatment.Call.User!.Unit?.Name ?? "",
                        Address = $"{treatment.Call.User!.Unit?.StreetName}, {treatment.Call.User!.Unit?.AddressNumber}, {treatment.Call.User!.Unit?.Neighborhood}",
                        Phone = treatment.Call.User!.Unit?.Phone ?? "",
                        Department = treatment.Call.User!.Department?.Alias ?? "",
                        Division = treatment.Call.User!.Division?.Name ?? "",
                    }
                }
                : null,
            User = treatment.User != null
                ? new FindOneTreatmentsUserResponse()
                {
                    Id = treatment.User.Id,
                    Name = treatment.User.Name,
                }
                : null,
        };
    }
}
