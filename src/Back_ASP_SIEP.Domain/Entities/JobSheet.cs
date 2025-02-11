using Interfaces.Entities.Job;

namespace Entities.Job
{
    public class JobSheet(string name, string description) : IJobSheet
    {
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}