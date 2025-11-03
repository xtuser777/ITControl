using ITControl.Domain.Supplements.Props;

namespace ITControl.Domain.Supplements.Entities;

public sealed class Supplement : SupplementProps
{
    public Supplement()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Supplement(SupplementProps @params)
    {
        Assign(@params);
    }

    public void Update(SupplementProps @params)
    {
        AssignUpdate(@params);
    }
}
