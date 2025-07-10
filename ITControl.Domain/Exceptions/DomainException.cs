namespace ITControl.Domain.Exceptions;

public class DomainException(IEnumerable<string> messages) : ITControlException(string.Join(", ", messages))
{
    public int Code { get; set; } = 400;
}