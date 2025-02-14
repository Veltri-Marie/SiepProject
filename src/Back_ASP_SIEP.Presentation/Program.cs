using System.Net.WebSockets;
using Extensions.ServiceCollection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices();
WebApplication app = builder.Build();

app.UseCors("Dev");

app.MapControllers();
app.Run();
