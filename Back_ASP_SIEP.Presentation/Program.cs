using Helpers.File;
using Interfaces.Repositories;
using Interfaces.UseCases.Job;
using InterfaceS.Helpers.File;
using Microsoft.SemanticKernel;
using Repositories.Job;
using UseCases.Job;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//#TODO: Configure the policy properly
//#TODO: put Services configuration in a separate extension class
builder.Services.AddCors(options => {
    options.AddPolicy("Dev", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
});

builder.Services.AddControllers();
builder.Services.AddLogging();
builder.Services.AddScoped<IJobSheetRepository, JobSheetRepository>();
builder.Services.AddScoped<IGetJobSheetUseCase, GetJobSheetUseCase>();

IKernelBuilder kernelBuilder = Kernel.CreateBuilder();
kernelBuilder.AddOllamaChatCompletion("mistral", new Uri("http://localhost:11434"));
Kernel kernel = kernelBuilder.Build();
builder.Services.AddSingleton<Kernel>(kernel);

IFileHelper fileHelper = new FileHelper();
builder.Services.AddSingleton<IFileHelper>(fileHelper);
WebApplication app = builder.Build();
app.MapControllers();
app.UseCors("Dev");
app.Run();
