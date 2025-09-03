using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Units.Requests;

public class UpdateUnitsRequest
{
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "nome")]
    public string? Name { get; set; }
    
    [MaxLength(10, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "telefone")]
    public string? Phone { get; set; }
    
    [MaxLength(8, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "cep")]
    public string? PostalCode { get; set; }
    
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "logradouro")]
    public string? StreetName { get; set; }
    
    [MaxLength(50, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "bairro")]
    public string? Neighborhood { get; set; }
    
    [MaxLength(5, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "número")]
    public string? AddressNumber { get; set; }
}