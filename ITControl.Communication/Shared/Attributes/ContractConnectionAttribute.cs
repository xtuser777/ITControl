using ITControl.Domain.Contracts.Interfaces;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Shared.Attributes;

public class ContractConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not Guid contractId || contractId == Guid.Empty)
            return ValidationResult.Success;
        var contractsRepository = (IContractsRepository)validationContext.GetService(typeof(IContractsRepository))!;
        var exists = contractsRepository.ExistsAsync(id: contractId).Result;
        if (!exists)
            return new ValidationResult(string.Format(Errors.ConnectionNotFound, validationContext.DisplayName, contractId));

        return ValidationResult.Success;
    }
}
