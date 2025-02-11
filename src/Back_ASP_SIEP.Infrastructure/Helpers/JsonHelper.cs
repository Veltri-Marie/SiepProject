using System.Text.Json;

namespace Helpers.Json
{
    /// <summary> Provides helper methods for JSON manipulation. </summary>
    public class JsonHelper
    {
        /// <summary> Extracts a JSON structure from a string and deserializes it into an object of type T. </summary>
        /// <returns> The deserialized object of type T. </returns>
        /// <exception cref="ArgumentException"> Thrown if the input string does not contain a valid JSON structure. </exception>
        /// <exception cref="JsonException"> Thrown if the JSON deserialization returns null. </exception>
        public static T DeserializeFromString<T>(string jsonFormattedString)
        {
            int startIndex = jsonFormattedString.IndexOf('{');
            int endIndex = jsonFormattedString.LastIndexOf('}');
            if (startIndex == -1 || endIndex == -1 || startIndex > endIndex)
            {
                throw new ArgumentException("Invalid JSON structure in input string.");
            }
            string jsonString = jsonFormattedString.Substring(startIndex, endIndex - startIndex + 1);
            Console.WriteLine("SUBBED STRING: " + jsonString);
            return JsonSerializer.Deserialize<T>(jsonString) ?? throw new JsonException("The JSON Deserialization returned null");
        }
    }
}
