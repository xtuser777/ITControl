using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class RolePage : Entity
{
    private Guid _roleId;
    private Guid _pageId;

    public Guid RoleId 
    { 
        get => _roleId; 
        set
        {
            DomainExceptionValidation
                .When(value == Guid.Empty)
                .Property("RoleId")
                .MustNotBeEmpty();
            _roleId = value;
        } 
    }
    public Guid PageId 
    { 
        get => _pageId; 
        set
        {
            DomainExceptionValidation
                .When(value == Guid.Empty)
                .Property("PageId")
                .MustNotBeEmpty();
            _pageId = value;
        } 
    }
    public Role? Role { get; set; }
    public Page? Page { get; set; }

    public RolePage(Guid roleId, Guid pageId)
    {
        Id = Guid.NewGuid();
        RoleId = roleId;
        PageId = pageId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(Guid? roleId, Guid? pageId)
    {
        RoleId = roleId ?? RoleId;
        PageId = pageId ?? PageId;
        UpdatedAt = DateTime.Now;
    }
}