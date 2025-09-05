using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Users.Requests;

public class UpdateUsersRequest
{
    [StringMinLength(3)]
    [StringMaxLength(20)]
    [Display(Name = "usuário")]
    public string? Username { get; set; }

    [StringMinLength(6)]
    [StringMaxLength(12)]
    [Display(Name = "senha")]
    public string? Password { get; set; }

    [StringMinLength(3)]
    [StringMaxLength(100)]
    [Display(Name = "nome")]
    public string? Name { get; set; }

    [EmailAddress(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "VALID_EMAIL")]
    [StringMaxLength(100)]
    [Display(Name = "e-mail")]
    public string? Email { get; set; }

    [BoolValue]
    [Display(Name = "ativo")]
    public bool? Active { get; set; }

    [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "POSITIVE_VALUE")]
    [Display(Name = "matrícula")]
    public int? Enrollment { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "cargo")]
    public Guid? PositionId { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "perfil")]
    public Guid? RoleId { get; set; }

    [RequiredField]
    [Display(Name = "equipamentos")]
    public IEnumerable<CreateUsersEquipmentsRequest> Equipments { get; set; } = [];

    [RequiredField]
    [Display(Name = "sistemas")]
    public IEnumerable<CreateUsersSystemsRequest> Systems { get; set; } = [];
}