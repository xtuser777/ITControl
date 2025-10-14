namespace ITControl.Domain.Shared.Exceptions;

public class ConflictException(string message): ITControlException(message)
{
}