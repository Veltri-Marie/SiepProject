using Dtos.Job.Response;
using Entities.Job;

namespace Extensions.Entities.Job
{
    /// <summary> Provides extension methods for the <see cref="JobSheet"/> entity. </summary>
    public static class JobExtensions
    {
        /// <summary> Converts a <see cref="JobSheet"/> entity to a <see cref="JobSheetResponse"/> DTO. </summary>
        /// <returns>A <see cref="JobSheetResponse"/> DTO containing the job sheet details.</returns>
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