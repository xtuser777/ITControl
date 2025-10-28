using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Shared.Messages;

namespace ITControl.Presentation.Shared.Attributes;

public class StringMinLengthAttribute : MinLengthAttribute
{
    public StringMinLengthAttribute(int minLength) : base(minLength)
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.MIN_LENGTH);
    }
}
