using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Positions.Requests;

public class UpdatePositionsRequest
{
    [StringMaxLength(100)]
    [Display(Name = "descri��o")]
    public string? Description { get; set; }
}