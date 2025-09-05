using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Divisions.Requests;

public class CreateDivisionsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = "nome")]
    public string Name { get; set; } = string.Empty;

    [RequiredField]
    [GuidConverter]
    [GuidValue]
    [Display(Name = "id do departamento")]
    public Guid DepartmentId { get; set; }

    [RequiredField]
    [GuidConverter]
    [GuidValue]
    [Display(Name = "id do usuário")]
    public Guid UserId { get; set; }
}