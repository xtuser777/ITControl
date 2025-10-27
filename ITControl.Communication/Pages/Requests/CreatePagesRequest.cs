using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Pages.Interfaces;
using ITControl.Domain.Pages.Params;

namespace ITControl.Communication.Pages.Requests;

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