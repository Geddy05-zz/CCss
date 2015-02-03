using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatcherPrototypeUnitTests
{
    [TestClass]
    public class moederbordAttributeAssignmentTest
    {
        [TestMethod]
        public void testMoederbordAttributeAssignments()
        {
            /** assign variables **/
            MatcherPrototype.Moederbord testMoederbord = new MatcherPrototype.Moederbord() { 
                Naam = "testNaam1 3", 
                Prijs = "testPrijs1 3", 
                Url = "testUrl1 3", 
                Socket = "testSocket1 3", 
                Geheugenslots = "testGeheugenslots1 3", 
                Geheugentype = "testGeheugentype1 3", 
                Vormfactor = "testVormfactor1 3" 
            };

            /** assert if variables are stored correctly **/
            Assert.IsInstanceOfType(testMoederbord, typeof(object));
            Assert.AreEqual(testMoederbord.Naam, "testNaam1 3");
            Assert.AreEqual(testMoederbord.Prijs, "testPrijs1 3");
            Assert.AreEqual(testMoederbord.Url, "testUrl1 3");
            Assert.AreEqual(testMoederbord.Socket, "testSocket1 3");
            Assert.AreEqual(testMoederbord.Geheugenslots, "testGeheugenslots1 3");
            Assert.AreEqual(testMoederbord.Geheugentype, "testGeheugentype1 3");
            Assert.AreEqual(testMoederbord.Vormfactor, "testVormfactor1 3");
        }
    }
}
