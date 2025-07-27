using NameSorter.Models;
using NameSorter.Services.Interfaces;

namespace NameSorter.Services
{
    /// <summary>
    /// Parses raw strings into PersonName objects.
    /// </summary>
    public class NameParserService : INameParserService
    {
        /// <inheritdoc />
        public IEnumerable<PersonName> ParseNames(IEnumerable<string> nameLines)
        {
            foreach (var line in nameLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    throw new FormatException("Name line cannot be empty.");

                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                // Validate number of name parts (1 to 3 given names + 1 last name)
                if (parts.Length < 2 || parts.Length > 4)
                    throw new FormatException($"Invalid name format: '{line}'. Name should have atleast 1 last name and up to 3 given names.");
                
                //get the last element (last name) from the parts array 
                var lastName = parts[^1];
                //Gets all but the last element of the parts array
                var givenNames = parts.Take(parts.Length - 1).ToList();

                yield return new PersonName(givenNames, lastName);
            }
        }
    }
}
