using ITControl.Domain.Positions.Interfaces;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Shared.Attributes;

public class PositionConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not Guid positionId || positionId == Guid.Empty)
        {
            return ValidationResult.Success;
        }
        var positionRepository = (IPositionsRepository)validationContext.GetService(typeof(IPositionsRepository))!;
        var exists = positionRepository.ExistsAsync(id: positionId).GetAwaiter().GetResult();
        if (exists == false)
        {
            return new ValidationResult(string.Format(Errors.ConnectionNotFound, validationContext.DisplayName, positionId));
        }

        return ValidationResult.Success;
    }
}
