using ITControl.Domain.Shared.Attributes;
using ITControl.Domain.Shared.DisplayValues;

namespace ITControl.Domain.Equipments.Enums;

public enum EquipmentType
{
    [DisplayValue(typeof(EquipmentsTypes), nameof(EquipmentsTypes.Desktop))]
    Desktop = 1,
    [DisplayValue(typeof(EquipmentsTypes), nameof(EquipmentsTypes.Laptop))]
    Laptop = 2,
    [DisplayValue(typeof(EquipmentsTypes), nameof(EquipmentsTypes.Server))]
    Server = 3,
    [DisplayValue(typeof(EquipmentsTypes), nameof(EquipmentsTypes.TimeClock))]
    TimeClock = 4,
    [DisplayValue(typeof(EquipmentsTypes), nameof(EquipmentsTypes.Router))]
    Router = 5,
    [DisplayValue(typeof(EquipmentsTypes), nameof(EquipmentsTypes.Switch))]
    Switch = 6,
    [DisplayValue(typeof(EquipmentsTypes), nameof(EquipmentsTypes.Firewall))]
    Firewall = 7,
    [DisplayValue(typeof(EquipmentsTypes), nameof(EquipmentsTypes.Printer))]
    Printer = 8,
    [DisplayValue(typeof(EquipmentsTypes), nameof(EquipmentsTypes.Cftv))]
    Cftv = 9,
    [DisplayValue(typeof(EquipmentsTypes), nameof(EquipmentsTypes.Pabx))]
    Pabx = 10,
    [DisplayValue(typeof(EquipmentsTypes), nameof(EquipmentsTypes.Other))]
    Other = 11
}