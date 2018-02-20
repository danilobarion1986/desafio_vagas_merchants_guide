using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantsGuideToTheGalaxy.Answers;

namespace MerchantsGuideToTheGalaxy.GalaxyFile
{
    /// <summary>
    /// Analyzes the specified path and extract all necessary info.
    /// </summary>
    public class FileAnalyzer
    {
        private FileInfo _FileInfo { get; set; }
        private FileReader _FileReader { get; set; }
        private QuestionAnalyzer _AnswerMachine { get; set; }

        /// <summary>
        /// Analyzes the specified path and extract all necessary info.
        /// </summary>
        /// <param name="path">The full path for the file to be analyzed.</param>
        /// <returns>
        ///     <c>FileInfo</c> object containing the extracted info.
        /// </returns>
        public FileInfo Analyze(string path)
        {
            this._FileReader = new FileReader();
            this._FileInfo = new FileInfo();

            var fileContent = _FileReader.ReadLines(path);

            if (!string.IsNullOrEmpty(fileContent))
            {
                _FileInfo.ContentLines = fileContent.Split('\n').ToList();
                _FileInfo.ValidLines = ExtractValidLines();
                _FileInfo.ReferenceValues = ExtractReferenceValues();
                _FileInfo.Questions = ExtractQuestions();
                _FileInfo.HasInvalidExpressions = HasInvalidExpressions();

                this._AnswerMachine = new QuestionAnalyzer();
                _FileInfo.Output = this._AnswerMachine.AnswerQuestions(_FileInfo);
            }

            return _FileInfo;
        }

        private List<string> ExtractValidLines()
        {
            var validLines = _FileInfo.ContentLines
                                      .Where(line => line.ToUpper().Contains("IS")
                                                  || line.ToUpper().Contains("CREDITS"))
                                      .ToList();
            return validLines;
        }

        private List<string> ExtractReferenceValues()
        {
            var refValues = _FileInfo.ValidLines
                                     .Where(line => !line.Contains("?"))
                                     .ToList();

            return refValues;
        }

        private List<string> ExtractQuestions()
        {
            var questions = _FileInfo.ValidLines
                                     .Where(line => line.Contains("?"))
                                     .ToList();

            return questions;
        }

        private bool HasInvalidExpressions()
        {
            return _FileInfo.ContentLines.Count() > _FileInfo.ValidLines.Count();
        }
    }
}
