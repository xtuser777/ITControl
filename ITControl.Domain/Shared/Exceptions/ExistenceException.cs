namespace ITControl.Domain.Shared.Exceptions;

public class ExistenceException(string message): ITControlException(message)
{
}