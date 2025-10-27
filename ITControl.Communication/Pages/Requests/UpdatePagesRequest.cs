using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Pages.Interfaces;
using ITControl.Domain.Pages.Params;

namespace ITControl.Communication.Pages.Requests;

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