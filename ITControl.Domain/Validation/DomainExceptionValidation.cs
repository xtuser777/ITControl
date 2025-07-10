using ITControl.Domain.Exceptions;

namespace ITControl.Domain.Validation;

public abstract class DomainExceptionValidation()
{
    private static readonly List<string> Messages = [];
    
    public static void When(bool hasError, string error)
    {
        if (hasError)
            Messages.Add(error);
    }
    
    public static void Throw()
    {
        if (Messages.Count == 0) return;
        var errors = new List<string>(Messages);
        Messages.Clear();
        throw new DomainException(errors);
    }
}