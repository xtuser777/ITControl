using ITControl.Domain.Pages.Interfaces;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

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
        bool pageExists = pagesRepository.ExistsAsync(id: pageId).GetAwaiter().GetResult();
        if (!pageExists)
        {
            return new ValidationResult(string.Format(Errors.ConnectionNotFound, validationContext.DisplayName, pageId));
        }

        return ValidationResult.Success;
    }
}
