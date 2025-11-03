using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Domain.Units.Params;
using ITControl.Domain.Units.Props;

namespace ITControl.Presentation.Units.Requests;

public record UpdateUnitsRequest
{
    [StringMinLength(1)]
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }
    
    [StringMinLength(10)]
    [StringMaxLength(10)]
    [Display(Name = nameof(Phone), ResourceType = typeof(DisplayNames))]
    public string? Phone { get; set; }
    
    [StringMinLength(8)]
    [StringMaxLength(8)]
    [Display(Name = nameof(PostalCode), ResourceType = typeof(DisplayNames))]
    public string? PostalCode { get; set; }
    
    [StringMinLength(1)]
    [StringMaxLength(100)]
    [Display(Name = nameof(StreetName), ResourceType = typeof(DisplayNames))]
    public string? StreetName { get; set; }
    
    [StringMinLength(1)]
    [StringMaxLength(50)]
    [Display(Name = nameof(Neighborhood), ResourceType = typeof(DisplayNames))]
    public string? Neighborhood { get; set; }
    
    [StringMinLength(1)]
    [StringMaxLength(5)]
    [Display(Name = nameof(AddressNumber), ResourceType = typeof(DisplayNames))]
    public string? AddressNumber { get; set; }

    public static implicit operator UnitProps(
        UpdateUnitsRequest request) => new()
    {
        Name = request.Name,
        Phone = request.Phone,
        PostalCode = request.PostalCode,
        StreetName = request.StreetName,
        Neighborhood = request.Neighborhood,
        AddressNumber = request.AddressNumber
    };
}