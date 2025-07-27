using NUnit.Framework;
using NameSorter.Models;
using System.Collections.Generic;

namespace NameSorter.Tests.Models
{
    [TestFixture]
    public class PersonNameTests
    {
        [Test]
        public void CompareTo_Null_ReturnsGreaterThanZero()
        {
            var person = new PersonName(new[] { "Janet" }, "Parsons");
            int result = person.CompareTo(null);

            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public void CompareTo_SortsByLastName()
        {
            var p1 = new PersonName(new[] { "A" }, "Brown");
            var p2 = new PersonName(new[] { "B" }, "Adams");

            Assert.That(p2.CompareTo(p1), Is.LessThan(0)); // Adams < Brown
        }

        [Test]
        public void CompareTo_SortsByGivenNamesWhenLastNamesAreEqual()
        {
            var p1 = new PersonName(new[] { "Janet" }, "Smith");
            var p2 = new PersonName(new[] { "Adam" }, "Smith");

            Assert.That(p2.CompareTo(p1), Is.LessThan(0)); // Adam < Janet
        }

        [Test]
        public void ToString_ReturnsFullNameCorrectly()
        {
            var person = new PersonName(new[] { "Janet", "Marie" }, "Parsons");

            string fullName = person.ToString();

            Assert.That(fullName, Is.EqualTo("Janet Marie Parsons"));
        }
    }
}
