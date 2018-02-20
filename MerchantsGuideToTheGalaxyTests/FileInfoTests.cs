using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantsGuideToTheGalaxy;
using MerchantsGuideToTheGalaxy.GalaxyFile;

namespace MerchantsGuideToTheGalaxyTests
{
    [TestClass]
    public class FileInfoTests
    {
        [TestMethod]
        public void TestPropertyReferenceValuesIsNotNullOnNewClass()
        {
            Assert.IsTrue(new FileInfo().ReferenceValues != null);
        }

        [TestMethod]
        public void TestPropertyQuestionsIsNotNullOnNewClass()
        {
            Assert.IsTrue(new FileInfo().Questions != null);
        }

        [TestMethod]
        public void TestPropertyOutputIsNotNullOnNewClass()
        {
            Assert.IsTrue(new FileInfo().Output != null);
        }
    }
}