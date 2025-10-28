using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Contracts.Interfaces;
using ITControl.Domain.Contracts.Params;
using ITControl.Domain.Shared.Messages;

namespace ITControl.Presentation.Shared.Attributes;

public class ContractConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not Guid contractId || contractId == Guid.Empty)
            return ValidationResult.Success;
        var contractsRepository = 
            (IContractsRepository)validationContext
            .GetService(typeof(IContractsRepository))!;
        var exists = contractsRepository
            .ExistsAsync(new ExistsContractsParams { Id = contractId })
            .GetAwaiter().GetResult();
        if (!exists)
            return new ValidationResult(
                string.Format(
                    Errors.ConnectionNotFound, 
                    validationContext.DisplayName, 
                    contractId));

        return ValidationResult.Success;
    }
}
