using ITControl.Domain.Locations.Interfaces;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Shared.Attributes;

public class LocationConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not Guid locationId || locationId == Guid.Empty)
        {
            return ValidationResult.Success;
        }
        var locationsRepository = (ILocationsRepository)validationContext.GetService(typeof(ILocationsRepository))!;
        bool locationExists = locationsRepository.ExistsAsync(id: locationId).Result;
        if (!locationExists)
        {
            return new ValidationResult(string.Format(Errors.ConnectionNotFound, validationContext.DisplayName, locationId));
        }

        return ValidationResult.Success;
    }
}
