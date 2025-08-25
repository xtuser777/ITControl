using ITControl.Application.Interfaces;
using ITControl.Application.Translators;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Treatments.Responses;
using ITControl.Domain.Entities;
using ITControl.Infrastructure.Migrations;

namespace ITControl.Application.Views;

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
                       Value = treatment.Status.ToString(),
                       DisplayValue = TreatmentStatusTranslator.ToDisplayName(treatment.Status)
                   },
                   Type = new TranslatableField()
                   {
                       Value = treatment.Type.ToString(),
                       DisplayValue = TreatmentTypeTranslator.ToDisplayName(treatment.Type)
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
                Value = treatment.Status.ToString(),
                DisplayValue = TreatmentStatusTranslator.ToDisplayName(treatment.Status)
            },
            Type = new TranslatableField()
            {
                Value = treatment.Type.ToString(),
                DisplayValue = TreatmentTypeTranslator.ToDisplayName(treatment.Type)
            },
            Observation = treatment.Observation,
            ExternalProtocol = treatment.ExternalProtocol,
            CallId = treatment.CallId,
            UserId = treatment.UserId,
            Call = treatment.Call != null && treatment.Call.Location != null
                ? new FindOneTreatmentsCallResponse()
                {
                    Id = treatment.Call.Id,
                    Title = treatment.Call.Title,
                    Description = treatment.Call.Description,
                    Reason = CallReasonTranslator.ToDisplayValue(treatment.Call.Reason),
                    Location = new FindOneTreatmentsCallLocationResponse()
                    {
                        Id = treatment.Call.Location.Id,
                        Description = treatment.Call.Location.Description,
                        Unit = treatment.Call.Location.Unit?.Name ?? "",
                        Address = $"{treatment.Call.Location.Unit?.StreetName}, {treatment.Call.Location.Unit?.AddressNumber}, {treatment.Call.Location.Unit?.Neighborhood}",
                        Phone = treatment.Call.Location.Unit?.Phone ?? "",
                        Department = treatment.Call.Location.Department?.Alias ?? "",
                        Division = treatment.Call.Location.Division?.Name ?? "",
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
