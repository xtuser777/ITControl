using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Auth.Requests;

public class LoginRequest
{
    [RequiredField]
    [StringMinLength(3)]
    [StringMaxLength(50)]
    [Display(Name = "usu�rio")]
    public string Username { get; set; } = string.Empty;

    [RequiredField]
    [StringMinLength(6)]
    [StringMaxLength(12)]
    [Display(Name = "senha")]
    public string Password { get; set; } = string.Empty;
}