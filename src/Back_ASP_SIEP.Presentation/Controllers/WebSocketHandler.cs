// using System.Net.WebSockets;
// using System.Text;
// using Interfaces.UseCases.Job;
// using Microsoft.Extensions.DependencyInjection;

// public static class WebSocketHandler
// {
//     public static async Task HandleWebSocketAsync(WebSocket webSocket, IServiceProvider services)
//     {
//         var buffer = new byte[4096];

//         using var scope = services.CreateScope();
//         var useCase = scope.ServiceProvider.GetRequiredService<IGetJobSheetUseCase>();

//         while (webSocket.State == WebSocketState.Open)
//         {
//             WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
//             if (result.MessageType == WebSocketMessageType.Close)
//             {
//                 await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Connection closed", CancellationToken.None);
//                 break;
//             }

//             string jobName = Encoding.UTF8.GetString(buffer, 0, result.Count);
//             Console.WriteLine("{jobName}");
//             try
//             {
//                 var jobResponse = await useCase.Execute(jobName);
//                 string jsonResponse = System.Text.Json.JsonSerializer.Serialize(jobResponse);

//                 var serverMsg = Encoding.UTF8.GetBytes(jsonResponse);
//                 await webSocket.SendAsync(new ArraySegment<byte>(serverMsg), WebSocketMessageType.Text, true, CancellationToken.None);
//             }
//             catch (Exception ex)
//             {
//                 var errorMsg = Encoding.UTF8.GetBytes($"Error: {ex.Message}");
//                 await webSocket.SendAsync(new ArraySegment<byte>(errorMsg), WebSocketMessageType.Text, true, CancellationToken.None);
//             }
//         }
//     }
// }
