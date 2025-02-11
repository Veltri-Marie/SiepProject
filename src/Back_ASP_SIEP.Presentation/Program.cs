using Extensions.ServiceCollection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices();
WebApplication app = builder.Build();
app.MapControllers();
app.UseCors("Dev");
app.Run();