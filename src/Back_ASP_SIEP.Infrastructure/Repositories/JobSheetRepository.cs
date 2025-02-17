using Interfaces.Repositories;
using InterfaceS.Helpers.File;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace Repositories.Job
{
    /// <summary> Repository for retrieving and formatting job sheet data. </summary>
    public class JobSheetRepository(Kernel kernel, IFileHelper fileHelper, IChatCompletionService chatCompletionService) : IJobSheetRepository
    {
        private readonly Kernel _kernel = kernel;
        private readonly IFileHelper _fileHelper = fileHelper;
        private readonly IChatCompletionService _chatCompletionService = chatCompletionService;


        /// <summary> Retrieves a formatted job sheet asynchronously based on the specified job name. </summary>
        /// <returns> A formatted job sheet as a string containing at least a json structure. </returns>
        /// <exception cref="Exception"> Thrown if an error occurs during the job sheet retrieval process. </exception>
        public async Task<string> GetFormatedSheetAsync(string jobName)
        {
            try
            {
                //#TODO: Get path dynamically
                string structure = _fileHelper.GetFileContent("Back_ASP_SIEP.Infrastructure\\Templates\\jobSheetTemplate.txt");
                string prompt = @$"Respecte strictement la structure suivante en format JSON :
                {structure}

                - Remplis uniquement les champs suivants :
                - ""Name"" : Nom du métier.
                - ""Excerpt"" : Une courte introduction sur le métier.
                - ""Tags"" : Une liste de mots-clés pertinents (au moins 3).
                - ""Description"" : Une description concise du métier avec un minimum de mots.
                - ""KnowHows"" : Un tableau contenant exactement 3 savoir-faire requis pour exercer ce métier.
                - ""SoftSkills"" : Un tableau contenant exactement 3 compétences comportementales (savoir-être).
                - ""RequiredTitle"" : Le diplôme ou la qualification requise pour ce métier.
                - ""ProfessionalFramework"" : L’environnement professionnel dans lequel ce métier s’exerce.
                - ""Synonyms"" : Une liste d’autres appellations pour ce métier.

                - Ne génère qu'une seule structure JSON correctement remplie.

                Voici le métier que tu dois utiliser :
                {jobName}

                Recherche les informations nécessaires pour ce métier et remplis la fiche en utilisant des informations précises et synthétiques.";
                await foreach (var message in _chatCompletionService.GetStreamingChatMessageContentsAsync(prompt))
                {
                    Console.Write("Streaming message: " + message);
                }
                FunctionResult result = await _kernel.InvokePromptAsync(prompt);
                Console.WriteLine("THE PROMPT RESULT IS: " + result);
                return result.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
