using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Pages.Interfaces;
using ITControl.Domain.Pages.Params;

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
    public string? Name { get; set; }

    public static implicit operator UpdatePageParams(
        UpdatePagesRequest request) => 
        new() 
        { 
            Name = request.Name 
        };
}