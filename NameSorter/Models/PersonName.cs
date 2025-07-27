using System;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter.Models
{
    /// <summary>
    /// Represents a person's name, with given names and a last name.
    /// </summary>
    public class PersonName : IComparable<PersonName>
    {
        /// <summary>
        /// Gets the list of given names (1 to 3).
        /// </summary>
        public IReadOnlyList<string> GivenNames { get; }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Constructs a PersonName with given names and last name.
        /// </summary>
        public PersonName(IEnumerable<string> givenNames, string lastName)
        {
            if (givenNames == null)
                throw new ArgumentNullException(nameof(givenNames));

            var givenList = givenNames.ToList();

            if (givenList.Count < 1 || givenList.Count > 3)
                throw new ArgumentException("A name must have at least 1 given name and may have up to 3 given names.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be null or whitespace.");

            GivenNames = givenList.AsReadOnly();
            LastName = lastName;
        }

        /// <summary>
        /// Returns the full name as a string.
        /// </summary>
        public override string ToString()
        {
            return $"{string.Join(" ", GivenNames)} {LastName}";
        }

        /// <summary>
        /// Compares this instance to another PersonName.
        /// </summary>
        /// <param name="other">The other PersonName instance, may be null.</param>
        public int CompareTo(PersonName? other)
        {
            // Nulls come last
            if (other is null) return 1;

            // First compare by last name
            int lastNameComparison = string.Compare(LastName, other.LastName, StringComparison.OrdinalIgnoreCase);
            if (lastNameComparison != 0)
                return lastNameComparison;

            // If last names are equal, compare full given names
            string thisGiven = string.Join(" ", GivenNames);
            string otherGiven = string.Join(" ", other.GivenNames);
            return string.Compare(thisGiven, otherGiven, StringComparison.OrdinalIgnoreCase);
        }
    }
}
