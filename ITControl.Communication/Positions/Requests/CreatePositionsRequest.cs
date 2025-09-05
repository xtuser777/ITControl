using ITControl.Communication.Shared.Attributes;
using System.ComponentModel;

namespace ITControl.Communication.Positions.Requests;

public class CreatePositionsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [DisplayName("descri��o")]
    public string Description { get; set; } = string.Empty;
}