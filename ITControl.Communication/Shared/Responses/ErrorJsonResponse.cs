namespace ITControl.Communication.Shared.Responses;

public class ErrorJsonResponse(string error)
{
    public string Message { get; set; } = error;
}