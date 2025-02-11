using Dtos.Job.Response;
using Entities.Job;
using Exceptions.Job;
using Extensions.Entities.Job;
using Helpers.Json;
using Interfaces.Entities.Job;
using Interfaces.Repositories;
using Interfaces.UseCases.Job;
using Microsoft.Extensions.Logging;

namespace UseCases.Job
{
    /// <summary> Use case for retrieving job sheet details based on the job name. </summary>
    public class GetJobSheetUseCase(IJobSheetRepository jobSheetRepository,
     IJsonValidationRepository jsonValidationRepository, ILogger<GetJobSheetUseCase> logger) : IGetJobSheetUseCase
    {
        private readonly IJobSheetRepository _jobSheetRepository = jobSheetRepository;
        private readonly IJsonValidationRepository _jsonValidationRepository = jsonValidationRepository;
        private readonly ILogger<GetJobSheetUseCase> _logger = logger;

        /// <summary> Executes the use case to retrieve a job sheet based on the job name.</summary>
        /// <returns>A <see cref="JobSheetResponse"/> containing the job sheet details.</returns>
        /// <exception cref="JobSheetException">Thrown when an error occurs while retrieving the job sheet.</exception>
        public async Task<JobSheetResponse> Execute(string jobName)
        {
            try
            {
                string jsonFormatedString = await _jobSheetRepository.GetFormatedSheetAsync(jobName);
                string verifiedjsonFormatedString = await _jsonValidationRepository.VerifyResultAsync(jsonFormatedString);
                IJobSheet jobSheet = JsonHelper.DeserializeFromString<JobSheet>(verifiedjsonFormatedString);
                return ((JobSheet)jobSheet).ToJobSheetResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetJobSheetUseCase.Execute: Error while getting job sheet details");
                throw new JobSheetException("An error occured while getting the job sheet", ex);
            }
        }
    }
}