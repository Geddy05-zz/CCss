using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatcherPrototypeUnitTests
{
    [TestClass]
    public class behuizingAttributeAssignmentTest
    {
        [TestMethod]
        public void testBehuizingAttributeAssignments()
        {
            /** assign variables **/
            MatcherPrototype.Behuizing testBehuizing = new MatcherPrototype.Behuizing()
            {
                Naam = "testNaam1 3",
                Prijs = "testPrijs1 3",
                Url = "testUrl1 3",
                Vormfactor = "testVormfactor1 3"
            };

            /** assert if variables are stored correctly **/
            Assert.IsInstanceOfType(testBehuizing, typeof(object));
            Assert.AreEqual(testBehuizing.Naam, "testNaam1 3");
            Assert.AreEqual(testBehuizing.Prijs, "testPrijs1 3");
            Assert.AreEqual(testBehuizing.Url, "testUrl1 3");
            Assert.AreEqual(testBehuizing.Vormfactor, "testVormfactor1 3");
        }
    }
}
