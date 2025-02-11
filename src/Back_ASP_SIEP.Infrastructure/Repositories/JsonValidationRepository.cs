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
                string prompt = @$"Verifie que {result} sois bien sous format JSON. Corrige les erreurs.
                            Par exemple des lettres qui se seraient rajoutées. Ou des phrases en trop a la fin du JSON.
                            Si tout te semble correct, renvoie juste la reponse comme elle était au depart. N'oublie pas que 
                            la structure a respecté est la suivante : {structure} 
                            Tu ne dois inclure que la structure dans ta réponse.";
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