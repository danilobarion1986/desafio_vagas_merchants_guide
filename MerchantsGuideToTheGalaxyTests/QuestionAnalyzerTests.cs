using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantsGuideToTheGalaxy;
using System.Collections.Generic;
using MerchantsGuideToTheGalaxy.GalaxyFile;
using MerchantsGuideToTheGalaxy.Answers;

namespace MerchantsGuideToTheGalaxyTests
{
    [TestClass]
    public class QuestionAnalyzerTests
    {
        public string Content = System.AppDomain.CurrentDomain.BaseDirectory
                                        .Replace(@"\MerchantsGuideToTheGalaxy\bin\Release\", @"\input_test_with_content.txt");
        public QuestionAnalyzer _QuestionAnalyzer = new QuestionAnalyzer();
        public FileAnalyzer _FileAnalyzer = new FileAnalyzer();
        public FileInfo _FileInfo = new FileInfo();
        public FileInfo _FileInfoWithoutQuestions = new FileInfo();
        public FileInfo _FileInfoWithNullQuestionsObj = new FileInfo();
        public List<string> InvalidRomanValueQuestion = new List<string>() { "", "", "", "" };

        public QuestionAnalyzerTests()
        {
            _FileInfo = _FileAnalyzer.Analyze(Content);
        }

        [TestMethod]
        public void TestValidateNullInputOnAnswerEachQuestion()
        {
            try
            {
                _FileInfoWithNullQuestionsObj.Questions = null;
                _QuestionAnalyzer.AnswerQuestions(_FileInfoWithNullQuestionsObj);
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("Null parameter was not correctly validated! Exception message: {0}", ex.Message));
            }
        }

        [TestMethod]
        public void TestThereIsNoEmptyAnswersAfterAnswerEachQuestion()
        {
            var answers = _QuestionAnalyzer.AnswerQuestions(_FileInfo);
            Assert.IsFalse(answers.Contains(string.Empty));
        }

        [TestMethod]
        public void TestValidateEmptyInputOnAnswerQuestion()
        {
            try
            {
                _FileInfoWithoutQuestions.Questions = new List<string>() { "" };
                _QuestionAnalyzer.AnswerQuestions(_FileInfoWithoutQuestions);
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("Empty parameter was not correctly validated! Exception message: {0}", ex.Message));
            }
        }
    }
}