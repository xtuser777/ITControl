using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Units.Requests;

public class UpdateUnitsRequest
{
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }
    
    [StringMaxLength(10)]
    [Display(Name = nameof(Phone), ResourceType = typeof(DisplayNames))]
    public string? Phone { get; set; }
    
    [StringMaxLength(8)]
    [Display(Name = nameof(PostalCode), ResourceType = typeof(DisplayNames))]
    public string? PostalCode { get; set; }
    
    [StringMaxLength(100)]
    [Display(Name = nameof(StreetName), ResourceType = typeof(DisplayNames))]
    public string? StreetName { get; set; }
    
    [StringMaxLength(50)]
    [Display(Name = nameof(Neighborhood), ResourceType = typeof(DisplayNames))]
    public string? Neighborhood { get; set; }
    
    [StringMaxLength(5)]
    [Display(Name = nameof(AddressNumber), ResourceType = typeof(DisplayNames))]
    public string? AddressNumber { get; set; }
}