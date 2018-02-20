using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantsGuideToTheGalaxy.AncientRome;

namespace MerchantsGuideToTheGalaxy.Coins
{
    /// <summary>
    /// Extracts the reference values and organize them.
    /// </summary>
    public class CoinsAnalyzer
    {
        private CoinsInfo _CoinsInfo { get; set; }

        /// <summary>
        /// Analyzes the specified reference values.
        /// </summary>
        /// <param name="referenceValues">The reference values.</param>
        /// <returns></returns>
        public CoinsInfo Analyze(List<string> referenceValues)
        {
            this._CoinsInfo = new CoinsInfo();
            
            if (referenceValues != null)
            {
                foreach (var item in referenceValues)
                {
                    var words = item.Trim().Split(' ');

                    if (words.Any(word => word.ToUpper().Contains("CREDITS")))
                    {
                        GetCreditCoinValueInfo(words.ToList()); 
                    }
                    else if (words.Any(word => RomanNumeral.HasValidNumeral(word.ToCharArray())))
                    {
                        GetRomanCoinValueInfo(words.ToList());
                    }
                } 
            }

            return _CoinsInfo;
        }

        /// <summary>
        /// Gets the roman coin value information.
        /// </summary>
        /// <param name="words">The words from which the values ​​will be extracted.</param>
        private void GetRomanCoinValueInfo(List<string> words)
        {
            var coinName = words.First();
            var coinValue = words.Last();

            if (!string.IsNullOrEmpty(coinValue))
            {
                if (this._CoinsInfo.RomanCoinValues.ContainsKey(coinName))
                {
                    this._CoinsInfo.RomanCoinValues[coinName] = coinValue;
                }
                else
                {
                    this._CoinsInfo.RomanCoinValues.Add(coinName, coinValue);
                }
            }
        }


        /// <summary>
        /// Gets the credit coin value information.
        /// </summary>
        /// <param name="words">The words from which the values ​​will be extracted.</param>
        private void GetCreditCoinValueInfo(List<string> words)
        {
            var neededWords = words.Where(word => word.ToUpper() != "IS" && word.ToUpper() != "CREDITS").ToList();
            var penultWord = neededWords.Count - 2;
           
            var coinName = neededWords[penultWord];
            var coinValue = this.CalculateValueOfCreditCoin(neededWords);

            if (coinValue != null)
            {
                if (this._CoinsInfo.CreditCoinValues.ContainsKey(coinName))
                {
                    this._CoinsInfo.CreditCoinValues[coinName] = (double)coinValue;
                }
                else
                {
                    this._CoinsInfo.CreditCoinValues.Add(coinName, (double)coinValue);
                }
            }
        }

        /// <summary>
        /// Calculates the value of credit coin.
        /// </summary>
        /// <param name="neededWords">The needed words.</param>
        /// <returns>
        ///     <c>double?</c>, with the value of coin, if it's possible to calculate; otherwise <c>null</c>.
        /// </returns>
        private double? CalculateValueOfCreditCoin(List<string> neededWords)
        {
            var creditsRefValue = neededWords.Last();

            if (string.IsNullOrEmpty(creditsRefValue))
                return null;

            var penultWord = neededWords.Count - 2;
            var romanNumeral = string.Empty;

            // Gets the roman numeral resulting from the name of each roman coin at needed words list
            for (int i = 0; i < penultWord; i++)
                romanNumeral += this._CoinsInfo.RomanCoinValues[neededWords[i]];

            // Gets the arabic representation of the roman numeral
            var arabicNumeral = RomanNumeral.RomanToArabic(romanNumeral.ToCharArray());

            // If roman numeral is invalid, return null
            if (!arabicNumeral.HasValue)
                return null;

            // If roman numeral is valid, divide the credit value for the arabic value
            return double.Parse(creditsRefValue) / arabicNumeral.Value;
        }

    }
}
