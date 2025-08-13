namespace ITControl.Domain.Exceptions;

public class ExistenceException(string message): ITControlException(message)
{
}