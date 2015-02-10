using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatcherPrototypeUnitTests
{
    [TestClass]
    public class hardeSchijfAttributeAssignmentTest
    {
        [TestMethod]
        public void testHardeSchijfAttributeAssignments()
        {
            /** assign variables **/
            MatcherPrototype.Hardeschijf testHardeschijf = new MatcherPrototype.Hardeschijf()
            {
                Naam = "testNaam1 3",
                Prijs = "testPrijs1 3",
                Url = "testUrl1 3",
                Soort = "testSoort1 3",
                MinimumOpslag = 500,
                MaximumOpslag = 1000,
                Opslag = "testOpslag1 3"
            };

            /** assert if variables are stored correctly **/
            Assert.IsInstanceOfType(testHardeschijf, typeof(object));
            Assert.AreEqual(testHardeschijf.Naam, "testNaam1 3");
            Assert.AreEqual(testHardeschijf.Prijs, "testPrijs1 3");
            Assert.AreEqual(testHardeschijf.Url, "testUrl1 3");
            Assert.AreEqual(testHardeschijf.Soort, "testSoort1 3");
            Assert.AreEqual(testHardeschijf.MinimumOpslag, 500);
            Assert.AreEqual(testHardeschijf.MaximumOpslag, 1000);
            Assert.AreEqual(testHardeschijf.Opslag, "testOpslag1 3");
        }
    }
}
