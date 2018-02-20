using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantsGuideToTheGalaxy;
using MerchantsGuideToTheGalaxy.AncientRome;

namespace MerchantsGuideToTheGalaxyTests
{
    [TestClass]
    public class RomanNumeralTests
    {
        public string ValidRomanNumeral = "MMXVII";
        public string NumeralWithInvalidCharacter = "IIR";
        public string NumeralWithInvalidRepetition = "MMMDDXVIIC";
        public string NumeralWithInvalidPair = "XVL";
        public string NumeralWithThreeAscendingCharsInARow = "VXL";
        public string NumeralWithRepetitionOfCharWithBiggerOnRight = "IIV";
        public string NumeralWithFirstSmallerThanTwoOnRight = "ILX";
        public string NumeralWithInvalidPalindromeTriplet = "XVX";
        public string ValidRomanNumeralToConvert = "MMCDXLVII";
        public int ValidRomanNumeralArabicValue = 2447;
        public string ValidNumeralWithEmptySpace = " MMCDXLVII ";
        public string ValidNumeralWithLowerCase = "mmcdxlvii";
        public string ValidNumeralWithLowerCaseAndEmptySpace = " mmcdxlvii ";
        public string StringWithAtLeastOneValidNumeral = "glob is I";
        public string StringWithNoValidNumeral = "_er_yfu_ fate";

        [TestMethod]
        public void TestValidNumeralIsValid()
        {
            Assert.IsTrue(RomanNumeral.IsValidNumeral(ValidRomanNumeral.ToCharArray()));
        }

        [TestMethod]
        public void TestNumeralWithInvalidCharacterIsInvalid()
        {
            Assert.IsFalse(RomanNumeral.IsValidNumeral(NumeralWithInvalidCharacter.ToCharArray()));
        }

        [TestMethod]
        public void TestNumeralWithInvalidPalindromeTripletIsInvalid()
        {
            Assert.IsFalse(RomanNumeral.IsValidNumeral(NumeralWithInvalidPalindromeTriplet.ToCharArray()));
        }

        [TestMethod]
        public void TestNumeralWithFirstSmallerThanTwoOnRightIsInvalid()
        {
            Assert.IsFalse(RomanNumeral.IsValidNumeral(NumeralWithFirstSmallerThanTwoOnRight.ToCharArray()));
        }

        [TestMethod]
        public void TestNumeralWithRepetitionOfCharWithBiggerOnRightIsInvalid()
        {
            Assert.IsFalse(RomanNumeral.IsValidNumeral(NumeralWithRepetitionOfCharWithBiggerOnRight.ToCharArray()));
        }

        [TestMethod]
        public void TestNumeralWithThreeAscendingCharsInARowIsInvalid()
        {
            Assert.IsFalse(RomanNumeral.IsValidNumeral(NumeralWithThreeAscendingCharsInARow.ToCharArray()));
        }

        [TestMethod]
        public void TestNumeralWithInvalidPairIsInvalid()
        {
            Assert.IsFalse(RomanNumeral.IsValidNumeral(NumeralWithInvalidPair.ToCharArray()));
        }

        [TestMethod]
        public void TestNumeralWithInvalidRepetitionIsInvalid()
        {
            Assert.IsFalse(RomanNumeral.IsValidNumeral(NumeralWithInvalidRepetition.ToCharArray()));
        }

        [TestMethod]
        public void TestInputHasValidNumeral()
        {
            Assert.IsTrue(RomanNumeral.HasValidNumeral(StringWithAtLeastOneValidNumeral.ToCharArray()));
        }

        [TestMethod]
        public void TestInputDoesntHaveValidNumeral()
        {
            Assert.IsFalse(RomanNumeral.HasValidNumeral(StringWithNoValidNumeral.ToCharArray()));
        } 
        
        [TestMethod]
        public void TestRomanToArabicGetsCorrectValue()
        {
            Assert.AreEqual(ValidRomanNumeralArabicValue,   
                            (int)RomanNumeral.RomanToArabic(ValidRomanNumeralToConvert.ToCharArray()));
        }

        [TestMethod]
        public void TestValidateEmptyInputOnValidation()
        {
            Assert.IsTrue(RomanNumeral.IsValidNumeral(ValidNumeralWithEmptySpace.ToCharArray()));
        }

        [TestMethod]
        public void TestNumeralWithEmptySpaceIsInvalidWithKeepEmptySpacesOption()
        {
            Assert.IsFalse(RomanNumeral.IsValidNumeral(ValidNumeralWithEmptySpace.ToCharArray(), 
                                                       RomanNumeral.ValidationOptions.KeepEmptySpaces));
        }

        [TestMethod]
        public void TestNumeralWithLowerCaseIsInvalidWithKeepCapitalizationOption()
        {
            Assert.IsFalse(RomanNumeral.IsValidNumeral(ValidNumeralWithLowerCase.ToCharArray(),
                                                       RomanNumeral.ValidationOptions.KeepCapitalization));
        }

        [TestMethod]
        public void TestNumeralWithLowerCaseIsInvalidWithAsIsOption()
        {
            Assert.IsFalse(RomanNumeral.IsValidNumeral(ValidNumeralWithLowerCase.ToCharArray(),
                                                       RomanNumeral.ValidationOptions.AsIs));
        }

        [TestMethod]
        public void TestNumeralWithEmptySpaceIsInvalidWithAsIsOption()
        {
            Assert.IsFalse(RomanNumeral.IsValidNumeral(ValidNumeralWithLowerCase.ToCharArray(),
                                                       RomanNumeral.ValidationOptions.AsIs));
        }

        [TestMethod]
        public void TestNumeralWithEmptySpaceAndLowerCaseIsInvalidWithAsIsOption()
        {
            Assert.IsFalse(RomanNumeral.IsValidNumeral(ValidNumeralWithLowerCaseAndEmptySpace.ToCharArray(),
                                                       RomanNumeral.ValidationOptions.AsIs));
        }

        [TestMethod]
        public void TestValidateEmptyInputOnConversion()
        {
            Assert.AreEqual(ValidRomanNumeralArabicValue,
                            (int)RomanNumeral.RomanToArabic(ValidNumeralWithEmptySpace.ToCharArray()));
        }

        [TestMethod]
        public void TestValidateLowerCaseInputOnValidation()
        {
            Assert.IsTrue(RomanNumeral.IsValidNumeral(ValidNumeralWithLowerCase.ToCharArray()));
        }

        [TestMethod]
        public void TestValidateLowerCaseInputOnConversion()
        {
            Assert.AreEqual(ValidRomanNumeralArabicValue,
                            (int)RomanNumeral.RomanToArabic(ValidNumeralWithLowerCase.ToCharArray()));
        }

        [TestMethod]
        public void TestValidateNullOrEmptyStringOnValidation()
        {
            Assert.IsFalse(RomanNumeral.IsValidNumeral(null));
        }

        [TestMethod]
        public void TestValidateNullOrEmptyCharArrayOnConversion()
        {
            Assert.IsNull(RomanNumeral.RomanToArabic(new char[] {}));
        }

    }
}