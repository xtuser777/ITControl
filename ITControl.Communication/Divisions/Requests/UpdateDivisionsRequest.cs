using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Divisions.Requests;

public class UpdateDivisionsRequest
{
    [StringMaxLength(100)]
    [Display(Name = "nome")]
    public string? Name { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "id do departamento")]
    public Guid? DepartmentId { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "id do usuário")]
    public Guid? UserId { get; set; }
}