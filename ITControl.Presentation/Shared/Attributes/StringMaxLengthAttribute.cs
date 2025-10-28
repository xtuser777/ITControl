using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Shared.Messages;

namespace ITControl.Presentation.Shared.Attributes;

public class StringMaxLengthAttribute : MaxLengthAttribute
{
    public StringMaxLengthAttribute(int maxLength) : base(maxLength)
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.MAX_LENGTH);
    }
}
