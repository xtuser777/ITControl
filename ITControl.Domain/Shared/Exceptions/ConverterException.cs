namespace ITControl.Domain.Shared.Exceptions;

public class ConverterException(string propertyName, string message) : ITControlException(message)
{
    public string PropertyName { get; } = propertyName;
}
