namespace ITControl.Domain.Shared.Exceptions;

public class NotFoundException(string message) : ITControlException(message)
{
    public int Code { get; } = 404;
}