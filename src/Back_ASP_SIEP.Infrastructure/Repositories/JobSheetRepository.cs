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
                            Le valeur du champs ""id"" doit être 1.
                            Tu ne dois inclure qu'une seule structure remplie dans ta réponse.
                            Tu ne peux modifier que le contenu des champs ou la valeur est 'x'.

                            Voici le métier que tu dois utiliser :
                            {jobName}

                            Cherche les informations requises pour ce métier et remplis la fiche avec les informations.
                            Inclus le minimum de mots pour la description.
                            
                            Ensuite pour le savoir faire (Know How), tu dois inclure au moins 3 savoirs faire 
                            sous forme de petites phrases (5/6 mots par savoir faire)";
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

       public async Task<string> VerifyResult(string result)
        {
            try
            {
                string structure = _fileHelper.GetFileContent("Back_ASP_SIEP.Infrastructure\\Templates\\jobSheetTemplate.txt");
                string prompt = @$"Verifie que {result} sois bien sous format JSON. Corrige les erreurs.
                            Par exemple des lettres qui se seraient rajoutées. Ou des phrases en trop a la fin du JSON.
                            Si tout te semble correct, renvoie juste la reponse comme elle était au depart. N'oublie pas que 
                            la structure a respecté est la suivante : {structure} 
                            Tu ne dois inclure que la structure dans ta réponse.";
                FunctionResult finalResult = await _kernel.InvokePromptAsync(prompt);
                
                Console.WriteLine(finalResult);

                return finalResult.ToString();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}