using ITControl.Domain.KnowledgeBases.Props;

namespace ITControl.Domain.KnowledgeBases.Entities;

public sealed class KnowledgeBase : KnowledgeBaseProps
{
    public KnowledgeBase()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public KnowledgeBase(KnowledgeBaseProps @params)
    {
        Assign(@params);
    }

    public void Update(KnowledgeBaseProps @params)
    {
        AssignUpdate(@params);
    }
}
