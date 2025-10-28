namespace ITControl.Presentation.Shared.Responses;

public class ErrorJsonResponse(string[] errors)
{
    public string[] Errors { get; set; } = errors;
}