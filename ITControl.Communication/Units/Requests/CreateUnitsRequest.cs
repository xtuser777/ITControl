using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Units.Params;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Units.Requests;

public record CreateUnitsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string Name { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(10)]
    [Display(Name = nameof(Phone), ResourceType = typeof(DisplayNames))]
    public string Phone { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(8)]
    [Display(Name = nameof(PostalCode), ResourceType = typeof(DisplayNames))]
    public string PostalCode { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = nameof(StreetName), ResourceType = typeof(DisplayNames))]
    public string StreetName { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(50)]
    [Display(Name = nameof(Neighborhood), ResourceType = typeof(DisplayNames))]
    public string Neighborhood { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(5)]
    [Display(Name = nameof(AddressNumber), ResourceType = typeof(DisplayNames))]
    public string AddressNumber { get; set; } = string.Empty;

    public static implicit operator UnitParams(CreateUnitsRequest request) => new()
    {
        Name = request.Name,
        Phone = request.Phone,
        PostalCode = request.PostalCode,
        StreetName = request.StreetName,
        Neighborhood = request.Neighborhood,
        AddressNumber = request.AddressNumber
    };
}