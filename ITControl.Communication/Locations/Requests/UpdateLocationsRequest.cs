using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Locations.Requests;

public class UpdateLocationsRequest
{
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "descrição")]
    public string? Description { get; set; }

    [GuidValue]
    [Display(Name = "unidade")]
    public Guid? UnitId { get; set; }

    [GuidValue]
    [Display(Name = "usuário")]
    public Guid? UserId { get; set; }

    [GuidValue]
    [Display(Name = "secretaria")]
    public Guid? DepartmentId { get; set; }

    [GuidValue]
    [Display(Name = "divisão")]
    public Guid? DivisionId { get; set; }
}