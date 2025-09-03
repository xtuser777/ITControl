using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Contracts.Requests;

public class CreateContractsRequest
{
    [Required(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "REQUIRED")]
    [MaxLength(
        100, 
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "objeto")]
    public string ObjectName { get; set; } = string.Empty;

    [Required(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "REQUIRED")]
    [DataType(
        DataType.Date, 
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "INVALID_DATE")]
    [Display(Name = "início")]
    public DateOnly StartedAt { get; set; }
    
    [DataType(
        DataType.Date, 
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "INVALID_DATE")]
    [Display(Name = "fim")]
    public DateOnly? EndedAt { get; set; }

    [Required(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "REQUIRED")]
    [Display(Name = "contatos")]
    public IEnumerable<CreateContractsContactsRequest> Contacts { get; set; } = [];
}