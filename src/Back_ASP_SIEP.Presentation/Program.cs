using System.Net.WebSockets;
using Extensions.ServiceCollection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices();
WebApplication app = builder.Build();

app.UseCors("Dev");
app.UseWebSockets(); 

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/ws")
    {
        if (context.WebSockets.IsWebSocketRequest)
        {
            using WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
            await WebSocketHandler.HandleWebSocketAsync(webSocket, app.Services);
        }
        else
        {
            context.Response.StatusCode = 400;
        }
    }
    else
    {
        await next();
    }
});

app.MapControllers();
app.Run();
