using ITControl.Domain.Shared.Messages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Positions.Requests;

public class CreatePositionsRequest
{
    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [DisplayName("descrição")]
    public string Description { get; set; } = string.Empty;
}