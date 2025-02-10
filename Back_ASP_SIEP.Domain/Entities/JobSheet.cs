using Interfaces.Entities.Job;

namespace Entities.Job
{
    public class JobSheet(string name, string description, string knowHow) : IJobSheet
    {
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;

        public string KnowHow { get; set; } = knowHow;
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}