using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatcherPrototypeUnitTests
{
    [TestClass]
    public class CPUAttributeAssignmentTest
    {
        [TestMethod]
        public void testCPUAttributeAssignments()
        {
            /** assign variables **/
            MatcherPrototype.CPU testCPU = new MatcherPrototype.CPU()
            {
                Naam = "testNaam1 3",
                Prijs = "testPrijs1 3",
                Url = "testUrl1 3",
                Socket = "testSocket1 3",
                Model = "testModel1 3",
                Cores = "testCores1 3",
                Kloksnelheid = "testKloksnelheid1 3",
                MaximumKloksnelheid = 100,
                MinimumKloksnelheid = 50
            };

            

            /** assert if variables are stored correctly **/
            Assert.IsInstanceOfType(testCPU, typeof(object));
            Assert.AreEqual(testCPU.Naam, "testNaam1 3");
            Assert.AreEqual(testCPU.Prijs, "testPrijs1 3");
            Assert.AreEqual(testCPU.Url, "testUrl1 3");
            Assert.AreEqual(testCPU.Socket, "testSocket1 3");
            Assert.AreEqual(testCPU.Model, "testModel1 3");
            Assert.AreEqual(testCPU.Cores, "testCores1 3");
            Assert.AreEqual(testCPU.Kloksnelheid, "testKloksnelheid1 3");          
            Assert.AreEqual(testCPU.MaximumKloksnelheid, 100);
            Assert.AreEqual(testCPU.MinimumKloksnelheid, 50);            
        }
    }
}
