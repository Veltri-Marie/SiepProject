using Dtos.Error.Response;
using Dtos.Job.Response;
using Exceptions.Job;
using Interfaces.UseCases.Job;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Hubs;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace ApiControllers.AI
{
    [ApiController]
    [Route("api/[controller]")]
    public class AiModelController : ControllerBase
    {
        private readonly IGetJobSheetUseCase _useCase;
        private readonly IHubContext<JobHub> _hubContext;
        private readonly ILogger<AiModelController> _logger;

        public AiModelController(IGetJobSheetUseCase useCase, IHubContext<JobHub> hubContext, ILogger<AiModelController> logger)
        {
            _useCase = useCase;
            _hubContext = hubContext;
            _logger = logger;
        }

        [HttpGet("{jobName}")]
        public async Task<IActionResult> GetJobSheet(string jobName)
        {
            _logger.LogInformation("Received request for job sheet: {JobName}", jobName);
            try
            {
                JobSheetResponse response = await _useCase.Execute(jobName);

                _logger.LogInformation("Sending job sheet response via SignalR");
                await _hubContext.Clients.All.SendAsync("ReceiveJobSheet", response);

                return Ok(response);
            }
            catch (JobSheetException ex)
            {
                var errorResponse = new ErrorResponse(
                    Message: ex.Message,
                    ErrorCode: ex.ERROR_CODE,
                    Details: ex.InnerException?.Message
                );

                _logger.LogError("JobSheetException: {Message}", ex.Message);
                await _hubContext.Clients.All.SendAsync("JobSheetError", errorResponse);

                return BadRequest(errorResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse(
                    Message: "An unexpected error occurred.",
                    ErrorCode: "001",
                    Details: ex.Message
                );

                _logger.LogError("Exception: {Message}", ex.Message);
                await _hubContext.Clients.All.SendAsync("JobSheetError", errorResponse);

                return StatusCode(500, errorResponse);
            }
        }

        [HttpGet("{jobName}/stream")]
        public async Task GetJobSheetStream(string jobName)
        {
            _logger.LogInformation("Streaming response for job sheet: {JobName}", jobName);

            Response.ContentType = "application/json";
            Response.StatusCode = StatusCodes.Status200OK;

            await using var writer = new StreamWriter(Response.Body);
            await writer.WriteAsync("{ \"status\": \"streaming\", \"data\": [");
            await writer.FlushAsync();

            try
            {
                JobSheetResponse response = await _useCase.Execute(jobName);

                var jsonOptions = new JsonSerializerOptions { WriteIndented = false };
                string json = JsonSerializer.Serialize(response, jsonOptions);

                await writer.WriteAsync(json);
                await writer.FlushAsync();
            }
            catch (JobSheetException ex)
            {
                _logger.LogError("JobSheetException: {Message}", ex.Message);
                await writer.WriteAsync($", {{ \"error\": \"{ex.Message}\" }}");
                await writer.FlushAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception: {Message}", ex.Message);
                await writer.WriteAsync($", {{ \"error\": \"An unexpected error occurred.\" }}");
                await writer.FlushAsync();
            }

            await writer.WriteAsync("] }");
            await writer.FlushAsync();
        }

    }
}