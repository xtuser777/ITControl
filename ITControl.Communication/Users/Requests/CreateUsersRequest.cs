using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Users.Requests;

public class CreateUsersRequest
{
    [RequiredField]
    [StringMinLength(3)]
    [StringMaxLength(20)]
    [Display(Name = "usuário")]
    public string Username { get; set; } = string.Empty;

    [RequiredField]
    [StringMinLength(6)]
    [StringMaxLength(12)]
    [Display(Name = "senha")]
    public string Password { get; set; } = string.Empty;

    [RequiredField]
    [StringMinLength(3)]
    [StringMaxLength(100)]
    [Display(Name = "nome")]
    public string Name { get; set; } = string.Empty;

    [RequiredField]
    [EmailAddress(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "VALID_EMAIL")]
    [StringMaxLength(100)]
    [Display(Name = "e-mail")]
    public string Email { get; set; } = string.Empty;

    [RequiredField]
    [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "POSITIVE_VALUE")]
    [Display(Name = "matrícula")]
    public int Enrollment { get; set; }

    [RequiredField]
    [GuidConverter]
    [GuidValue]
    [Display(Name = "cargo")]
    public Guid PositionId { get; set; }

    [RequiredField]
    [GuidConverter]
    [GuidValue]
    [Display(Name = "perfil")]
    public Guid RoleId { get; set; }

    [RequiredField]
    [Display(Name = "equipamentos")]
    public IEnumerable<CreateUsersEquipmentsRequest> Equipments { get; set; } = [];

    [RequiredField]
    [Display(Name = "sistemas")]
    public IEnumerable<CreateUsersSystemsRequest> Systems { get; set; } = [];
}