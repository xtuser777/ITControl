using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Users.Requests;

public class CreateUsersRequest
{
    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [MinLength(3, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MIN_LENGTH")]
    [MaxLength(20, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "usuário")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [MinLength(6, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MIN_LENGTH")]
    [MaxLength(12, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "senha")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [MinLength(3, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MIN_LENGTH")]
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "nome")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [EmailAddress(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "VALID_EMAIL")]
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "e-mail")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "POSITIVE_VALUE")]
    [Display(Name = "matrícula")]
    public int Enrollment { get; set; }

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [GuidValue]
    [Display(Name = "cargo")]
    public Guid PositionId { get; set; }

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [GuidValue]
    [Display(Name = "perfil")]
    public Guid RoleId { get; set; }

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [Display(Name = "equipamentos")]
    public IEnumerable<CreateUsersEquipmentsRequest> Equipments { get; set; } = [];

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [Display(Name = "sistemas")]
    public IEnumerable<CreateUsersSystemsRequest> Systems { get; set; } = [];
}