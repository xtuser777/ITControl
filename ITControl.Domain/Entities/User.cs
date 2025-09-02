using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class User : Entity
{
    private string _username = string.Empty;
    private string _password = string.Empty;
    private string _email = string.Empty;
    private string _name = string.Empty;
    private bool _active;
    private int _enrollment;
    private Guid _positionId;
    private Guid _roleId;

    public string Username 
    { 
        get => _username; 
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("Username")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 100)
                .Property("Username")
                .LengthMustBeLessThanOrEqualTo(100);
            _username = value;
        }
    }
    public string Password 
    { 
        get => _password; 
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("Password")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length < 6)
                .Property("Password")
                .LengthMustBeGreaterThanOrEqualTo(6);
            DomainExceptionValidation
                .When(value.Length > 128)
                .Property("Password")
                .LengthMustBeLessThanOrEqualTo(128);
            _password = value;
        } 
    }
    public string Email 
    { 
        get => _email; 
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("Email")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 100)
                .Property("Email")
                .LengthMustBeLessThanOrEqualTo(100);
            _email = value;
        } 
    }
    public string Name 
    { 
        get => _name; 
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("Name")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 100)
                .Property("Name")
                .LengthMustBeLessThanOrEqualTo(100);
            _name = value;
        } 
    }
    public bool Active 
    { 
        get => _active; 
        set
        {
            DomainExceptionValidation.When(
                CreatedAt == UpdatedAt && value == false,
                "O usuário deve estar ativo."
            );
            _active = value;
        } 
    }
    public int Enrollment 
    { 
        get => _enrollment; 
        set
        {
            DomainExceptionValidation.When(value <= 0).Property("Enrollment").MustBeGreaterThanOrEqualTo(0);
            _enrollment = value;
        } 
    }
    public Guid PositionId 
    { 
        get => _positionId; 
        set
        {
            DomainExceptionValidation.When(value == Guid.Empty).Property("PositionId").MustNotBeEmpty();
            _positionId = value;
        } 
    }
    public Guid RoleId 
    { 
        get => _roleId; 
        set
        {
            DomainExceptionValidation.When(value == Guid.Empty).Property("RoleId").MustNotBeEmpty();
            _roleId = value;
        } 
    }
    public Position? Position { get; set; }
    public Role? Role { get; set; }
    public ICollection<UserEquipment>? UsersEquipments { get; set; }
    public ICollection<UserSystem>? UsersSystems { get; set; }

    public User(
        string username, 
        string password, 
        string email, 
        string name, 
        int enrollment,
        Guid positionId,
        Guid roleId
    )
    {
        Id = Guid.NewGuid();
        Username = username;
        Password = password;
        Email = email;
        Name = name;
        Active = true; // Default to active
        Enrollment = enrollment;
        PositionId = positionId;
        RoleId = roleId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(
        string? username = null,
        string? password = null,
        string? email = null,
        string? name = null,
        bool? active = null,
        int? enrollment = null,
        Guid? positionId = null,
        Guid? roleId = null
    )
    {
        Username = username ?? Username;
        Password = password ?? Password;
        Email = email ?? Email;
        Name = name ?? Name;
        Active = active ?? Active;
        Enrollment = enrollment ?? Enrollment;
        PositionId = positionId ?? PositionId;
        RoleId = roleId ?? RoleId;
        
        UpdatedAt = DateTime.Now;
    }
}