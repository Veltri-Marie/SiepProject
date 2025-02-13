namespace Dtos.Job.Response
{
    /// <summary> Represents a response DTO containing job sheet details. </summary>
    public record JobSheetResponse
    (
        int Id,
        bool IsActive,
        bool IsIntro,
        bool IsRegulated,
        bool IsPriority,
        string Statut,
        DateTime LastUpdated,
        string Name,
        string Excerpt,
        string[] Tags,
        int? ParentJobId,
        string LanguageLink,
        string Description,
        string[] KnowHows,
        string[] SoftSkills,
        string RequiredTitle,
        DateTime? RequiredTitleLastUpdated,
        string ProfessionalFramework,
        string[] Synonyms,
        int[] RelatedJobsIds,
        int[] RelatedSectorsIds,
        int[] RelatedInterviewsIds,
        int[] RelatedFederationsIds,
        int[] RelatedNewsIds,
        int[] RelatedPublicationsIds,
        int[] AuthorsIds,
        bool IsShortageJob
    );

}

