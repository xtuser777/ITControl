using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Positions.Interfaces;
using ITControl.Domain.Positions.Params;
using ITControl.Domain.Shared.Messages;

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
        var exists = positionRepository.ExistsAsync(new ExistsPositionsParams { Id = positionId }).GetAwaiter().GetResult();
        return !exists ? new ValidationResult(string.Format(Errors.ConnectionNotFound, validationContext.DisplayName, positionId)) : ValidationResult.Success;
    }
}
