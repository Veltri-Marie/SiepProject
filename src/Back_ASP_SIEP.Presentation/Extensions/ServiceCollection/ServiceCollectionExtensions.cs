using Helpers.File;
using Interfaces.Repositories;
using Interfaces.UseCases.Job;
using InterfaceS.Helpers.File;
using Microsoft.SemanticKernel;
using Repositories.Job;
using UseCases.Job;

namespace Extensions.ServiceCollection
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            //#TODO: Configure cors policy properly
            services.AddCors(options => {
                options.AddPolicy("Dev", builder =>
            {
                builder.WithOrigins("http://localhost:5173")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
            });
            services.AddControllers();
            services.AddLogging();
            services.AddScoped<IJobSheetRepository, JobSheetRepository>();
            services.AddScoped<IGetJobSheetUseCase, GetJobSheetUseCase>();
            services.AddOllamaChatCompletion("mistral", new Uri("http://localhost:11434"));
            services.AddSingleton<KernelPluginCollection>((serviceProvider) => 
                [
                    //KernelPluginFactory.CreateFromObject(serviceProvider.GetRequiredService<TestPlugin>())
                ]
            );
            services.AddTransient((serviceProvider) => {
                KernelPluginCollection pluginCollection = serviceProvider.GetRequiredService<KernelPluginCollection>();
                return new Kernel(serviceProvider, pluginCollection);
            });
            services.AddSingleton<IFileHelper>(new FileHelper());
        }
    }
}