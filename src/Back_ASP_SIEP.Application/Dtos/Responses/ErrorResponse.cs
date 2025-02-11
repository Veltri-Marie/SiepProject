namespace Dtos.Error.Response
{
    public record ErrorResponse
    (
        string Message,
        string ErrorCode,
        string? Details = null
    );
}