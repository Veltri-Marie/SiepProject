using Microsoft.AspNetCore.Mvc;
using Dtos.Job.Response;
using Interfaces.UseCases.Job;
using Exceptions.Job;
using Dtos.Error.Response;

namespace ApiControllers.AI
{
    [ApiController]
    [Route("api/[controller]")]
    public class AiModelController(IGetJobSheetUseCase useCase) : ControllerBase
    {
        private readonly IGetJobSheetUseCase _useCase = useCase;

        [HttpGet("{jobName}")]
        public async Task<IActionResult> GetJobSheet(string jobName)
        {
            try
            {
                JobSheetResponse response = await _useCase.Execute(jobName);
                return Ok(response);
            }
            catch(JobSheetException ex)
            {
                return BadRequest(new ErrorResponse(
                    Message: ex.Message,
                    ErrorCode: ex.ERROR_CODE,
                    Details: ex.InnerException?.Message
                ));
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorResponse(
                    Message: "An unexpected error occurred.",
                    ErrorCode: "001",
                    Details: ex.Message
                ));

            }
        }
    }
}