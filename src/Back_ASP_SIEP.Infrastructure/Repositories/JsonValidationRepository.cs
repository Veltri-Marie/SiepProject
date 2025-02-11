using Interfaces.Repositories;
using InterfaceS.Helpers.File;
using Microsoft.SemanticKernel;

namespace Repositories.Json
{
    /// <summary> Repository for validating JSON structures. </summary>
    public class JsonValidationRepository(Kernel kernel, IFileHelper fileHelper) : IJsonValidationRepository
    {
        private readonly Kernel _kernel = kernel;
        private readonly IFileHelper _fileHelper = fileHelper;

        /// <summary> Verifies and corrects a JSON structure asynchronously. </summary>
        /// <returns> The verified and corrected JSON structure as a string. </returns>
        /// <exception cref="Exception"> Thrown if an error occurs during the JSON validation process. </exception>
        public async Task<string> VerifyResultAsync(string result)
        {
            try
            {
                string structure = _fileHelper.GetFileContent("Back_ASP_SIEP.Infrastructure\\Templates\\jobSheetTemplate.txt");
                string prompt = @$"Tu ne dois rien répondre d'autre qu'une structure JSON.
                            Vérifie que {result} soit une structure qui respecte un format JSON correct.
                            Si il y a des caractères en dehors des champs ou valeurs, supprime les.
                            Renvoie ensuite le résultat corrigé.";
                FunctionResult finalResult = await _kernel.InvokePromptAsync(prompt);
                return finalResult.ToString();
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}