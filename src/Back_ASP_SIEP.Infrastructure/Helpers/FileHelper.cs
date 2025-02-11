using System.Text;
using InterfaceS.Helpers.File;

namespace Helpers.File
{
    /// <summary> Provides helper methods for file operations. </summary>
    public class FileHelper : IFileHelper
    {
        /// <summary> Reads the content of a file at the specified relative path. </summary>
        /// <returns> The content of the file as a string. </returns>
        /// <exception cref="ArgumentNullException"> Thrown if the provided path is null. </exception>
        /// <exception cref="FileNotFoundException"> Thrown if the file does not exist at the specified path. </exception>
        /// <exception cref="IOException"> Thrown if an I/O error occurs while reading the file. </exception>
        public string GetFileContent(string path)
        {
            if (path is null) throw new ArgumentNullException(nameof(path), "The file path cannot be null.");
            string baseDirectoryPath = Directory.GetCurrentDirectory();
            string parentDirectoryPath = Directory.GetParent(baseDirectoryPath).FullName;
            string completePath = Path.Combine(parentDirectoryPath, path);
            if (!System.IO.File.Exists(completePath)) throw new FileNotFoundException("The specified file was not found.", completePath);
            return System.IO.File.ReadAllText(completePath, Encoding.UTF8);
        }
    }
}
