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
                jobName.Name,
                jobName.Description,
                jobName.KnowHow
            );
        }
    }
}