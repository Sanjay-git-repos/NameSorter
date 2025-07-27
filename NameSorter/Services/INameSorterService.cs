using NameSorter.Models;

namespace NameSorter.Services.Interfaces
{
    /// <summary>
    /// Interface for sorting collections of PersonName.
    /// </summary>
    public interface INameSorterService
    {
        /// <summary>
        /// Sorts PersonName instances by last name, then by given names.
        /// </summary>
        IEnumerable<PersonName> Sort(IEnumerable<PersonName> names);
    }
}
