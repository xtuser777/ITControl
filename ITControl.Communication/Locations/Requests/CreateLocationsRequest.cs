using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Locations.Requests;

public class CreateLocationsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = "descri��o")]
    public string Description { get; set; } = string.Empty;

    [RequiredField]
    [GuidConverter]
    [GuidValue]
    [Display(Name = "unidade")]
    public Guid UnitId { get; set; }

    [RequiredField]
    [GuidConverter]
    [GuidValue]
    [Display(Name = "usu�rio")]
    public Guid UserId { get; set; }

    [RequiredField]
    [GuidConverter]
    [GuidValue]
    [Display(Name = "secretaria")]
    public Guid DepartmentId { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "divis�o")]
    public Guid? DivisionId { get; set; }
}