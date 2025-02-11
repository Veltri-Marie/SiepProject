namespace Dtos.Job.Response
{
    /// <summary> Represents a response DTO containing job sheet details. </summary>
    public record JobSheetResponse
    (
        int Id,
        bool isActive,
        bool isIntro,
        bool isRegulated,
        bool isPriority,
        string Statut,
        string Name,
        string Description,
        string[] KnowHow,
        DateTime Date
    );
}

