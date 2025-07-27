using NameSorter.Services;
using NameSorter.Services.Interfaces;

namespace NameSorter
{
    /// <summary>
    /// Main entry point of the name sorter console application.
    /// </summary>
    public class Program
    {
        private const string OutputFileName = "sorted-names-list.txt";

        private static IFileService _fileService = new FileService();
        private static INameParserService _nameParser = new NameParserService();
        private static INameSorterService _nameSorter = new NameSorterService();

        /// <summary>
        /// Main method.
        /// Usage: name-sorter <input-file>
        /// </summary>
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: name-sorter <input-file>");
                return;
            }

            var inputFilePath = args[0];

            try
            {
                // Read names from file
                var rawNames = _fileService.ReadFile(inputFilePath);

                // Parse raw names into PersonName objects
                var parsedNames = _nameParser.ParseNames(rawNames);

                // Sort parsed names
                var sortedNames = _nameSorter.Sort(parsedNames);

                // Convert sorted PersonName objects back to strings
                var outputLines = sortedNames.Select(n => n.ToString());

                // Print sorted names to console
                foreach (var line in outputLines)
                {
                    Console.WriteLine(line);
                }

                // Write sorted names to output file
                _fileService.WriteFile(OutputFileName, outputLines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
