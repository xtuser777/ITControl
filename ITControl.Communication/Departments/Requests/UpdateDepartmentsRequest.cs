using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Departments.Requests;

public class UpdateDepartmentsRequest
{
    [StringMaxLength(10)]
    [Display(Name = "sigla")]
    public string? Alias { get; set; }
    
    [StringMaxLength(100)]
    [Display(Name = "nome")]
    public string? Name { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "user")]
    public Guid? UserId { get; set; }
}