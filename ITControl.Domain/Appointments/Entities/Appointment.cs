using ITControl.Domain.Appointments.Props;

namespace ITControl.Domain.Appointments.Entities;

public sealed class Appointment : AppointmentProps
{
    public Appointment()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Appointment(AppointmentProps @params)
    {
        Assign(@params);
    }

    public void Update(AppointmentProps @params)
    {
        AssignUpdate(@params);
    }
}