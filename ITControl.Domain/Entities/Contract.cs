using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class Contract : Entity
{
    private string _objectName = string.Empty;
    private DateOnly _startedAt;
    private DateOnly? _endedAt;

    public Contract(string objectName, DateOnly startedAt, DateOnly? endedAt)
    {
        Id = Guid.NewGuid();
        ObjectName = objectName;
        StartedAt = startedAt;
        EndedAt = endedAt;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public string ObjectName
    {
        get => _objectName;
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("ObjectName")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 100)
                .Property("ObjectName")
                .MustBeLessThanOrEqualTo(100);
            _objectName = value;
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

    public void Update(string? objectName = null, DateOnly? startedAt = null, DateOnly? endedAt = null)
    {
        ObjectName = objectName ?? ObjectName;
        StartedAt = startedAt ?? StartedAt;
        EndedAt = endedAt ?? EndedAt;
        UpdatedAt = DateTime.Now;
    }
}