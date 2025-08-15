using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class Contract : Entity
{
    private string _object = string.Empty;
    private DateOnly _startedAt;
    private DateOnly? _endedAt;

    public Contract(string objectValue, DateOnly startedAt, DateOnly? endedAt)
    {
        Id = Guid.NewGuid();
        Object = objectValue;
        StartedAt = _startedAt;
        EndedAt = _endedAt;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public string Object
    {
        get => _object;
        set
        {
            DomainExceptionValidation.When(
                string.IsNullOrEmpty(_object),
                "Object don't be null or empty");
            DomainExceptionValidation.When(
                _object.Length > 100,
                "Object length must be less than 100");
            _object = value;
        }
    }

    public DateOnly StartedAt
    {
        get => _startedAt;
        set
        {
            DomainExceptionValidation.When(
                _startedAt > DateOnly.FromDateTime(DateTime.Now),
                "Started at date must be before current date");
            _startedAt = value;
        }
    }

    public DateOnly? EndedAt
    {
        get => _endedAt;
        set
        {
            DomainExceptionValidation.When(
                _endedAt < _startedAt,
                "Ended at date must be after started at date");
            _endedAt = value;
        }
    }

    public IEnumerable<ContractContact>? ContractContacts { get; set; }

    public void Update(string? objectValue = null, DateOnly? startedAt = null, DateOnly? endedAt = null)
    {
        Object = objectValue ?? Object;
        StartedAt = startedAt ?? StartedAt;
        EndedAt = endedAt ?? EndedAt;
        UpdatedAt = DateTime.Now;
    }
}