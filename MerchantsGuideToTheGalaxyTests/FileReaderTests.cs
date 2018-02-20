using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantsGuideToTheGalaxy;
using MerchantsGuideToTheGalaxy.GalaxyFile;

namespace MerchantsGuideToTheGalaxyTests
{
    [TestClass]
    public class FileReaderTests
    {
        public string path = System.AppDomain.CurrentDomain.BaseDirectory;
        public string ExistentFileWithContent {get; set; }
        public string ExistentFileWithoutContent { get; set; }
        public string NonExistentFile { get; set; }
        public FileReader _FileReader = new FileReader();

        public FileReaderTests()
        {
            this.ExistentFileWithContent = path + @"input_test_with_content.txt";
            this.ExistentFileWithoutContent = path + @"input_test_without_content.txt";
            this.NonExistentFile = @"input_test_2.txt";
        }

        [TestMethod]
        public void TestReturnEmptyStringCaseFileDontExists()
        {
            Assert.AreEqual(string.Empty, _FileReader.ReadLines(NonExistentFile));
        }

        [TestMethod]
        public void TestReturnEmptyStringCaseFileExistsWithoutContent()
        {
            Assert.AreEqual(string.Empty, _FileReader.ReadLines(ExistentFileWithoutContent));
        }

        [TestMethod]
        public void TestReturnContentCaseFileExistsWithContent()
        {
            Assert.IsTrue(!string.IsNullOrEmpty(_FileReader.ReadLines(ExistentFileWithContent)));
        }
    }
}