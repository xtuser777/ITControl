using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Pages.Params;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Pages.Requests;

public record UpdatePagesRequest
{
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }

    public static implicit operator UpdatePageParams(UpdatePagesRequest request) => 
        new() 
        { 
            Name = request.Name 
        };
}