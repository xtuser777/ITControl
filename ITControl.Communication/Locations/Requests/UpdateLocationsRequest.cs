using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Locations.Requests;

public class UpdateLocationsRequest
{
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    public string? Description { get; set; }
    public Guid? UnitId { get; set; }
    public Guid? UserId { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? DivisionId { get; set; }
}