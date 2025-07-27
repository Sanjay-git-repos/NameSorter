using NameSorter.Models;
using NameSorter.Services;
using NameSorter.Services.Interfaces;

namespace NameSorter.Tests.Services
{
    /// <summary>
    /// Unit tests for NameSorterService.
    /// </summary>
    [TestFixture]
    public class NameSorterServiceTests
    {
        private INameSorterService _sorter;

        [SetUp]
        public void Setup()
        {
            _sorter = new NameSorterService();
        }

        [Test]
        public void Sort_SortsByLastNameThenGivenNames()
        {
            var unsorted = new List<PersonName>
            {
                new PersonName(new[] {"Janet", "Parsons"}, "Vaughn"),
                new PersonName(new[] {"Adonis", "Julius"}, "Archer"),
                new PersonName(new[] {"Shelby"}, "Nathan"),
            };

            var sorted = _sorter.Sort(unsorted).ToList();

            Assert.Multiple(() =>
            {
                Assert.That(sorted[0].LastName, Is.EqualTo("Archer"));
                Assert.That(sorted[1].GivenNames[0], Is.EqualTo("Shelby"));
                Assert.That(sorted[2].LastName, Is.EqualTo("Vaughn"));
            });
        }
    }
}
