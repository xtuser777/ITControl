using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Shared.Messages;
using ITControl.Domain.Users.Entities;
using ITControl.Domain.Users.Interfaces;
using ITControl.Domain.Users.Params;

namespace ITControl.Communication.Users.Requests;

public class CreateUsersRequest
{
    [RequiredField]
    [StringMinLength(3)]
    [StringMaxLength(20)]
    [UniqueField(typeof(IUsersRepository), typeof(ExistsUsersParams))]
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
    [UniqueField(typeof(IUsersRepository), typeof(ExistsUsersParams))]
    [Display(Name = nameof(Email), ResourceType = typeof(DisplayNames))]
    public string Email { get; set; } = string.Empty;

    [RequiredField]
    [StringLength(11)]
    [DocumentValue]
    [UniqueField(typeof(IUsersRepository), typeof(ExistsUsersParams))]
    [Display(Name = nameof(Document), ResourceType = typeof(DisplayNames))]
    public string Document { get; set; } = string.Empty;

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
    [GuidValue]
    [UnitConnection]
    [Display(Name = nameof(UnitId), ResourceType = typeof(DisplayNames))]
    public Guid UnitId { get; set; }

    [RequiredField]
    [GuidValue]
    [DepartmentConnection]
    [Display(Name = nameof(DepartmentId), ResourceType = typeof(DisplayNames))]
    public Guid DepartmentId { get; set; }

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

    public static implicit operator UserParams(
        CreateUsersRequest request) =>
        new ()
        {
            Username = request.Username,
            Password = request.Password,
            Name = request.Name,
            Email = request.Email,
            Document = request.Document,
            Enrollment = request.Enrollment,
            PositionId = request.PositionId,
            RoleId = request.RoleId,
            UnitId = request.UnitId,
            DepartmentId = request.DepartmentId,
            DivisionId = request.DivisionId,
            UsersEquipments = request.Equipments
                .Select(e => new UserEquipment(
                    Guid.Empty, e.EquipmentId, e.StartedAt, e.EndedAt))
                .ToList(),
            UsersSystems = request.Systems
                .Select(s => new UserSystem(
                    Guid.Empty, s.SystemId))
                .ToList(),
        };
}