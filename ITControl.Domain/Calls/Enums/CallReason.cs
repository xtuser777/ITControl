using ITControl.Domain.Shared.Attributes;
using ITControl.Domain.Shared.DisplayValues;

namespace ITControl.Domain.Calls.Enums;

public enum CallReason
{
    [DisplayValue(typeof(CallsReasons), nameof(CallsReasons.SystemsUsers))]
    SystemsUsers = 1,
    [DisplayValue(typeof(CallsReasons), nameof(CallsReasons.SystemsUsersPermissions))]
    SystemsUsersPermissions = 2,
    [DisplayValue(typeof(CallsReasons), nameof(CallsReasons.SoftwareInstallation))]
    SoftwareInstallation = 3,
    [DisplayValue(typeof(CallsReasons), nameof(CallsReasons.Network))]
    Network = 4,
    [DisplayValue(typeof(CallsReasons), nameof(CallsReasons.Printer))]
    Printer = 5,
    [DisplayValue(typeof(CallsReasons), nameof(CallsReasons.Other))]
    Other = 6,
}