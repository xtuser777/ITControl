using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Contracts.Requests;

public class CreateContractsContactsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string Name { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(100)]
    [EmailAddress(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = nameof(Errors.VALID_EMAIL))]
    [Display(Name = nameof(Email), ResourceType = typeof(DisplayNames))]
    public string Email { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(10)]
    [Display(Name = nameof(Phone), ResourceType = typeof(DisplayNames))]
    public string Phone { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(11)]
    [Display(Name = nameof(Cellphone), ResourceType = typeof(DisplayNames))]
    public string Cellphone { get; set; } = string.Empty;
}