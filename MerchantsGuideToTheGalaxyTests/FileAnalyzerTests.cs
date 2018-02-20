using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantsGuideToTheGalaxy;
using MerchantsGuideToTheGalaxy.GalaxyFile;
using System.Reflection;
using System.IO;

namespace MerchantsGuideToTheGalaxyTests
{
    [TestClass]
    public class FileAnalyzerTests
    {
        public string[] NullArgs = null;
        public string[] EmptyArgs = new string[0];
        private string path = System.AppDomain.CurrentDomain.BaseDirectory;
        public string Content { get; set; }
        public string ContentWithInvalidExpressions { get; set; }
        public string ContentWithoutInvalidExpressions { get; set; } 
        public int ValidLinesCount = 11;
        public int ReferenceLinesCount = 7;
        public int QuestionLinesCount = 4;
        FileAnalyzer _FileAnalyzer = new FileAnalyzer();
        MerchantsGuideToTheGalaxy.GalaxyFile.FileInfo _FileInfo = new MerchantsGuideToTheGalaxy.GalaxyFile.FileInfo();

        public FileAnalyzerTests()
        {
            this.Content = path + @"input_test_with_content.txt";
            this.ContentWithInvalidExpressions = path + @"input_test_with_content_with_invalid_expressions.txt";
            this.ContentWithoutInvalidExpressions = @"input_test_with_content_without_invalid_expressions.txt";
            this._FileInfo = _FileAnalyzer.Analyze(Content);
        }

        [TestMethod]
        public void TestCorrectlyExtractValidLinesOnAnalyze()
        {
            Assert.AreEqual(ValidLinesCount, this._FileInfo.ValidLines.Count);
        }

        [TestMethod]
        public void TestCorrectlyExtractReferenceValuesOnAnalyze()
        {
            Assert.AreEqual(ReferenceLinesCount, this._FileInfo.ReferenceValues.Count);
        }

        [TestMethod]
        public void TestCorrectlyExtractQuestionsOnAnalyze()
        {
            Assert.AreEqual(QuestionLinesCount, this._FileInfo.Questions.Count);
        }

        [TestMethod]
        public void TestCorrectlyVerifyContentWithInvalidExpressions()
        {
            Assert.IsTrue(_FileAnalyzer.Analyze(ContentWithInvalidExpressions).HasInvalidExpressions);
        }

        [TestMethod]
        public void TestCorrectlyVerifyContentWithoutInvalidExpressions()
        {
            Assert.IsFalse(_FileAnalyzer.Analyze(ContentWithoutInvalidExpressions).HasInvalidExpressions);
        }


        private string GetSolutionPath()
        {
            string assemblyname = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string path = "";

            using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(assemblyname + ".solutionpath.txt"))
            {
                using (var sr = new StreamReader(stream))
                {
                    path = sr.ReadToEnd().Trim();
                }
            }

            return path;
        }
    }
}