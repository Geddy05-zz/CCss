using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MatcherPrototype;

namespace MatcherPrototypeUnitTests
{
    [TestClass]

        public class matcherPriceComparisonTest
            {
                [TestMethod]
                    public void testPriceComparison()
                    {

                        /** arrange testvariables **/
                        List<MatcherPrototype.Moederbord> listMoederbordsUnsorted = new List<MatcherPrototype.Moederbord>();
                        listMoederbordsUnsorted.Add(new MatcherPrototype.Moederbord(){Naam="lowest", Prijs="15"});
                        listMoederbordsUnsorted.Add(new MatcherPrototype.Moederbord(){Naam="highest", Prijs="16.05"});

                        List<MatcherPrototype.CPU> listCPUUnsorted = new List<MatcherPrototype.CPU>();
                        listCPUUnsorted.Add(new MatcherPrototype.CPU(){Naam="lowest", Prijs="60"});
                        listCPUUnsorted.Add(new MatcherPrototype.CPU(){Naam="highest", Prijs="1055.05"});

                        List<MatcherPrototype.GeheugenKaart> listGeheugenUnsorted = new List<MatcherPrototype.GeheugenKaart>();
                        listGeheugenUnsorted.Add(new MatcherPrototype.GeheugenKaart() { Naam = "highest", Prijs = "10" });
                        listGeheugenUnsorted.Add(new MatcherPrototype.GeheugenKaart() { Naam = "lowest", Prijs = "0" });

                        List<MatcherPrototype.Optischedrives> listOptischedrivesUnsorted = new List<MatcherPrototype.Optischedrives>();
                        listOptischedrivesUnsorted.Add(new MatcherPrototype.Optischedrives() { Naam = "lowest", Prijs = "6" });
                        listOptischedrivesUnsorted.Add(new MatcherPrototype.Optischedrives() { Naam = "highest", Prijs = "15" });

                        List<MatcherPrototype.Hardeschijf> listHardeschijfUnsorted = new List<MatcherPrototype.Hardeschijf>();
                        listHardeschijfUnsorted.Add(new MatcherPrototype.Hardeschijf() { Naam = "highest", Prijs = "15.72" });
                        listHardeschijfUnsorted.Add(new MatcherPrototype.Hardeschijf() { Naam = "lowest", Prijs = "15.71" });

                        List<MatcherPrototype.GrafischeKaart> listGrafischekaartUnsorted = new List<MatcherPrototype.GrafischeKaart>();
                        listGrafischekaartUnsorted.Add(new MatcherPrototype.GrafischeKaart() { Naam = "lowest", Prijs = "1" });
                        listGrafischekaartUnsorted.Add(new MatcherPrototype.GrafischeKaart() { Naam = "highest", Prijs = "10000" });

                        List<MatcherPrototype.CPUKoeler> listCPUKoelerUnsorted = new List<MatcherPrototype.CPUKoeler>();
                        listCPUKoelerUnsorted.Add(new MatcherPrototype.CPUKoeler() { Naam = "highest", Prijs = "95" });
                        listCPUKoelerUnsorted.Add(new MatcherPrototype.CPUKoeler() { Naam = "lowest", Prijs = "54" });

                        List<MatcherPrototype.Voeding> listVoedingUnsorted = new List<MatcherPrototype.Voeding>();
                        listVoedingUnsorted.Add(new MatcherPrototype.Voeding() { Naam = "lowest", Prijs = "5" });
                        listVoedingUnsorted.Add(new MatcherPrototype.Voeding() { Naam = "highest", Prijs = "65" });

                        List<MatcherPrototype.Behuizing> listBehuizingUnsorted = new List<MatcherPrototype.Behuizing>();
                        listBehuizingUnsorted.Add(new MatcherPrototype.Behuizing() { Naam = "highest", Prijs = "56.79" });
                        listBehuizingUnsorted.Add(new MatcherPrototype.Behuizing() { Naam = "lowest", Prijs = "45.54" });

                        MatcherPrototype.Matcher testMatcher = new MatcherPrototype.Matcher();

                        /** execute function matchComponentsWithLowestPrice **/
                        testMatcher.matchComponentsWithLowestPrice(listMoederbordsUnsorted, listCPUUnsorted, listGeheugenUnsorted, listOptischedrivesUnsorted,listHardeschijfUnsorted, listGrafischekaartUnsorted, listCPUKoelerUnsorted, listVoedingUnsorted, listBehuizingUnsorted);

                        /** assert if all elements in all lists were sorted correctly **/
                        Assert.AreEqual(listMoederbordsUnsorted[1].Naam, "highest");
                        Assert.AreEqual(listCPUUnsorted[1].Naam, "highest");
                        Assert.AreEqual(listGeheugenUnsorted[1].Naam, "highest");
                        Assert.AreEqual(listOptischedrivesUnsorted[1].Naam, "highest");
                        Assert.AreEqual(listHardeschijfUnsorted[1].Naam, "highest");
                        Assert.AreEqual(listGrafischekaartUnsorted[1].Naam, "highest");
                        Assert.AreEqual(listCPUKoelerUnsorted[1].Naam, "highest");
                        Assert.AreEqual(listVoedingUnsorted[1].Naam, "highest");
                        Assert.AreEqual(listBehuizingUnsorted[1].Naam, "highest");
                    }
    }
}
