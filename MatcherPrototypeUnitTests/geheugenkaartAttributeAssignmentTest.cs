using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatcherPrototypeUnitTests
{
    [TestClass]
    public class geheugenkaartAttributeAssignmentTest
    {
        [TestMethod]
        public void testGeheugenkaartAttributeAssignments()
        {
            /** assign variables **/
            MatcherPrototype.GeheugenKaart testGeheugenkaart = new MatcherPrototype.GeheugenKaart()
            {
                Naam = "testNaam1 3",
                Prijs = "testPrijs1 3",
                Url = "testUrl1 3",
                Geheugenkloksnelehid = "testGeheugenkloksnelheid1 3",
                Geheugenslots = "testGeheugenslots1 3",
                Geheugentype = "testGeheugentype1 3",
                Geheugen = "testGeheugen1 3"
            };

            /** assert if variables are stored correctly **/
            Assert.IsInstanceOfType(testGeheugenkaart, typeof(object));
            Assert.AreEqual(testGeheugenkaart.Naam, "testNaam1 3");
            Assert.AreEqual(testGeheugenkaart.Prijs, "testPrijs1 3");
            Assert.AreEqual(testGeheugenkaart.Url, "testUrl1 3");
            Assert.AreEqual(testGeheugenkaart.Geheugenkloksnelehid, "testGeheugenkloksnelheid1 3");
            Assert.AreEqual(testGeheugenkaart.Geheugenslots, "testGeheugenslots1 3");
            Assert.AreEqual(testGeheugenkaart.Geheugentype, "testGeheugentype1 3");
            Assert.AreEqual(testGeheugenkaart.Geheugen, "testGeheugen1 3");
        }
    }
}
