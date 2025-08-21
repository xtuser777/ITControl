using ITControl.Domain.Exceptions;

namespace ITControl.Domain.Validation;

public class DomainExceptionValidation
{
    private static readonly List<string> Messages = [];

    private bool _hasError = false;
    private string _property = string.Empty;

    private DomainExceptionValidation(bool hasError)
    {
        _hasError = hasError;
    }
    
    public static void When(bool hasError, string error)
    {
        if (hasError)
            Messages.Add(error);
    }
    
    public static DomainExceptionValidation When(bool hasError)
    {
        var validation = new DomainExceptionValidation(hasError);
        
        return validation;
    }

    public DomainExceptionValidation Property(string property)
    {
        _property = property;
        return this;
    }

    public void MustNotBeEmpty()
    {
        if (_hasError)
            throw new BadRequestException($"the field {_property} must not be empty.");
    }

    public void MustNotBeNull()
    {
        if (_hasError)
            throw new BadRequestException($"the field {_property} must not be null.");
    }

    public void MustBeTrue()
    {
        if (_hasError)
            throw new BadRequestException($"the field {_property} must be true.");
    }

    public void MustBeAUuid()
    {
        if (_hasError)
            throw new BadRequestException($"the field {_property} must be a valid UUID.");
    }

    public void LengthMustBeLessThanOrEqualTo(int value)
    {
        if (_hasError)
            throw new BadRequestException($"the field {_property} length must be less than or equal to {value}.");
    }

    public void LengthMustBeGreaterThanOrEqualTo(int value)
    {
        if (_hasError)
            throw new BadRequestException($"the field {_property} length must be greater than or equal to {value}.");
    }

    public void MustBeLessThanOrEqualTo(int value)
    {
        if (_hasError)
            throw new BadRequestException($"the field {_property} must be less than or equal to {value}.");
    }

    public void MustBeLessThanOrEqualTo(decimal value)
    {
        if (_hasError)
            throw new BadRequestException($"the field {_property} must be less than or equal to {value}.");
    }

    public void MustBeGreaterThanOrEqualTo(int value)
    {
        if (_hasError)
            throw new BadRequestException($"the field {_property} must be greater than or equal to {value}.");
    }

    public void MustBeGreaterThanOrEqualTo(decimal value)
    {
        if (_hasError)
            throw new BadRequestException($"the field {_property} must be greater than or equal to {value}.");
    }

    public void MustBeGreaterThan(int value)
    {
        if (_hasError)
            throw new BadRequestException($"the field {_property} must be greater than {value}.");
    }

    public void DateMustNotBeGreaterThanCurrent()
    {
        if (_hasError)
            throw new BadRequestException($"the field {_property} must not be greater than current date.");
    }

    public void DateMustNotBeLessThan(DateOnly value)
    {
        if (_hasError)
            throw new BadRequestException($"the field {_property} must not be less than {value}.");
    }

    public void TimeMustNotBeGreaterThanCurrent()
    {
        if (_hasError)
            throw new BadRequestException($"the field {_property} must not be greater than current time.");
    }

    public void TimeMustNotBeLessThan(TimeOnly value)
    {
        if (_hasError)
            throw new BadRequestException($"the field {_property} must not be less than {value}.");
    }

    public void MustBeGreaterThan(decimal value)
    {
        if (_hasError)
            throw new BadRequestException($"the field {_property} must be greater than {value}.");
    }

    public void MustBeAOneOfFollowingValues(string enumName)
    {
        if (_hasError)
            throw new BadRequestException($"the field {_property} values must be one of {enumName}.");
    }
    
    public static void Throw()
    {
        if (Messages.Count == 0) return;
        var errors = new List<string>(Messages);
        Messages.Clear();
        throw new DomainException(errors);
    }
}