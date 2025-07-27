using NameSorter.Services.Interfaces;

namespace NameSorter.Services
{
    /// <summary>
    /// Handles file read/write operations.
    /// </summary>
    public class FileService : IFileService
    {
        public IEnumerable<string> ReadFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Input file not found: {path}");

            return File.ReadLines(path);
        }
        public void WriteFile(string path, IEnumerable<string> lines)
        {
            File.WriteAllLines(path, lines);
        }
    }
}
