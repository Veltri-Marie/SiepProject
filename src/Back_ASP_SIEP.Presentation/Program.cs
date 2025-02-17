using Extensions.ServiceCollection;
using Hubs;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices();
WebApplication app = builder.Build();

app.UseCors("Dev");
app.UseRouting();

app.UseWebSockets(new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromSeconds(120)
});

app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<JobHub>("/jobHub");
});


app.Run();
