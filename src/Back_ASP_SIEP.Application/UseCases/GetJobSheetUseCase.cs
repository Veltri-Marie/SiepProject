using Dtos.Job.Response;
using Extensions.Entities.Job;
using Interfaces.Repositories;
using Interfaces.UseCases.Job;
using Microsoft.Extensions.Logging;
using Exceptions.Job;
using Interfaces.Entities.Job;
using Entities.Job;
using Helpers.Json;

namespace UseCases.Job
{
    public class GetJobSheetUseCase(IJobSheetRepository repository, ILogger<GetJobSheetUseCase> logger) : IGetJobSheetUseCase
    {
        private readonly IJobSheetRepository _repository = repository;
        private readonly ILogger<GetJobSheetUseCase> _logger = logger;

        public async Task<JobSheetResponse> Execute(string jobName)
        {
            try
            {
                string jsonFormatedString = await _repository.GetFormatedSheetAsync(jobName);
                IJobSheet jobSheet = JsonHelper.ExtractFromJson<JobSheet>(jsonFormatedString);
                return ((JobSheet)jobSheet).ToJobSheetResponse();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "GetJobSheetUseCase.Execute: Error while getting job sheet details");
                throw new JobSheetException("An error occured while getting the job sheet", ex);
            }
        }
    }
}