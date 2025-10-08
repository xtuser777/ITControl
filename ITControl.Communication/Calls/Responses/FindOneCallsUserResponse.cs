namespace ITControl.Communication.Calls.Responses;
public class FindOneCallsUserResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public FindOneCallsUserPositionResponse Position { get; set; } = null!;
    public FindOneCallsUserDepartmentResponse Department { get; set; } = null!;
    public FindOneCallsUserDivisionResponse Division { get; set; } = null!;
    public FindOneCallsUserUnitResponse Unit { get; set; } = null!;
}
