using ITControl.Domain.Calls.Entities;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Treatments.Enums;
using ITControl.Domain.Treatments.Params;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Treatments.Entities;

public sealed class Treatment : Entity
{
    public string Description { get; set; } = string.Empty;
    public string Protocol { get; set; } = string.Empty;
    public DateOnly StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public TimeOnly StartedIn { get; set; }
    public TimeOnly? EndedIn { get; set; }
    public TreatmentStatus Status { get; set; }
    public TreatmentType Type { get; set; }
    public string Observation { get; set; } = string.Empty;
    public string ExternalProtocol { get; set; } = string.Empty;
    public Guid CallId { get; set; }
    public Guid UserId { get; set; }

    public Call? Call { get; set; }
    public User? User { get; set; }

    public Treatment() { }

    public Treatment(TreatmentParams @params)
    {
        Id = Guid.NewGuid();
        Description = @params.Description;
        Protocol = @params.Protocol;
        StartedAt = @params.StartedAt;
        EndedAt = @params.EndedAt;
        StartedIn = @params.StartedIn;
        EndedIn = @params.EndedIn;
        Status = @params.Status;
        Type = @params.Type;
        Observation = @params.Observation;
        ExternalProtocol = @params.ExternalProtocol;
        CallId = @params.CallId;
        UserId = @params.UserId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(UpdateTreatmentParams @params)
    {
        Description = @params.Description ?? Description;
        Protocol = @params.Protocol ?? Protocol;
        StartedAt = @params.StartedAt ?? StartedAt;
        EndedAt = @params.EndedAt ?? EndedAt;
        StartedIn = @params.StartedIn ?? StartedIn;
        EndedIn = @params.EndedIn ?? EndedIn;
        Status = @params.Status ?? Status;
        Type = @params.Type ?? Type;
        Observation = @params.Observation ?? Observation;
        ExternalProtocol = @params.ExternalProtocol ?? ExternalProtocol;
        CallId = @params.CallId ?? CallId;
        UserId = @params.UserId ?? UserId;
        UpdatedAt = DateTime.Now;
    }
}