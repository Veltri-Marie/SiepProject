using Helpers.File;
using Interfaces.Repositories;
using Interfaces.UseCases.Job;
using InterfaceS.Helpers.File;
using Microsoft.SemanticKernel;
using Repositories.Job;
using Repositories.Json;
using UseCases.Job;

namespace Extensions.ServiceCollection
{
    /// <summary> Provides extension methods for configuring services in the dependency injection container. </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary> Configures and registers necessary services for the application. </summary>
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Dev", builder =>
                {
                    builder.WithOrigins("http://localhost:5173") // ✅ Autoriser le frontend
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials(); // ✅ Indispensable pour SignalR
                });
            });

            services.AddControllers();
            services.AddLogging();
            services.AddSignalR();

            // Registers the repository and use case for job sheets
            services.AddScoped<IJobSheetRepository, JobSheetRepository>();
            services.AddScoped<IJsonValidationRepository, JsonValidationRepository>();
            services.AddScoped<IGetJobSheetUseCase, GetJobSheetUseCase>();

            // Configures AI model connection
            services.AddOllamaChatCompletion("mistral", new Uri("http://localhost:11434"));

            // Registers a collection of AI plugins (currently empty)
            services.AddSingleton<KernelPluginCollection>((serviceProvider) =>
                [
                // KernelPluginFactory.CreateFromObject(serviceProvider.GetRequiredService<TestPlugin>())
                ]
            );

            // Registers a Kernel instance with the plugin collection
            services.AddTransient((serviceProvider) =>
            {
                KernelPluginCollection pluginCollection = serviceProvider.GetRequiredService<KernelPluginCollection>();
                return new Kernel(serviceProvider, pluginCollection);
            });

            // Registers the file helper as a singleton
            services.AddSingleton<IFileHelper>(new FileHelper());
        }

    }
}
