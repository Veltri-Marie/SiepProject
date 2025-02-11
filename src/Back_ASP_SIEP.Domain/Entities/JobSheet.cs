using Interfaces.Entities.Job;

namespace Entities.Job
{
    /// <summary> Represents a job sheet entity containing details about a specific job. </summary>
    public class JobSheet(int id, string synonyms, string name, string description, string[] knowHows) : IJobSheet
    {
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

        /// <summary> A string containing synonyms or alternative job titles. </summary>
        public string Synonyms { get; set; } = synonyms;

        /// <summary> The unique identifier of the job sheet. </summary>
        public int Id { get; set; } = id;

        /// <summary> The name of the job. </summary>
        public string Name { get; set; } = name;

        /// <summary> A brief description of the job. </summary>
        public string Description { get; set; } = description;

        /// <summary> An array of required know-hows for the job. </summary>
        public string[] KnowHows { get; set; } = knowHows;

        /// <summary> The date associated with the job sheet. Defaults to the current date. </summary>
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
