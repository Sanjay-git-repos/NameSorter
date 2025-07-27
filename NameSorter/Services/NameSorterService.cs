using NameSorter.Models;
using NameSorter.Services.Interfaces;

namespace NameSorter.Services
{
    /// <summary>
    /// Provides sorting functionality for PersonName collections.
    /// </summary>
    public class NameSorterService : INameSorterService
    {
        /// <inheritdoc />
        public IEnumerable<PersonName> Sort(IEnumerable<PersonName> names)
        {
            // Sort by last name, then by given names alphabetically
            return names
                .OrderBy(n => n.LastName, StringComparer.OrdinalIgnoreCase)
                .ThenBy(n => string.Join(" ", n.GivenNames), StringComparer.OrdinalIgnoreCase);
        }
    }
}
