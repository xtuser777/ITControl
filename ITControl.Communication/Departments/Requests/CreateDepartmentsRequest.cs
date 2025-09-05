using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Converters;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Departments.Requests;

public class CreateDepartmentsRequest
{
    [RequiredField]
    [StringMaxLength(10)]
    [Display(Name = "sigla")]
    public string Alias { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = "nome")]
    public string Name { get; set; } = string.Empty;

    [RequiredField]
    [GuidConverter]
    [GuidValue]
    [Display(Name = "user")]
    public Guid UserId { get; set; }
}