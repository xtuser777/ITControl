using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Users.Requests;

public class UpdateUsersRequest
{
    [MinLength(3, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MIN_LENGTH")]
    [MaxLength(20, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    public string? Username { get; set; }

    [MinLength(6, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MIN_LENGTH")]
    [MaxLength(12, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    public string? Password { get; set; }

    [MinLength(3, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MIN_LENGTH")]
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    public string? Name { get; set; }

    [EmailAddress(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "VALID_EMAIL")]
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    public string? Email { get; set; }
    public bool? Active { get; set; }

    [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "POSITIVE_VALUE")]
    public int? Enrollment { get; set; }
    public Guid? PositionId { get; set; }
    public Guid? RoleId { get; set; }

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    public IEnumerable<CreateUsersEquipmentsRequest> Equipments { get; set; } = [];

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    public IEnumerable<CreateUsersSystemsRequest> Systems { get; set; } = [];
}