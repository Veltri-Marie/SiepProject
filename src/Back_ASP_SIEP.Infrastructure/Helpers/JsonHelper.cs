using System.Text.Json;

namespace Helpers.Json
{
    public class JsonHelper
    {
        /// <summary>
        /// Extrait une structure JSON d'une chaîne de caractères et la désérialise en un objet de type T.
        /// </summary>
        /// <typeparam name="T">Le type de l'objet à désérialiser.</typeparam>
        /// <param name="jsonFormattedString">La chaîne de caractères contenant la structure JSON.</param>
        /// <returns>L'objet désérialisé de type T.</returns>
        public static T ExtractFromJson<T>(string jsonFormattedString)
        {
            int startIndex = jsonFormattedString.IndexOf('{');
            int endIndex = jsonFormattedString.LastIndexOf('}');
            if (startIndex == -1 || endIndex == -1 || startIndex > endIndex)
            {
                throw new ArgumentException("Invalid JSON structure in input string.");
            }
            string jsonString = jsonFormattedString.Substring(startIndex, endIndex - startIndex + 1);
            Console.WriteLine("SUBBED STRING: " + jsonString);
            return JsonSerializer.Deserialize<T>(jsonString)
                ?? throw new JsonException("The JSON Deserialization returned null");
        }
    }
}