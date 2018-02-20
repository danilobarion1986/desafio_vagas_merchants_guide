using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantsGuideToTheGalaxy.AncientRome;
using MerchantsGuideToTheGalaxy.Coins;
using MerchantsGuideToTheGalaxy.GalaxyFile;

namespace MerchantsGuideToTheGalaxy.Answers
{
    /// <summary>
    /// Answer the questions passed, using coins reference values.
    /// </summary>
    public class QuestionAnalyzer
    {
        private CoinsAnalyzer _CoinsAnalyzer { get; set; }
        private CoinsInfo _CoinsInfo { get; set; }
        private List<string> Answers { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionAnalyzer"/> class.
        /// </summary>
        public QuestionAnalyzer()
        {
            this._CoinsAnalyzer = new CoinsAnalyzer();
            this._CoinsInfo = new CoinsInfo();
            this.Answers = new List<string>();
        }

        /// <summary>
        /// Answers the questions.
        /// </summary>
        /// <param name="fileInfo">The <see cref="FileInfo"/> object with the questions and coins reference values.</param>
        /// <returns>List of answers.</returns>
        public List<string> AnswerQuestions(FileInfo fileInfo)
        {
            this._CoinsInfo = this._CoinsAnalyzer.Analyze(fileInfo.ReferenceValues);

            this.Answers = this.AnswerEachQuestion(fileInfo.Questions);

            return this.Answers;
        }

        /// <summary>
        /// Loop through each question, collecting each non empty answer.
        /// </summary>
        /// <param name="questions">The questions to answer.</param>
        /// <returns>List of non empty answers.</returns>
        private List<string> AnswerEachQuestion(List<string> questions)
        {
            List<string> answers = new List<string>();

            if (questions != null)
            {
                foreach (var question in questions)
                {
                    var finalAnswer = this.AnswerQuestion(question);

                    if (!string.IsNullOrEmpty(finalAnswer))
                    {
                        answers.Add(finalAnswer);
                    }
                } 
            }

            return answers;
        }

        /// <summary>
        /// Answers one question of the list. Decide what the type of question, to answer accordingly.
        /// </summary>
        /// <param name="question">The question.</param>
        /// <returns>
        ///     Answer to the specific question.
        /// </returns>
        private string AnswerQuestion(string question)
        {
            var answer = string.Empty;

            if (!string.IsNullOrEmpty(question))
            {
                var neededWords = question.Trim()
                                          .Split(new string[] { " is " }, 
                                            StringSplitOptions.RemoveEmptyEntries)
                                          .Last().Split(' ').Where(x => x != "?").ToArray();

                if (question.ToUpper().Contains("CREDITS"))
                {
                    answer = this.AnswerToCreditsQuestion(neededWords);
                }
                else if (neededWords.Any(word => _CoinsInfo.RomanCoinValues.ContainsKey(word)))
                {
                    answer = this.AnswerToRomanValueQuestion(neededWords);
                }  
            }

            return answer;
        }

        /// <summary>
        /// Answers to question that use only roman numerals.
        /// </summary>
        /// <param name="words">The necessary words to calculate and answer.</param>
        /// <returns>The calculated answer.</returns>
        private string AnswerToRomanValueQuestion(string[] words)
        {
            var finalAnswer = string.Empty;
            var romanNumeral = string.Empty;

            foreach (var word in words)
            {
                if (_CoinsInfo.RomanCoinValues.ContainsKey(word))
                    romanNumeral += _CoinsInfo.RomanCoinValues[word];
                 
                finalAnswer += word + " ";
            }

            var arabicValue = RomanNumeral.RomanToArabic(romanNumeral.ToCharArray());

            if (arabicValue.HasValue)
                finalAnswer += string.Format("is {0}", arabicValue);
            else
                finalAnswer = "It was not possible to answer this question!";

            return finalAnswer;
        }

        /// <summary>
        /// Answers to question that use roman numerals and credits.
        /// </summary>
        /// <param name="words">The necessary words to calculate and answer.</param>
        /// <returns>The calculated answer.</returns>
        private string AnswerToCreditsQuestion(string[] words)
        {
            var finalAnswer = string.Empty;
            var romanNumeral = string.Empty;

            for (int i = 0; i < words.Length - 1; i++)
            {
                if (_CoinsInfo.RomanCoinValues.ContainsKey(words[i]))
                    romanNumeral += _CoinsInfo.RomanCoinValues[words[i]];
                
                finalAnswer += words[i] + " ";
            }

            var creditsValue = 0.0;
            var arabicValue = RomanNumeral.RomanToArabic(romanNumeral.ToCharArray());
            arabicValue = (arabicValue.HasValue ? arabicValue.Value : 0);

            if (arabicValue.HasValue && _CoinsInfo.CreditCoinValues.ContainsKey(words.Last()))
            {
                creditsValue = _CoinsInfo.CreditCoinValues[words.Last()];
                finalAnswer += string.Format("{0} is {1} Credits", words.Last(), creditsValue * arabicValue);
            }
            else
            {
                finalAnswer = "It was not possible to answer this question!";
            }
                            
            return finalAnswer;
        }
    }
}
