namespace NameSorter.Services.Interfaces
{
    /// <summary>
    /// Interface for file read/write operations.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Reads all lines from the specified file path.
        /// </summary>
        IEnumerable<string> ReadFile(string path);

        /// <summary>
        /// Writes all lines to the specified file path.
        /// </summary>
        void WriteFile(string path, IEnumerable<string> lines);
    }
}
