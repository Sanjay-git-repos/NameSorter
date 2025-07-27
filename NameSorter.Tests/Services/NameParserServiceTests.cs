using NameSorter.Services;
using NameSorter.Services.Interfaces;

namespace NameSorter.Tests.Services
{
    /// <summary>
    /// Unit tests for NameParserService.
    /// </summary>
    [TestFixture]
    public class NameParserServiceTests
    {
        private INameParserService _parser;

        [SetUp]
        public void Setup()
        {
            _parser = new NameParserService();
        }

        [Test]
        public void Parse_ValidTwoPartName_ReturnsCorrectObject()
        {
            var result = _parser.ParseNames(new[] { "Janet Parsons" }).ToList();

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(result[0].LastName, Is.EqualTo("Parsons"));
                Assert.That(result[0].GivenNames, Has.Count.EqualTo(1));
            });
            Assert.That(result[0].GivenNames[0], Is.EqualTo("Janet"));
        }

        [Test]
        public void Parse_ValidFourPartName_ReturnsCorrectObject()
        {
            var result = _parser.ParseNames(new[] { "Adonis Julius Archer" }).ToList();

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(result[0].LastName, Is.EqualTo("Archer"));
                Assert.That(result[0].GivenNames, Has.Count.EqualTo(2));
            });
            Assert.Multiple(() =>
            {
                Assert.That(result[0].GivenNames[0], Is.EqualTo("Adonis"));
                Assert.That(result[0].GivenNames[1], Is.EqualTo("Julius"));
            });
        }

        [Test]
        public void Parse_InvalidName_ThrowsFormatException()
        {
            var invalidNames = new[] { "SingleNameOnly" };

            Assert.Throws<FormatException>(() => _parser.ParseNames(invalidNames).ToList());
        }

        [Test]
        public void Parse_EmptyLine_ThrowsFormatException()
        {
            var invalidNames = new[] { "" };

            Assert.Throws<FormatException>(() => _parser.ParseNames(invalidNames).ToList());
        }
    }
}
