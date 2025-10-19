using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Shared.Messages;

namespace ITControl.Communication.Shared.Attributes;

public class RequiredFieldAttribute : RequiredAttribute
{
    public RequiredFieldAttribute()
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.REQUIRED);
    }
}
