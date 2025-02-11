using Interfaces.Entities.Job;

namespace Entities.Job
{
    public class JobSheet(int id, string synonyms, string name, string description, string knowHow) : IJobSheet
    {

        public bool IsActive { get; set; } = true;
        public bool isIntro { get; set; } = false;
        public bool IsRegulated { get; set; } = false;
        public bool IsPriority { get; set; } = true;
        public string Synonyms { get; set; } = synonyms;
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;

        public string KnowHow { get; set; } = knowHow;
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}