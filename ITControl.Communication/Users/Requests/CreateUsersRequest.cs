using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Resources;

namespace ITControl.Communication.Users.Requests;

public class CreateUsersRequest
{
    [RequiredField]
    [StringMinLength(3)]
    [StringMaxLength(20)]
    [Display(Name = nameof(Username), ResourceType = typeof(DisplayNames))]
    public string Username { get; set; } = string.Empty;

    [RequiredField]
    [StringMinLength(6)]
    [StringMaxLength(12)]
    [Display(Name = nameof(Password), ResourceType = typeof(DisplayNames))]
    public string Password { get; set; } = string.Empty;

    [RequiredField]
    [StringMinLength(3)]
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string Name { get; set; } = string.Empty;

    [RequiredField]
    [EmailAddress(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = nameof(Errors.VALID_EMAIL))]
    [StringMaxLength(100)]
    [Display(Name = nameof(Email), ResourceType = typeof(DisplayNames))]
    public string Email { get; set; } = string.Empty;

    [RequiredField]
    [IntegerPositiveValue]
    [Display(Name = nameof(Enrollment), ResourceType = typeof(DisplayNames))]
    public int Enrollment { get; set; }

    [RequiredField]
    [GuidValue]
    [PositionConnection]
    [Display(Name = nameof(PositionId), ResourceType = typeof(DisplayNames))]
    public Guid PositionId { get; set; }

    [RequiredField]
    [GuidValue]
    [RoleConnection]
    [Display(Name = nameof(RoleId), ResourceType = typeof(DisplayNames))]
    public Guid RoleId { get; set; }

    [RequiredField]
    [Display(Name = nameof(Equipments), ResourceType = typeof(DisplayNames))]
    public IEnumerable<CreateUsersEquipmentsRequest> Equipments { get; set; } = [];

    [RequiredField]
    [Display(Name = nameof(Systems), ResourceType = typeof(DisplayNames))]
    public IEnumerable<CreateUsersSystemsRequest> Systems { get; set; } = [];
}