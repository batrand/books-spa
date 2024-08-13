namespace BooksSpa.Api.Models;

public class ErrorResponse(string errorMessage)
{
    public string Message { get; set; } = errorMessage;
}