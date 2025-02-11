using Dtos.Job.Response;
using Entities.Job;

namespace Extensions.Entities.Job
{
    public static class JobExtensions
    {
        public static JobSheetResponse ToJobSheetResponse(this JobSheet jobSheet)
        {
            return new JobSheetResponse
            (
                jobSheet.Id,
                jobSheet.IsActive,
                jobSheet.IsIntro,
                jobSheet.IsRegulated,
                jobSheet.IsPriority,
                jobSheet.Statut,
                jobSheet.Name,
                jobSheet.Description,
                jobSheet.KnowHows,
                DateTime.Now
            );
        }
    }
}