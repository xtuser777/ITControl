using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Shared.Attributes;

public class StringMaxLengthAttribute : MaxLengthAttribute
{
    public StringMaxLengthAttribute(int maxLength) : base(maxLength)
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.MAX_LENGTH);
    }
}
