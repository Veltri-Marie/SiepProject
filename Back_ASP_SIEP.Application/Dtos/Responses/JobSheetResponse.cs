namespace Dtos.Job.Response
{
    public record JobSheetResponse
    (
        string Name,
        string Description, 
        string[] KnowHow
    );
}