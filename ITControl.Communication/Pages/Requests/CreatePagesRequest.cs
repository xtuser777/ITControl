using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Pages.Requests;

public class CreatePagesRequest
{
    [RequiredField]
    [StringMinLength(3)]
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string Name { get; set; } = string.Empty;
}