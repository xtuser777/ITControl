namespace ITControl.Domain.Shared.Exceptions;

public class ITControlException(string message) : SystemException(message)
{
}