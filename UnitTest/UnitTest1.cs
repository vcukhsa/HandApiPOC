using Microsoft.VisualStudio.TestTools.UnitTesting;
using HandApiTest.Utilities;
using HandApiTest.Models;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            OrganismSection organismSection = new()
            {
                OrganismCode = "ORG001",
            };

            string str = CommaDelimitedPrinter.PrintObject(organismSection);
            Assert.AreEqual("\"(*ORGANISMS\",\"ORG001\",\"ORGANISMS*)\",", str);
        }
    }
}
