namespace ITControl.Domain.Exceptions;

public class ITControlException(string message) : SystemException(message)
{
}