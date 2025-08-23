using ITControl.Application.Interfaces;
using ITControl.Application.Translators;
using ITControl.Communication.Equipments.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Views;

public class EquipmentsView : IEquipmentsView
{
    public CreateEquipmentsResponse? Create(Equipment? equipment)
    {
        if (equipment == null) return null;

        return new CreateEquipmentsResponse()
        {
            Id = equipment.Id,
        };
    }

    public FindOneEquipmentsResponse? FindOne(Equipment? equipment)
    {
        if (equipment == null) return null;

        return new FindOneEquipmentsResponse()
        {
            Id = equipment.Id,
            Name = equipment.Name,
            Description = equipment.Description,
            Ip = equipment.Ip,
            Mac = equipment.Mac,
            Tag = equipment.Tag,
            Type = new TranslatableField()
            {
                Value = (int)equipment.Type,
                DisplayValue = EquipmentTypeTranslator.ToDisplayValue(equipment.Type),
            },
            Rented = equipment.Rented,
            ContractId = equipment.ContractId,
            Contract = equipment.Contract != null ? new FindOneEquipmentsContractResponse()
            {
                Id = equipment.Contract.Id,
                ObjectName = equipment.Contract.ObjectName
            } : null,
        };
    }

    public IEnumerable<FindManyEquipmentsResponse> FindMany(IEnumerable<Equipment>? equipments)
    {
        if (equipments == null) return [];

        return from equipment in equipments select new FindManyEquipmentsResponse()
        {
            Id = equipment.Id,
            Name = equipment.Name,
            Description = equipment.Description,
            Ip = equipment.Ip,
            Mac = equipment.Mac,
            Tag = equipment.Tag,
            Type = new TranslatableField()
            {
                Value = (int)equipment.Type,
                DisplayValue = EquipmentTypeTranslator.ToDisplayValue(equipment.Type),
            },
            Rented = equipment.Rented,
            ContractId = equipment.ContractId,
        };
    }
}