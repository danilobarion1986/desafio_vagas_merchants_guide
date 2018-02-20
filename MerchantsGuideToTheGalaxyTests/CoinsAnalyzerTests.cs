using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantsGuideToTheGalaxy;
using System.Collections.Generic;
using MerchantsGuideToTheGalaxy.Coins;

namespace MerchantsGuideToTheGalaxyTests
{
    [TestClass]
    public class CoinsAnalyzerTests
    {
        public List<string> NullArgs = null;
        public List<string> EmptyArgs = new List<string>() { };
        public CoinsAnalyzer _CoinsAnalyzer = new CoinsAnalyzer();
        public string[] RefValueToCalculateWithSilver = new string[] { "glob", "glob", "Silver", "34" };
        public string[] RefValueToCalculateWithGold = new string[] { "glob", "prok", "gold", "57800" };
        public string[] RefValueToCalculateWithIron = new string[] { "pish", "pish", "Iron", "3910" };
        public string RomanNumeralSilver = "II";
        public string RomanNumeralGold = "IV";
        public string RomanNumeralIron = "XX";
        public string CreditsRefValueToCalculateSilver = "34";
        public string CreditsRefValueToCalculateGold = "57800";
        public string CreditsRefValueToCalculateIron = "3910";
        public double CorrectCoinValueInCreditsSilver = 17.0;
        public double CorrectCoinValueInCreditsGold = 14450.0;
        public double CorrectCoinValueInCreditsIron = 195.5;
        public Dictionary<string, string> RomanRefValues = new Dictionary<string, string>() 
            {
                {"glob", "I"},
                {"prok", "V"},
                {"pish", "X"},
                {"tegj", "L"}
            };

        [TestMethod]
        public void TestValidateEmptyInputOnAnalyze()
        {
            try
            {
                this._CoinsAnalyzer.Analyze(EmptyArgs);
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("Empty parameter was not correctly validated! Exception message: {0}", ex.Message));
            }
        }

        [TestMethod]
        public void TestValidateNullInputOnAnalyze()
        {
            try
            {
                this._CoinsAnalyzer.Analyze(NullArgs);
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("Null parameter was not correctly validated! Exception message: {0}", ex.Message));
            }
        }

        #region Editar estes testes para que verifiquem as mesmas condiçõs, mas com a remoção do CoinCalculator
		//[TestMethod]
        //public void TestValidateNullInputOnCalculatingCoinValueInCredits()
        //{
        //    Assert.IsNull(_CoinsAnalyzer.GetCoinValueInCredits(null, null, null));
        //}

        //[TestMethod]
        //public void TestGetCorrectCoinValueInCreditsSilver()
        //{
        //    Assert.AreEqual(CorrectCoinValueInCreditsSilver,
        //                    _CoinsAnalyzer.GetCoinValueInCredits(RomanNumeralSilver, CreditsRefValueToCalculateSilver, RomanRefValues));
        //}

        //[TestMethod]
        //public void TestGetCorrectCoinValueInCreditsGold()
        //{
        //    Assert.AreEqual(CorrectCoinValueInCreditsGold,
        //                    _CoinsAnalyzer.GetCoinValueInCredits(RomanNumeralGold, CreditsRefValueToCalculateGold, RomanRefValues));
        //}

        //[TestMethod]
        //public void TestGetCorrectCoinValueInCreditsIron()
        //{
        //    Assert.AreEqual(CorrectCoinValueInCreditsIron,
        //                    _CoinsAnalyzer.GetCoinValueInCredits(RomanNumeralIron, CreditsRefValueToCalculateIron, RomanRefValues));
        //}
 
	#endregion
    }
}