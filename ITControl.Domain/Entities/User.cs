using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class User(
    string username,
    string password,
    string email,
    string name,
    bool active,
    int enrollment)
    : Entity
{
    public string Username { get; private set; } = username;
    public string Password { get; private set; } = password;
    public string Email { get; private set; } = email;
    public string Name { get; private set; } = name;
    public bool Active { get; private set; } = active;
    public int Enrollment { get; private set; } = enrollment;
    public Guid PositionId { get; set; }
    public Position? Position { get; set; }
    public Guid RoleId { get; set; }
    public Role? Role { get; set; }

    public static User Create(
        string username, 
        string password, 
        string email, 
        string name, 
        int enrollment,
        Guid positionId,
        Guid roleId
    )
    {
        var user = new User(
            username: username,
            password: password,
            email: email,
            name: name,
            active: false,
            enrollment: enrollment
        )
        {
            Id = Guid.NewGuid(),
            PositionId = positionId,
            RoleId = roleId,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        user.Validate();
        
        return user;
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
        
        Validate();
    }

    private void Validate()
    {
        DomainExceptionValidation.When(
            string.IsNullOrEmpty(Username),
            "Nome de usuário não pode estar vazio."
        );
        
        DomainExceptionValidation.When(
            string.IsNullOrEmpty(Password),
            "A senha não pode estar vazio."
        );
        
        DomainExceptionValidation.When(
            string.IsNullOrEmpty(Email),
            "O E-mail não pode estar vazio."
        );
        
        DomainExceptionValidation.When(
            string.IsNullOrEmpty(Name),
            "O nome do usuário não pode estar vazio."
        );
        
        DomainExceptionValidation.When(
            Enrollment <= 0,
            "O número de matrícula deve ser maior que zero."
        );
        
        DomainExceptionValidation.When(
            PositionId == Guid.Empty,
            "O id do cargo não pode estar vazio."
        );
    }
}