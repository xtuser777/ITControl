using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Departments.Requests;

public class UpdateDepartmentsRequest
{
    [MaxLength(10, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    public string? Alias { get; set; }
    
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    public string? Name { get; set; }
    public Guid? UserId { get; set; }
}