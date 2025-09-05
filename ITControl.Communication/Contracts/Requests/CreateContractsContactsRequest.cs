using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Contracts.Requests;

public class CreateContractsContactsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = "nome")]
    public string Name { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(100)]
    [EmailAddress(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "VALID_EMAIL")]
    [Display(Name = "e-mail")]
    public string Email { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(10)]
    [Display(Name = "telefone")]
    public string Phone { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(11)]
    [Display(Name = "celular")]
    public string Cellphone { get; set; } = string.Empty;
}