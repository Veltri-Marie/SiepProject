using Interfaces.Repositories;
using InterfaceS.Helpers.File;
using Microsoft.SemanticKernel;

namespace Repositories.Job
{
    /// <summary> Repository for retrieving and formatting job sheet data. </summary>
    public class JobSheetRepository(Kernel kernel, IFileHelper fileHelper) : IJobSheetRepository
    {
        private readonly Kernel _kernel = kernel;
        private readonly IFileHelper _fileHelper = fileHelper;

        /// <summary> Retrieves a formatted job sheet asynchronously based on the specified job name. </summary>
        /// <returns> A formatted job sheet as a string containing at least a json structure. </returns>
        /// <exception cref="Exception"> Thrown if an error occurs during the job sheet retrieval process. </exception>
        public async Task<string> GetFormatedSheetAsync(string jobName)
        {
            try
            {
                //#TODO: Get path dynamically
                string structure = _fileHelper.GetFileContent("Back_ASP_SIEP.Infrastructure\\Templates\\jobSheetTemplate.txt");
                string prompt = @$"Voici la structure que tu dois strictement respecter, en format JSON :
                            {structure}
                            Le valeur du champs ""id"" doit être 1.
                            La valeur du champrs ""KnowHows"" doit être un tableau de string contenant 3 savoirs faire requis pour exercer le métier.
                            Tu ne dois inclure qu'une seule structure remplie dans ta réponse.

                            Voici le métier que tu dois utiliser :
                            {jobName}

                            Cherche les informations requises pour ce métier et remplis la fiche avec les informations.
                            Inclus le minimum de mots pour la description.";
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
