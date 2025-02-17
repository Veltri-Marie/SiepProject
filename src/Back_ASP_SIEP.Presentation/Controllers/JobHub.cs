using Interfaces.UseCases.Job;
using Microsoft.AspNetCore.SignalR;
using Dtos.Job.Response;
using Exceptions.Job;
using Dtos.Error.Response;

namespace Hubs
{
    public class JobHub : Hub
    {
        private readonly IGetJobSheetUseCase _useCase;

        public JobHub(IGetJobSheetUseCase useCase)
        {
            _useCase = useCase;
        }

        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"[SignalR] Connexion établie : {Context.ConnectionId}");
            await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} joined the chat");
        }


        public async Task GetJobSheet(string jobName)
        {
            try
            {
                JobSheetResponse response = await _useCase.Execute(jobName);
                await Clients.Caller.SendAsync("ReceiveJobSheet", response);
            }
            catch (JobSheetException ex)
            {
                await Clients.Caller.SendAsync("JobSheetError", new ErrorResponse(
                    Message: $"{ex.Message}",
                    ErrorCode: ex.ERROR_CODE,
                    Details: ex.InnerException?.Message
                ));
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("JobSheetError", new ErrorResponse(
                    Message: "An unexpected error occurred.",
                    ErrorCode: "001",
                    Details: ex.Message
                ));
            }
        }

    }
}