using ITControl.Application.Calls.Interfaces;
using ITControl.Application.Translators;
using ITControl.Communication.Calls.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Calls.Entities;

namespace ITControl.Application.Calls.Views;
public class CallsView : ICallsView
{
    public CreateCallsResponse? Create(Call? call)
    {
        if (call == null) return null;

        return new CreateCallsResponse()
        {
            Id = call.Id
        };
    }

    public FindOneCallsResponse? FindOne(Call? call)
    {
        if (call == null) return null;

        return new FindOneCallsResponse() 
        {
            Id = call.Id,
            Title = call.Title,
            Description = call.Description,
            Reason = new TranslatableField()
            {
                Value = call.Reason.ToString(),
                DisplayValue = CallReasonTranslator.ToDisplayValue(call.Reason)
            },
            CallStatusId = call.CallStatusId,
            UserId = call.UserId,
            LocationId = call.LocationId,
            EquipmentId = call.EquipmentId,
            SystemId = call.SystemId,
            CallStatus = call.CallStatus != null 
                ? new FindOneCallsStatusResponse() 
                {
                    Id = call.CallStatus.Id,
                    Status = new TranslatableField()
                    {
                        Value = call.CallStatus!.Status.ToString(),
                        DisplayValue = CallStatusTranslator.ToDisplayValue(call.CallStatus.Status)
                    },
                    Description = call.CallStatus.Description,
                    CreatedAt = call.CallStatus.CreatedAt,
                    UpdatedAt = call.CallStatus.UpdatedAt,
                } 
                : null,
            User = call.User != null 
                ? new FindOneCallsUserResponse()
                {
                    Id = call.User.Id,
                    Name = call.User.Name,
                }
                : null,
            Location = call.Location != null && call.Location.Unit != null
                ? new FindOneCallsLocationResponse()
                {
                    Id = call.Location.Id,
                    Description = call.Location.Description,
                    Unit = call.Location.Unit.Name,
                    Address = $"{call.Location.Unit.StreetName}, {call.Location.Unit.AddressNumber}, {call.Location.Unit.Neighborhood}",
                    Phone = call.Location.Unit.Phone,
                }
                : null,
            Equipment = call.Equipment != null
                ? new FindOneCallsEquipmentResponse()
                {
                    Id = call.Equipment.Id,
                    Name = call.Equipment.Name,
                    Description = call.Equipment.Description,
                    Ip = call.Equipment.Ip,
                    Mac = call.Equipment.Mac,
                    Type = EquipmentTypeTranslator.ToDisplayValue(call.Equipment.Type)
                }
                : null,
            System = call.System != null 
                ? new FindOneCallsSystemResponse()
                {
                    Id = call.System.Id,
                    Name = call.System.Name,
                    Version = call.System.Version,
                }
                : null
        };
    }

    public IEnumerable<FindManyCallsResponse> FindMany(IEnumerable<Call>? calls)
    {
        if (calls == null) return [];

        return from call in calls
               select
               new FindManyCallsResponse()
               {
                   Id = call.Id,
                   Title = call.Title,
                   Description = call.Description,
                   Reason = new TranslatableField()
                   {
                       Value = call.Reason.ToString(),
                       DisplayValue = CallReasonTranslator.ToDisplayValue(call.Reason)
                   },
                   Status = new TranslatableField()
                   {
                       Value = call.CallStatus!.Status.ToString(),
                       DisplayValue = CallStatusTranslator.ToDisplayValue(call.CallStatus.Status)
                   },
                   UserId = call.UserId,
                   LocationId = call.LocationId,
                   EquipmentId = call.EquipmentId,
                   SystemId = call.SystemId,
               };
    }
}
