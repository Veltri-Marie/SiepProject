namespace Dtos.Job.Details
{
    public record JobSheetDetails
    (
        int Id,
        bool isActive,
        bool isIntro,
        bool isRegulated,
        bool isPriority,
        string Statut,
        string Name,
        string Description, 
        string[] KnowHow
    );
}