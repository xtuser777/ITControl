using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Pages.Params;

namespace ITControl.Communication.Pages.Requests;

public class UpdatePagesRequest
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