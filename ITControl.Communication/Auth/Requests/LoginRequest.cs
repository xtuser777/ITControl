using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Auth.Requests;

public class LoginRequest
{
    [RequiredField]
    [StringMinLength(3)]
    [StringMaxLength(50)]
    [Display(Name = nameof(Username), ResourceType = typeof(DisplayNames))]
    public string Username { get; set; } = string.Empty;

    [RequiredField]
    [StringMinLength(6)]
    [StringMaxLength(12)]
    [Display(Name = nameof(Password), ResourceType = typeof(DisplayNames))]
    public string Password { get; set; } = string.Empty;
}