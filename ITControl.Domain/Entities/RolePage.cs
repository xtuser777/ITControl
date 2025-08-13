using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public class RolePage : Entity
{
    public Guid RoleId { get; set; }
    public Guid PageId { get; set; }

    public Role? Role { get; set; }
    public Page? Page { get; set; }

    public static RolePage Create(Guid roleId, Guid pageId)
    {
        var rolePage = new RolePage()
        {
            Id = Guid.NewGuid(),
            RoleId = roleId,
            PageId = pageId,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };
        
        rolePage.Validate();
        
        return rolePage;
    }

    public static RolePage Load(Guid id, Guid roleId, Guid pageId, DateTime createdAt, DateTime updatedAt)
    {
        var rolePage = new RolePage()
        {
            Id = id,
            RoleId = roleId,
            PageId = pageId,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt,
        };
        
        rolePage.Validate();
        
        return rolePage;
    }

    public void Update(Guid? roleId, Guid? pageId)
    {
        RoleId = roleId ?? RoleId;
        PageId = pageId ?? PageId;
        
        UpdatedAt = DateTime.Now;
        
        Validate();
    }

    private void Validate()
    {
        DomainExceptionValidation.When(
            RoleId == Guid.Empty, 
            "RoleId cannot be empty");
        
        DomainExceptionValidation.When(
            PageId == Guid.Empty, 
            "PageId cannot be empty");
        
        DomainExceptionValidation.Throw();
    }
}