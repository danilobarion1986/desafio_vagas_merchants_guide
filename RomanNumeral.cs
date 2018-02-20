using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy.AncientRome
{
    /// <summary>
    /// Validate Roman Numerals and convert them to the corresponding Arabic representation.
    /// </summary>
    public static class RomanNumeral
    {
        /// <summary>
        /// Options used to validate roman numeral.
        /// </summary>
        public enum ValidationOptions
        {
            /// <summary>
            /// Default behavior: Remove single empty spaces and capitalize all characters.
            /// </summary>
            None,
            
            /// <summary>
            /// Keep empty spaces and capitalize all characters.
            /// </summary>
            KeepEmptySpaces,

            /// <summary>
            /// Keep capitalization and remove empty spaces.
            /// </summary>
            KeepCapitalization,

            /// <summary>
            /// Validate numeral As-Is (maintain empty spaces, capitalization and any other invalid character or format).
            /// </summary>
            AsIs
        }

        private static List<char> ValidCharacters;
        private static List<string> InvalidPairs;
        private static List<string> InvalidRepetitions;
        private static List<string> ValidPalindromes;
        private static Dictionary<char, int> CharacterValues;

        static RomanNumeral()
        {
            ValidCharacters = new List<char> { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            InvalidPairs = new List<string> { "IL", "IC", "ID", "IM", "VX", "VL", "VC", "VD", "VM", "XD", "XM", "LC","LD","LM", "DM"};
            InvalidRepetitions = new List<string>() { "IIII", "VV", "XXXX", "LL", "CCCC", "DD", "MMMM" };
            ValidPalindromes = new List<string>() { "XIX", "CXC" };
            
            CharacterValues = new Dictionary<char, int>() 
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };
        }

        /// <summary>
        /// Convert Roman Numerals to Arabic representation.
        /// </summary>
        /// <param name="numeral">The numeral to convert.</param>
        /// <returns>
        ///     <c>int?</c> with value containing the arabic representation of the numeral, if it's valid; otherwise, <c>null</c>
        /// </returns>
        public static int? RomanToArabic(char[] numeral)
        {
            if (numeral == null || numeral.Count() == 0)
                return null;

            var formattedNumeral = new string(numeral).ToCorrectFormat(ValidationOptions.None).ToCharArray();

            if (!IsValidNumeral(formattedNumeral))
                return null;

            return ConvertRomanToArabic(formattedNumeral);
        }

        /// <summary>
        /// Determines whether the specified roman numeral is valid or not, based on all necessary the rules.
        /// </summary>
        /// <param name="numeral">The numeral to validate.</param>
        /// <param name="validationOptions">The options used to validate the numeral.</param>
        /// <returns>
        ///     <c>true</c> if the numeral is valid; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidNumeral(char[] numeral, ValidationOptions validationOptions = ValidationOptions.None)
        {
            var formattedNumeral = new string(numeral).ToCorrectFormat(validationOptions);

            if (string.IsNullOrEmpty(formattedNumeral)
                || formattedNumeral.HasInvalidCharacter()
                || formattedNumeral.HasInvalidRepetitionOfCharacters()
                || formattedNumeral.HasInvalidPairOfCharacters()
                || formattedNumeral.HasInvalidSequenceOfCharacters())
                return false;

            return true;
        }

        /// <summary>
        /// Determines whether the specified numeral has a valid roman character.
        /// </summary>
        /// <param name="numeral">The numeral.</param>
        /// <returns>
        ///     <c>true</c> if the numeral has at least one valid character; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasValidNumeral(char[] numeral)
        {
            var hasValidNumeral = numeral.Any(x => RomanNumeral.ValidCharacters.Contains(x));

            return hasValidNumeral;
        }

        private static int? ConvertRomanToArabic(char[] numeral)
        {
            var numeralLength = numeral.Length;
            var thisCharsValues = new int[numeralLength];

            // Gets the values of each character of numeral
            for (int i = 0; i < numeralLength; i++)
                thisCharsValues[i] = CharacterValues[numeral[i]];

            var sum = 0;

            for (int i = 0; i < numeralLength - 1; i++)
            {
                if (thisCharsValues[i] < thisCharsValues[i + 1])
                {
                    // If the current character value is smaller than the character on the right, subtract its value from that
                    sum = thisCharsValues[i + 1] - thisCharsValues[i]; 
                    thisCharsValues[i] = sum;
                    thisCharsValues[i + 1] = 0;
                    
                    // As the one on the right has been reset, jump it in the next loop
                    i++;
                }
            }

            return thisCharsValues.Sum();
        }

        /// <summary>
        /// Gets the formatted numeral, based on option. Default option remove empty spaces and capitalize all characters.
        /// </summary>
        /// <param name="numeral">The numeral.</param>
        /// <param name="validationOptions">The validation option.</param>
        /// <returns>
        ///     <c>null</c>, if the numeral is null or empty. Otherwise, <c>string</c> with the format accordingly with the validation option.
        /// </returns>
        private static string ToCorrectFormat(this string numeral, ValidationOptions validationOptions)
        {
            if (string.IsNullOrEmpty(numeral))
                return null;

            if (validationOptions == ValidationOptions.None)
                return numeral.ToUpper().Trim();

            else if (validationOptions == ValidationOptions.KeepEmptySpaces)
                return numeral.ToUpper();

            else if (validationOptions == ValidationOptions.KeepCapitalization)
                return numeral.Trim();

            else
                return numeral;
        }

        /// <summary>
        /// Determines whether the numeral has any character that is not in the 'ValidCharacters' list.
        /// </summary>
        /// <param name="numeral">The numeral.</param>
        /// <returns>
        ///     <c>true</c> if numeral has at least one invalid character; otherwise, <c>false</c>.
        /// </returns>
        private static bool HasInvalidCharacter(this string numeral)
        {
            return numeral.Any(character => !ValidCharacters.Contains(character));
        }

        /// <summary>
        /// Determines whether the numeral has any of the pairs of the 'InvalidPairs' list.
        /// </summary>
        /// <param name="numeral">The numeral.</param>
        /// <returns>
        ///     <c>true</c> if numeral has at least one invalid pair; otherwise, <c>false</c>.
        /// </returns>
        private static bool HasInvalidPairOfCharacters(this string numeral)
        {
            return InvalidPairs.Any(combination => numeral.Contains(combination));
        }

        /// <summary>
        /// Determines whether the numeral has any of the repetitions of the 'InvalidRepetitions' list.
        /// </summary>
        /// <param name="numeral">The numeral.</param>
        /// <returns>
        ///     <c>true</c> if numeral has at least one invalid repetition; otherwise, <c>false</c>.
        /// </returns>
        private static bool HasInvalidRepetitionOfCharacters(this string numeral)
        {
            return InvalidRepetitions.Any(repetition => numeral.Contains(repetition));
        }

        #region Invalid Sequences Validations
        /// <summary>
        /// Determines whether the numeral has any of the invalid sequences of characters.
        /// </summary>
        /// <param name="numeral">The numeral.</param>
        /// <returns>
        ///     <c>true</c> if numeral has at least one invalid sequence of characters; otherwise, <c>false</c>.
        /// </returns>
        private static bool HasInvalidSequenceOfCharacters(this string numeral)
        {
            var chars = numeral.ToCharArray();
            var numeralLength = chars.Length;

            if (numeralLength >= 3)
                return ThreeAscendingCharsInARow(chars, numeralLength)
                    || RepetitionOfCharWithBiggerOnRight(chars, numeralLength)
                    || FirstSmallerThanTwoOnRight(chars, numeralLength)
                    || InvalidPalindromeTriplet(chars, numeralLength);

            return false;
        }

        /// <summary>
        /// Rule that verify if a palindrome sequence of type 'n n-1 n' occurs in any triplet, being 'n' an index of ValidCharacters list.
        /// Examples: VIV, XVX, LXL, etc.
        /// </summary>
        /// <param name="chars">The roman numeral characters.</param>
        /// <param name="numeralLength">Length of the roman numeral.</param>
        /// <returns>
        ///     <c>true</c> if the numeral has at least one triplet of type 'n n-1 n'; otherwise, <c>false</c>.
        /// </returns>
        private static bool InvalidPalindromeTriplet(char[] chars, int numeralLength)
        {
            for (int i = 0; i < numeralLength - 2; i++)
            {
                var firstChar = chars[i];
                var secondChar = chars[i + 1];
                var thirdChar = chars[i + 2];

                if (firstChar == thirdChar && 
                    CharacterValues[secondChar] < CharacterValues[firstChar] &&
                    !ValidPalindromes.Contains(string.Format("{0}{1}{2}", firstChar, secondChar, thirdChar)))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Rule that verify if there is a sequence of type 'n n+1 n+2' occurs in any triplet, being 'n' an index of ValidCharacters list.
        /// Examples: IVX, VXL, XLD, etc.
        /// </summary>
        /// <param name="chars">The roman numeral characters.</param>
        /// <param name="numeralLength">Length of the roman numeral.</param>
        /// <returns>
        ///     <c>true</c> if the numeral has at least one triplet of type 'n n+1 n+2'; otherwise, <c>false</c>.
        /// </returns>
        private static bool ThreeAscendingCharsInARow(char[] chars, int numeralLength)
        {
            for (int i = 0; i < numeralLength - 2; i++)
            {
                var firstValue = CharacterValues[chars[i]];
                var secondValue = CharacterValues[chars[i + 1]];
                var thirdValue = CharacterValues[chars[i + 2]];

                if (firstValue < secondValue && secondValue < thirdValue)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Rule that verify if there is any valid repetition of the same character, followed by a bigger character on the right, occurs in any triplet.
        /// Examples: IIV, XXL, XXXL, CCM, etc
        /// </summary>
        /// <param name="chars">The roman numeral characters.</param>
        /// <param name="numeralLength">Length of the roman numeral.</param>
        /// <returns>
        ///     <c>true</c> if the valid repetition is followed by a bigger character on the right; otherwise, <c>false</c>.
        /// </returns>
        private static bool RepetitionOfCharWithBiggerOnRight(char[] chars, int numeralLength)
        {
            var charsWithoutLast = chars.Take(numeralLength - 1);

            if (charsWithoutLast.Distinct().Count() == 1 && CharacterValues[chars[0]] < CharacterValues[chars.Last()])
                return true;

            return false;
        }

        /// <summary>
        /// Rule that verify if the first character in each triplet is smaller than the others two on the right.
        /// Examples: IVV, VXX, XLL, etc.
        /// </summary>
        /// <param name="chars">The roman numeral characters.</param>
        /// <param name="numeralLength">Length of the roman numeral.</param>
        /// <returns>
        ///     <c>true</c> if the first character is smaller than the others two on the right; otherwise, <c>false</c>.
        /// </returns>
        private static bool FirstSmallerThanTwoOnRight(char[] chars, int numeralLength)
        {
            for (int i = 0; i < numeralLength - 2; i++)
            {
                var first = CharacterValues[chars[i]];
                var second = CharacterValues[chars[i + 1]];
                var third = CharacterValues[chars[i + 2]];

                if (first < second && first < third)
                    return true;
            }

            return false;
        } 
        #endregion

    }
}
