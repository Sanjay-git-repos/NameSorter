using NameSorter.Models;

namespace NameSorter.Services.Interfaces
{
    /// <summary>
    /// Interface for parsing raw string names into PersonName objects.
    /// </summary>
    public interface INameParserService
    {
        /// <summary>
        /// Parses a collection of raw name strings.
        /// </summary>
        IEnumerable<PersonName> ParseNames(IEnumerable<string> nameLines);
    }
}
