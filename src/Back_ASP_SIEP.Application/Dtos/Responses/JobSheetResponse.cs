namespace Dtos.Job.Response
{
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

