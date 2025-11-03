using ITControl.Domain.Treatments.Props;

namespace ITControl.Domain.Treatments.Entities;

public sealed class Treatment : TreatmentProps
{
    public Treatment()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Treatment(TreatmentProps @params)
    {
        Assign(@params);
    }

    public void Update(TreatmentProps @params)
    {
        AssignUpdate(@params);
    }
}