using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;

namespace ITControl.Presentation.Auth.Requests;

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

    public static implicit operator (string, string)?(LoginRequest request)
    {
        return (request.Username, request.Password);
    }
}