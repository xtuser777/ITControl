namespace ITControl.Domain.Exceptions;

public class BadRequestException(string message) : ITControlException(message)
{
    public int Code { get; set; } = 400;
}