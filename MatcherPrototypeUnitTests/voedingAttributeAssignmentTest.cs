using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatcherPrototypeUnitTests
{
    [TestClass]
    public class voedingAttributeAssignmentTest
    {
        [TestMethod]
        public void testVoedingAttributeAssignments()
        {
            /** assign variables **/
            MatcherPrototype.Voeding testVoeding = new MatcherPrototype.Voeding()
            {
                Naam = "testNaam1 3",
                Prijs = "testPrijs1 3",
                Url = "testUrl1 3",
                Wattage = "testWattage1 3"                
            };

            /** assert if variables are stored correctly **/
            Assert.IsInstanceOfType(testVoeding, typeof(object));
            Assert.AreEqual(testVoeding.Naam, "testNaam1 3");
            Assert.AreEqual(testVoeding.Prijs, "testPrijs1 3");
            Assert.AreEqual(testVoeding.Url, "testUrl1 3");
            Assert.AreEqual(testVoeding.Wattage, "testWattage1 3");
        }
    }
}
