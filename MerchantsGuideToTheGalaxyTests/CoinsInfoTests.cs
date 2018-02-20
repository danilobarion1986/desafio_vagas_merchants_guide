using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantsGuideToTheGalaxy;

namespace MerchantsGuideToTheGalaxyTests
{
    [TestClass]
    public class CoinsInfoTests
    {
        [TestMethod]
        public void TestPropertyRomanValueCoinsIsNotNullOnNewClass()
        {
            Assert.IsTrue(new CoinsInfo().RomanCoinValues != null);
        }

        [TestMethod]
        public void TestPropertyCreditValueCoinsIsNotNullOnNewClass()
        {
            Assert.IsTrue(new CoinsInfo().CreditCoinValues != null);
        }
    }
}