using ITControl.Domain.Pages.Interfaces;
using ITControl.Domain.Shared.Messages;
using ITControl.Infrastructure.Pages.Repositories;
using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Pages.Params;

namespace ITControl.Communication.Shared.Attributes;

public class PageConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not Guid pageId || pageId == Guid.Empty)
        {
            return ValidationResult.Success;
        }
        var pagesRepository = (IPagesRepository)validationContext.GetService(typeof(IPagesRepository))!;
        bool pageExists = pagesRepository.ExistsAsync(new ExistsPagesRepositoryParams() 
        { 
            Id = pageId 
        }).GetAwaiter().GetResult();
        return !pageExists ? new ValidationResult(string.Format(Errors.ConnectionNotFound, validationContext.DisplayName, pageId)) : ValidationResult.Success;
    }
}
