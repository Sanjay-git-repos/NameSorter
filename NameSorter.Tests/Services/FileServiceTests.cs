using NameSorter.Services;
using NameSorter.Services.Interfaces;

namespace NameSorter.Tests.Services
{
    /// <summary>
    /// Unit tests for FileService.
    /// </summary>
    [TestFixture]
    public class FileServiceTests
    {
        private IFileService _service;
        private const string TestInputFile = "test-input.txt";
        private const string TestOutputFile = "test-output.txt";

        [SetUp]
        public void Setup()
        {
            _service = new FileService();

            // Clean up test files before each test
            if (File.Exists(TestInputFile))
                File.Delete(TestInputFile);
            if (File.Exists(TestOutputFile))
                File.Delete(TestOutputFile);
        }

        [Test]
        public void ReadFile_ReadsLinesCorrectly()
        {
            // Prepare test input file with 2 lines
            File.WriteAllLines(TestInputFile, new[] { "Janet Parsons", "Vaughn Lewis" });

            var lines = _service.ReadFile(TestInputFile).ToList();

            Assert.That(lines, Has.Count.EqualTo(2));
            Assert.That(lines[0], Is.EqualTo("Janet Parsons"));
        }

        [Test]
        public void WriteFile_WritesLinesCorrectly()
        {
            var linesToWrite = new[] { "Line 1", "Line 2" };

            // Write lines to output file
            _service.WriteFile(TestOutputFile, linesToWrite);

            // Read back the lines to verify
            var readLines = File.ReadAllLines(TestOutputFile);

            Assert.That(readLines, Has.Length.EqualTo(linesToWrite.Length));
            Assert.That(readLines[0], Is.EqualTo("Line 1"));
        }
    }
}
