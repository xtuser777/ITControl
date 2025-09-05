using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Units.Requests;

public class CreateUnitsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = "nome")]
    public string Name { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(10)]
    [Display(Name = "telefone")]
    public string Phone { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(8)]
    [Display(Name = "cep")]
    public string PostalCode { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = "logradouro")]
    public string StreetName { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(50)]
    [Display(Name = "bairro")]
    public string Neighborhood { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(5)]
    [Display(Name = "número")]
    public string AddressNumber { get; set; } = string.Empty;
}