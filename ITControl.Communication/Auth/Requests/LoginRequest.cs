using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Auth.Requests;

public class LoginRequest
{
    [Required(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "REQUIRED")]
    [MinLength(
        3, 
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "MIN_LENGTH")]
    [MaxLength(
        50, 
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "MAX_LENGTH")]
    [RegularExpression(
        "^[a-zA-Z0-9_.-]*$", 
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "INVALID_FORMAT")]
    [Display(Name = "usuário")]
    public string Username { get; set; } = string.Empty;

    [Required(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "REQUIRED")]
    [MinLength(
        6, 
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "MIN_LENGTH")]
    [MaxLength(
        12, 
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "senha")]
    public string Password { get; set; } = string.Empty;
}