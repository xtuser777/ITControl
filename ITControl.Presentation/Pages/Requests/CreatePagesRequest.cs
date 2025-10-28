using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Pages.Interfaces;
using ITControl.Domain.Pages.Params;

namespace ITControl.Presentation.Pages.Requests;

public record CreatePagesRequest
{
    [RequiredField]
    [StringMinLength(3)]
    [StringMaxLength(100)]
    [UniqueField<Page>(
        typeof(IPagesRepository), 
        typeof(ExistsPagesParams))]
    [Display(
        Name = nameof(Name), 
        ResourceType = typeof(DisplayNames))]
    public string Name { get; set; } = string.Empty;

    public static implicit operator PageParams(
        CreatePagesRequest request) => new()
    {
        Name = request.Name
    };
}