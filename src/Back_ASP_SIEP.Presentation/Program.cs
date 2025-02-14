using Extensions.ServiceCollection;
using Hubs;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices();
WebApplication app = builder.Build();

app.UseCors("Dev");
app.UseRouting();
app.UseWebSockets();
app.MapHub<JobHub>("jobHub");
app.Run();
