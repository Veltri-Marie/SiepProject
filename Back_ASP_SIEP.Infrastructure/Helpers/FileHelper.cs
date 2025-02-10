using System.Text;
using InterfaceS.Helpers.File;

namespace Helpers.File
{
    public class FileHelper : IFileHelper
    {
        public string GetFileContent(string path)
        {
            string baseDirectoryPath = Directory.GetCurrentDirectory();
            string parentDirectoryPath = Directory.GetParent(baseDirectoryPath).FullName;
            string completePath = Path.Combine(parentDirectoryPath, path);
            return System.IO.File.ReadAllText(completePath, Encoding.UTF8);
        }
    }
}