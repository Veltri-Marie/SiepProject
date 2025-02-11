using Dtos.Job.Details;
using Dtos.Job.Response;

namespace Extensions.Job
{
    public static class JobExtensions
    {
        public static JobSheetResponse ToJobSheetResponse(this JobSheetDetails jobName)
        {
            return new JobSheetResponse
            (
                jobName.Id,
                jobName.isActive,
                jobName.isIntro,
                jobName.isRegulated,
                jobName.isPriority,
                jobName.Statut,
                jobName.Name,
                jobName.Description,
                jobName.KnowHow, 
                jobName.Date
                
            );
        }
    }
}