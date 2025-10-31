using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Pages.Interfaces;
using ITControl.Domain.Pages.Params;
using ITControl.Domain.Pages.Props;

namespace ITControl.Presentation.Pages.Requests;

public record UpdatePagesRequest
{
    [StringMinLength(1)]
    [StringMaxLength(100)]
    [UniqueField<Page>(
        typeof(IPagesRepository),
        typeof(ExclusivePagesParams))]
    [Display(
        Name = nameof(Name),
        ResourceType = typeof(DisplayNames))]
    public string Name { get; set; } = null!;

    public static implicit operator PageProps(
        UpdatePagesRequest request) => 
        new() 
        { 
            Name = request.Name 
        };
}