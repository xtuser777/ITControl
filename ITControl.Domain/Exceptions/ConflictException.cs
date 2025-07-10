namespace ITControl.Domain.Exceptions;

public class ConflictException(string message): ITControlException(message)
{
}