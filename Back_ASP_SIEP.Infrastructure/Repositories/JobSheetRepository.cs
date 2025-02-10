using Interfaces.Repositories;
using InterfaceS.Helpers.File;
using Microsoft.SemanticKernel;

namespace Repositories.Job
{
    public class JobSheetRepository(Kernel kernel, IFileHelper fileHelper) : IJobSheetRepository
    {
        private readonly Kernel _kernel = kernel;
        private readonly IFileHelper _fileHelper = fileHelper;

        public async Task<string> GetFormatedSheetAsync(string jobName)
        {
            try
            {
                //#TODO: Get path dynamically
                string structure = _fileHelper.GetFileContent("Back_ASP_SIEP.Infrastructure\\Templates\\jobSheetTemplate.txt");
                string prompt = @$"Voici la structure que tu dois strictement respecter, en format JSON :
                            {structure}
                            
                            Tu ne dois inclure qu'une seule structure remplie dans ta réponse.
                            Tu ne peux modifier que le contenu des champs ou la valeur est 'x'.

                            Voici le métier que tu dois utiliser :
                            {jobName}

                            Cherche les informations requises pour ce métier et remplis la fiche avec les informations.
                            Inclus le minimum de mots pour la description.";
                FunctionResult result = await _kernel.InvokePromptAsync(prompt);
                //#TODO: Verify result before trying to convert it to JSON
                Console.WriteLine("THE PROMPT RESULT IS: " + result);
                return result.ToString();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}