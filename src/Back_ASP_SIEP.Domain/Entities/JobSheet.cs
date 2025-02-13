using Interfaces.Entities.Job;

namespace Entities.Job
{
    /// <summary> Represents a job sheet entity containing details about a specific job. </summary>
    public class JobSheet : IJobSheet
    {
        /// <summary> The unique identifier of the job sheet. </summary>
        public int Id { get; set; }

        /// <summary> Indicates whether the job sheet is active. Defaults to <c>true</c>. </summary>
        public bool IsActive { get; set; } = true;

        /// <summary> Indicates whether the job sheet serves as an introduction. Defaults to <c>false</c>. </summary>
        public bool IsIntro { get; set; } = false;

        /// <summary> Indicates whether the job is subject to regulations. Defaults to <c>false</c>. </summary>
        public bool IsRegulated { get; set; } = false;

        /// <summary> Indicates whether the job is considered a priority. Defaults to <c>true</c>. </summary>
        public bool IsPriority { get; set; } = true;

        /// <summary> The current status of the job sheet. Defaults to "Unknown". </summary>
        public string Statut { get; set; } = "Unknown";

        /// <summary> The last update date of the job sheet. Defaults to the current date. </summary>
        public DateTime LastUpdated { get; set; } = DateTime.Now;

        /// <summary> The name of the job. </summary>
        public string Name { get; set; }

        /// <summary> A brief excerpt of the job sheet. </summary>
        public string Excerpt { get; set; } = string.Empty;

        /// <summary> Tags associated with the job sheet. </summary>
        public string[] Tags { get; set; } = Array.Empty<string>();

        /// <summary> The parent job ID, if applicable. </summary>
        public int? ParentJobId { get; set; }

        /// <summary> Link to language options for the job. </summary>
        public string LanguageLink { get; set; } = string.Empty;

        /// <summary> A detailed description of the job. </summary>
        public string Description { get; set; }

        /// <summary> An array of required know-hows for the job. </summary>
        public string[] KnowHows { get; set; }

        /// <summary> An array of soft skills required for the job. </summary>
        public string[] SoftSkills { get; set; } = Array.Empty<string>();

        /// <summary> Required title or qualifications for the job. </summary>
        public string RequiredTitle { get; set; } = string.Empty;

        /// <summary> The last update date of the required title. </summary>
        public DateTime? RequiredTitleLastUpdated { get; set; }

        /// <summary> The professional framework where the job is situated. </summary>
        public string ProfessionalFramework { get; set; } = string.Empty;

        /// <summary> A string containing synonyms or alternative job titles. </summary>
        public string[] Synonyms { get; set; } = Array.Empty<string>();

        /// <summary> Related job IDs. </summary>
        public int[] RelatedJobsIds { get; set; } = Array.Empty<int>();

        /// <summary> Related sector IDs (max 2). </summary>
        public int[] RelatedSectorsIds { get; set; } = Array.Empty<int>();

        /// <summary> Related interview IDs. </summary>
        public int[] RelatedInterviewsIds { get; set; } = Array.Empty<int>();

        /// <summary> Related federation IDs. </summary>
        public int[] RelatedFederationsIds { get; set; } = Array.Empty<int>();

        /// <summary> Related news IDs. </summary>
        public int[] RelatedNewsIds { get; set; } = Array.Empty<int>();

        /// <summary> Related publication IDs. </summary>
        public int[] RelatedPublicationsIds { get; set; } = Array.Empty<int>();

        /// <summary> IDs of the authors who worked on the job sheet. </summary>
        public int[] AuthorsIds { get; set; } = Array.Empty<int>();

        /// <summary> Indicates whether the job is in shortage based on regions. </summary>
        public bool IsShortageJob { get; set; } = false;

        /// <summary> Default constructor for initialization. </summary>
        public JobSheet(string name, string excerpt, string[] tags, string description, string[] knowHows,
        string[] softSkills, string requiredTitle, string professionalFramework, string[] synonyms)
        {
            Id = 1;
            IsActive = true;
            IsIntro = false;
            IsRegulated = false;
            IsPriority = true;
            Statut = "Unknown";
            LastUpdated = DateTime.Now;
            Name = name;
            Excerpt = excerpt;
            Tags = tags ?? Array.Empty<string>();
            ParentJobId = null;
            LanguageLink = string.Empty;
            Description = description;
            KnowHows = knowHows ?? Array.Empty<string>();
            SoftSkills = softSkills ?? Array.Empty<string>();
            RequiredTitle = requiredTitle;
            RequiredTitleLastUpdated = null;
            ProfessionalFramework = professionalFramework;
            Synonyms = synonyms ?? Array.Empty<string>();
            RelatedJobsIds = Array.Empty<int>();
            RelatedSectorsIds = Array.Empty<int>();
            RelatedInterviewsIds = Array.Empty<int>();
            RelatedFederationsIds = Array.Empty<int>();
            RelatedNewsIds = Array.Empty<int>();
            RelatedPublicationsIds = Array.Empty<int>();
            AuthorsIds = Array.Empty<int>();
            IsShortageJob = false;
        }
    }
}
