using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Units.Requests;

public class UpdateUnitsRequest
{
    [StringMaxLength(100)]
    [Display(Name = "nome")]
    public string? Name { get; set; }
    
    [StringMaxLength(10)]
    [Display(Name = "telefone")]
    public string? Phone { get; set; }
    
    [StringMaxLength(8)]
    [Display(Name = "cep")]
    public string? PostalCode { get; set; }
    
    [StringMaxLength(100)]
    [Display(Name = "logradouro")]
    public string? StreetName { get; set; }
    
    [StringMaxLength(50)]
    [Display(Name = "bairro")]
    public string? Neighborhood { get; set; }
    
    [StringMaxLength(5)]
    [Display(Name = "número")]
    public string? AddressNumber { get; set; }
}