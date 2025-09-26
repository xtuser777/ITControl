namespace ITControl.Communication.Shared.Responses;

public class ErrorJsonResponse(string[] errors)
{
    public string[] Errors { get; set; } = errors;
}