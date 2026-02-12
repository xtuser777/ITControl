using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Shared.Messages;
using ITControl.Domain.Supplies.Interfaces;
using ITControl.Domain.Supplies.Params;

namespace ITControl.Presentation.Shared.Attributes;

public class SupplyConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        if (value is not Guid supplyId || supplyId == Guid.Empty)
        {
            return ValidationResult.Success;
        }
        var supplyRepository = 
            (ISuppliesRepository)validationContext
                .GetService(typeof(ISuppliesRepository))!;
        var existsParams = 
            new ExistsSuppliesParams { Id = supplyId };
        var exists = supplyRepository
            .ExistsAsync(existsParams).GetAwaiter().GetResult();
        if (exists == false)
        {
            return new ValidationResult(
                string.Format(
                    Errors.ConnectionNotFound, 
                    validationContext.DisplayName, 
                    supplyId));
        }

        return ValidationResult.Success;
    }
}
