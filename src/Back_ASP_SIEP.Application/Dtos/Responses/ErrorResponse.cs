namespace Dtos.Error.Response
{
    /// <summary> Represents a standardized error response for API calls. </summary>
    public record ErrorResponse
    (
        string Message,
        string ErrorCode,
        string? Details = null
    );
}