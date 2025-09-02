using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Divisions.Requests;

public class UpdateDivisionsRequest
{
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    public string? Name { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? UserId { get; set; }
}