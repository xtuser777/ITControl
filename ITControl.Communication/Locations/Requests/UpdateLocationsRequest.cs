using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Locations.Requests;

public class UpdateLocationsRequest
{
    [StringMaxLength(100)]
    [Display(Name = "descrição")]
    public string? Description { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "unidade")]
    public Guid? UnitId { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "usuário")]
    public Guid? UserId { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "secretaria")]
    public Guid? DepartmentId { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "divisão")]
    public Guid? DivisionId { get; set; }
}