using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Equipments.Interfaces;
using ITControl.Domain.Equipments.Params;
using ITControl.Domain.Shared.Messages;

namespace ITControl.Presentation.Shared.Attributes;

public class EquipmentConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        if (value is not Guid equipmentId || equipmentId == Guid.Empty)
        {
            return ValidationResult.Success;
        }
        var equipmentsRepository = 
            (IEquipmentsRepository)validationContext
                .GetService(typeof(IEquipmentsRepository))!;
        var exists = equipmentsRepository
            .ExistsAsync(new ExistsEquipmentsParams { Id = equipmentId })
            .GetAwaiter().GetResult();
        return !exists 
            ? new ValidationResult(
                string.Format(
                    Errors.ConnectionNotFound, validationContext.DisplayName, equipmentId)) 
            : ValidationResult.Success;
    }
}
