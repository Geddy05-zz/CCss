using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatcherPrototypeUnitTests
{
    [TestClass]
    public class grafischeKaartAttributeAssignmentTest
    {
        [TestMethod]
        public void testGrafischeKaartAttributeAssignments()
        {
            /** assign variables **/
            MatcherPrototype.GrafischeKaart testGrafischeKaart = new MatcherPrototype.GrafischeKaart()
            {
                Naam = "testNaam1 3",
                Prijs = "testPrijs1 3",
                Url = "testUrl1 3",
                Videogeheugen = "testVideogeheugen1 3",
                Typegeheugen = "testTypeGeheugen1 3"
            };

            /** assert if variables are stored correctly **/
            Assert.IsInstanceOfType(testGrafischeKaart, typeof(object));
            Assert.AreEqual(testGrafischeKaart.Naam, "testNaam1 3");
            Assert.AreEqual(testGrafischeKaart.Prijs, "testPrijs1 3");
            Assert.AreEqual(testGrafischeKaart.Url, "testUrl1 3");
            Assert.AreEqual(testGrafischeKaart.Videogeheugen, "testVideogeheugen1 3");
            Assert.AreEqual(testGrafischeKaart.Typegeheugen, "testTypeGeheugen1 3");
        }
    }
}
