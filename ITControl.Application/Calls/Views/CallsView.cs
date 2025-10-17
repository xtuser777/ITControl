using ITControl.Application.Calls.Interfaces;
using ITControl.Communication.Calls.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Calls.Entities;
using ITControl.Domain.Shared.Extensions;

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
                DisplayValue = call.Reason.GetDisplayValue()
            },
            CallStatusId = call.CallStatusId,
            UserId = call.UserId,
            EquipmentId = call.EquipmentId,
            SystemId = call.SystemId,
            CallStatus = call.CallStatus != null 
                ? new FindOneCallsStatusResponse() 
                {
                    Id = call.CallStatus.Id,
                    Status = new TranslatableField()
                    {
                        Value = call.CallStatus!.Status.ToString(),
                        DisplayValue = call.CallStatus.Status.GetDisplayValue()
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
                    Phone = call.User.Unit!.Phone,
                    Address = $"{call.User.Unit.StreetName}, {call.User.Unit.AddressNumber}, {call.User.Unit.Neighborhood}",
                    Position = call.User.Position!.Name,
                    Unit = call.User.Unit!.Name,
                    Department = call.User.Department!.Alias,
                    Division = call.User.Division!.Name,
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
                    Type = call.Equipment.Type.GetDisplayValue()
                }
                : null,
            System = call.System != null 
                ? new FindOneCallsSystemResponse()
                {
                    Id = call.System.Id,
                    Name = call.System.Name,
                    Version = call.System.Version,
                    Own = call.System.Own ? "SIM" : "NÃO",
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
                       DisplayValue = call.Reason.GetDisplayValue()
                   },
                   Status = new TranslatableField()
                   {
                       Value = call.CallStatus!.Status.ToString(),
                       DisplayValue = call.CallStatus.Status.GetDisplayValue()
                   },
                   UserId = call.UserId,
                   EquipmentId = call.EquipmentId,
                   SystemId = call.SystemId,
               };
    }
}
