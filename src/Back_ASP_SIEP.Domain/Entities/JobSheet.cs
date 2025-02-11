using Interfaces.Entities.Job;

namespace Entities.Job
{
    public class JobSheet(int id, string synonyms, string name, string description, string[] knowHows) : IJobSheet
    {
        //#TODO: verify constructor parameters and default parameters
        public bool IsActive { get; set; } = true;
        public bool IsIntro { get; set; } = false;
        public bool IsRegulated { get; set; } = false;
        public bool IsPriority { get; set; } = true;
        public string Statut { get; set; } = "Unknow";
        public string Synonyms { get; set; } = synonyms;
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;

        public string[] KnowHows { get; set; } = knowHows;
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}