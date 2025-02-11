using Dtos.Job.Response;

namespace Interfaces.UseCases.Job
{
    public interface IGetJobSheetUseCase
    {
        Task<JobSheetResponse> Execute(string jobName);
    }
}