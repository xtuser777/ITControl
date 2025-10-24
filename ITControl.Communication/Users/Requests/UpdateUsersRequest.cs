using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Shared.Messages;
using ITControl.Domain.Users.Entities;
using ITControl.Domain.Users.Interfaces;
using ITControl.Domain.Users.Params;

namespace ITControl.Communication.Users.Requests;

public class UpdateUsersRequest
{
    [StringMinLength(3)]
    [StringMaxLength(20)]
    [UniqueField<User>(typeof(IUsersRepository), typeof(ExclusiveUsersParams))]
    [Display(Name = nameof(Username), ResourceType = typeof(DisplayNames))]
    public string? Username { get; set; }

    [StringMinLength(6)]
    [StringMaxLength(12)]
    [Display(Name = nameof(Password), ResourceType = typeof(DisplayNames))]
    public string? Password { get; set; }

    [StringMinLength(3)]
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }

    [EmailAddress(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = nameof(Errors.VALID_EMAIL))]
    [StringMaxLength(100)]
    [UniqueField<User>(typeof(IUsersRepository), typeof(ExclusiveUsersParams))]
    [Display(Name = nameof(Email), ResourceType = typeof(DisplayNames))]
    public string? Email { get; set; }

    [StringLength(11)]
    [DocumentValue]
    [UniqueField<User>(typeof(IUsersRepository), typeof(ExclusiveUsersParams))]
    [Display(Name = nameof(Document), ResourceType = typeof(DisplayNames))]
    public string? Document { get; set; } 

    [BoolValue]
    [Display(Name = nameof(Active), ResourceType = typeof(DisplayNames))]
    public bool? Active { get; set; }

    [IntegerPositiveValue]
    [Display(Name = nameof(Enrollment), ResourceType = typeof(DisplayNames))]
    public int? Enrollment { get; set; }

    [GuidValue]
    [PositionConnection]
    [Display(Name = nameof(PositionId), ResourceType = typeof(DisplayNames))]
    public Guid? PositionId { get; set; }

    [GuidValue]
    [RoleConnection]
    [Display(Name = nameof(RoleId), ResourceType = typeof(DisplayNames))]
    public Guid? RoleId { get; set; }

    [GuidValue]
    [UnitConnection]
    [Display(Name = nameof(UnitId), ResourceType = typeof(DisplayNames))]
    public Guid? UnitId { get; set; }

    [GuidValue]
    [DepartmentConnection]
    [Display(Name = nameof(DepartmentId), ResourceType = typeof(DisplayNames))]
    public Guid? DepartmentId { get; set; }

    [GuidValue]
    [DivisionConnection]
    [Display(Name = nameof(DivisionId), ResourceType = typeof(DisplayNames))]
    public Guid? DivisionId { get; set; }

    [RequiredField]
    [Display(Name = nameof(Equipments), ResourceType = typeof(DisplayNames))]
    public IEnumerable<CreateUsersEquipmentsRequest> Equipments { get; set; } = [];

    [RequiredField]
    [Display(Name = nameof(Systems), ResourceType = typeof(DisplayNames))]
    public IEnumerable<CreateUsersSystemsRequest> Systems { get; set; } = [];

    public static implicit operator UpdateUserParams(
        UpdateUsersRequest request) => new()
    {
        Username = request.Username,
        Name = request.Name,
        Email = request.Email,
        Password = request.Password,
        Document = request.Document,
        Enrollment = request.Enrollment,
        Active = request.Active,
        PositionId = request.PositionId,
        RoleId = request.RoleId,
        UnitId = request.UnitId,
        DepartmentId = request.DepartmentId,
        DivisionId = request.DivisionId,
    };
}