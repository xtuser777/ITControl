using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Pages.Requests;

public class UpdatePagesRequest
{
    [StringMaxLength(100)]
    [Display(Name = "nome")]
    public string? Name { get; set; }
}