using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatcherPrototypeUnitTests
{
    [TestClass]
    public class optischeDrivesAttributeAssignmenttest
    {
        [TestMethod]
        public void testOptischeDrivesAttributeAssignments()
        {
            /** assign variables **/
            MatcherPrototype.Optischedrives testOptischedrive = new MatcherPrototype.Optischedrives()
            {
                Naam = "testNaam1 3",
                Prijs = "testPrijs1 3",
                Url = "testUrl1 3",
                Categorie = "testCategorie1 3"
            };

            /** assert if variables are stored correctly **/
            Assert.IsInstanceOfType(testOptischedrive, typeof(object));
            Assert.AreEqual(testOptischedrive.Naam, "testNaam1 3");
            Assert.AreEqual(testOptischedrive.Prijs, "testPrijs1 3");
            Assert.AreEqual(testOptischedrive.Url, "testUrl1 3");
            Assert.AreEqual(testOptischedrive.Categorie, "testCategorie1 3");
        }
    }
}
