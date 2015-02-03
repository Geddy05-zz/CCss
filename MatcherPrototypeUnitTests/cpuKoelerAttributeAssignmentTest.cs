using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatcherPrototypeUnitTests
{
    [TestClass]
    public class cpuKoelerAttributeAssignmentTest
    {
        [TestMethod]
        public void testCPUKoelerAttributeAssignments()
        {
            /** assign variables **/
            MatcherPrototype.CPUKoeler testCPUKoeler = new MatcherPrototype.CPUKoeler()
            {
                Naam = "testNaam1 3",
                Prijs = "testPrijs1 3",
                Url = "testUrl1 3",
                Socket = "testSocket1 3"
           };

            /** assert if variables are stored correctly **/
            Assert.IsInstanceOfType(testCPUKoeler, typeof(object));
            Assert.AreEqual(testCPUKoeler.Naam, "testNaam1 3");
            Assert.AreEqual(testCPUKoeler.Prijs, "testPrijs1 3");
            Assert.AreEqual(testCPUKoeler.Url, "testUrl1 3");
            Assert.AreEqual(testCPUKoeler.Socket, "testSocket1 3");
        }
    }
}
