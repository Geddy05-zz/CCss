using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simple_solutions.Models;

namespace Simple_solutions
{
    class QueryManager
    {
        private GraphClient client;
        private String serverAddress = "http://145.24.222.101:8001/db/data";
        private String serverAddressForTestOnly = "http://localhost:7474/db/data";

        private void initClientConnection()
        {
            try
            {
                if (this.client != null)
                {
                    return;
                }
                this.client = new GraphClient(new Uri(serverAddress));
                this.client.Connect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Could not make connection to database, check if database server is on and try again.");
            }


        }

        public void queryMoederbord(Moederbord moederbordNode,CPU processorNode,GeheugenKaart geheugenNode,List<Moederbord> listMoederB)
        {
            // This query is to return the motherbord node.

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor),(g:Geheugen)")
                .Where((Moederbord m) => m.Geheugenslots == moederbordNode.Geheugenslots)
                .AndWhere((CPU p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere((GeheugenKaart g) => g.Geheugen == geheugenNode.Geheugen)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .AndWhere("g.Geheugentype = m.Geheugentype")
                .ReturnDistinct((m) => new
                {
                    listM = m.As<Moederbord>(),
                })
                .Results;
                

            foreach(var a in result)
            {
                listMoederB.Add(a.listM);
            }

        }

        public void queryProcessor(Moederbord moederbordNode,CPU processorNode,GeheugenKaart geheugenNode,List<CPU> listProcessor)
        {
            // This query is to return the CPU node.

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor),(g:Geheugen)")
                .Where((Moederbord m) => m.Geheugenslots == moederbordNode.Geheugenslots)
                .AndWhere((CPU p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere((GeheugenKaart g) => g.Geheugen == geheugenNode.Geheugen)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .AndWhere("g.Geheugentype = m.Geheugentype")
                .ReturnDistinct((p) => new
                {
                    listP = p.As<CPU>(),
                })
                .Results;


            foreach (var a in result)
            {
                listProcessor.Add(a.listP);
            }

        }
        
        public void queryGeheugenKaart(Moederbord moederbordNode,CPU processorNode,GeheugenKaart geheugenNode,List<GeheugenKaart> listGeheugenkaart)
        {
            // This query is to return the RAM node.

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor),(g:Geheugen)")
                .Where((Moederbord m) => m.Geheugenslots == moederbordNode.Geheugenslots)
                .AndWhere((CPU p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere((GeheugenKaart g) => g.Geheugen == geheugenNode.Geheugen)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .AndWhere("g.Geheugentype = m.Geheugentype")
                .ReturnDistinct((g) => new
                {
                    listG = g.As<GeheugenKaart>(),
                })
                .Results;


            foreach (var a in result)
            {
                listGeheugenkaart.Add(a.listG);
            }

        }

        public void queryOptischedrive(Optischedrives optischeDrivesNode, List<Optischedrives> listOptischeDrives)
        {
            // This query is to return the optical drive node.

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (o:Optischedrives)")
                .Where((Optischedrives o) => o.Categorie == optischeDrivesNode.Categorie)
                .ReturnDistinct((o) => new
                {
                    listO = o.As<Optischedrives>(),
                })
                .Limit(500)
                .Results;


            foreach (var a in result)
            {
                listOptischeDrives.Add(a.listO);
            }

        }

        public void queryHardeschijf(Hardeschijf hardeschijfNode, List<Hardeschijf> listHardeschijf)
        {
            // This query is to return the hard drive node.

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (h:Hardeschijf)")
                .Where("h.Opslag >= " + hardeschijfNode.MinimumOpslag + " AND h.Opslag <= " + hardeschijfNode.MaximumOpslag)
                .AndWhere((Hardeschijf h) => h.Soort == hardeschijfNode.Soort)
                .ReturnDistinct((h) => new
                {
                    listH = h.As<Hardeschijf>(),
                })
                .Limit(500)
                .Results;


            foreach (var a in result)
            {
                listHardeschijf.Add(a.listH);
            }

        }

        public void queryVoeding(List<Voeding> listVoeding)
        {
            // This query is to retrieve the psu node.

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (v:Voeding)")
                .ReturnDistinct((v) => new
                {
                    listV = v.As<Voeding>(),
                })
                .Limit(500)
                .Results;


            foreach (var a in result)
            {
                listVoeding.Add(a.listV);
            }

        }

        public void queryGrafischekaart(GrafischeKaart grafischekaartNode, List<GrafischeKaart> listGrafischeKaart)
        {
            // This query is to return the grafic Card node.

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (g:Grafischekaart)")
                .Where((GrafischeKaart g) => g.Typegeheugen == grafischekaartNode.Typegeheugen && g.Videogeheugen == grafischekaartNode.Videogeheugen )
                .ReturnDistinct((g) => new
                {
                    listG = g.As<GrafischeKaart>(),
                })
                .Limit(500)
                .Results;


            foreach (var a in result)
            {
                listGrafischeKaart.Add(a.listG);
            }

        }

        public void queryKoeler(CPU processorNode,List<CPUKoeler> listCPUKoeler)
        {
            // This query is to retrieve the cpu cooler node.

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (p:Processor),(k:Koeler)")
                .Where((CPU p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere("p.Socket = k.Socket")
                .ReturnDistinct((k) => new
                {
                    listK = k.As<CPUKoeler>(),
                })
                .Limit(500)
                .Results;


            foreach (var a in result)
            {
                listCPUKoeler.Add(a.listK);
            }

        }

        public void queryBehuizing(Moederbord moederbordNode, List<Behuizing> listBehuizing)
        {
            // This query is to retrieve the behuizing node

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (m:Moederbord),(b:Behuizing)")
                .Where((Moederbord m) => m.Geheugenslots == moederbordNode.Geheugenslots)
                .AndWhere(" m.Vormfactor = b.Vormfactor")
                .ReturnDistinct((b) => new
                {
                    listB = b.As<Behuizing>(),
                })
                .Limit(500)
                .Results;


            foreach (var a in result)
            {
                listBehuizing.Add(a.listB);
            }

        }

        public void runAllQuery(SearchPropertiesModel searchPropertiesModel, List<Moederbord> ListNodeMoederbord, List<CPU> listProcessor, List<GeheugenKaart> listGeheugenkaart, List<Optischedrives> listNOptischedrives,
            List<Hardeschijf> listHardeschijf, List<GrafischeKaart> listGrafischekaart, List<CPUKoeler> listCPUKoeler,
            List<Voeding> listVoeding, List<Behuizing> listBehuizing)
        {

            //Create objects With the properties needed to run the queries.

            Moederbord moederbordNode = new Moederbord();
            moederbordNode.Geheugenslots = searchPropertiesModel.geheugenslots;


            CPU processorNode = new CPU();
            processorNode.Cores = searchPropertiesModel.processorcores;
            processorNode.Model = searchPropertiesModel.processorType;
            processorNode.MinimumKloksnelheid = processorNode.setMinimumRange(searchPropertiesModel.processorsnelheid);
            processorNode.MaximumKloksnelheid = processorNode.setMaximumRange(searchPropertiesModel.processorsnelheid);

            GeheugenKaart geheugenNode = new GeheugenKaart();
            geheugenNode.Geheugenslots = searchPropertiesModel.geheugenslots;
            geheugenNode.Geheugen = searchPropertiesModel.geheugensnelheid;

            Hardeschijf hardeschijfNode = new Hardeschijf();
            hardeschijfNode.Soort = searchPropertiesModel.hardeschijftype;
            hardeschijfNode.MinimumOpslag = hardeschijfNode.setMinimumRange(searchPropertiesModel.hardeschijfopslag);
            hardeschijfNode.MaximumOpslag = hardeschijfNode.setMaximumRange(searchPropertiesModel.hardeschijfopslag);

            GrafischeKaart grafischekaartNode = new GrafischeKaart();
            grafischekaartNode.Videogeheugen = searchPropertiesModel.grafischekaartvideogeheugen;
            grafischekaartNode.Typegeheugen = searchPropertiesModel.grafischekaarttype;

            Optischedrives optischedrivesNode = new Optischedrives();
            optischedrivesNode.Categorie = searchPropertiesModel.optischedrivescategorie;

            //Run all the queries necesary to retrieve the nodes
            queryMoederbord(moederbordNode, processorNode, geheugenNode, ListNodeMoederbord);
            queryProcessor(moederbordNode, processorNode, geheugenNode, listProcessor);
            queryGeheugenKaart(moederbordNode, processorNode, geheugenNode, listGeheugenkaart);
            queryHardeschijf(hardeschijfNode, listHardeschijf);
            queryGrafischekaart(grafischekaartNode, listGrafischekaart);
            queryOptischedrive(optischedrivesNode,listNOptischedrives);
            queryKoeler(processorNode, listCPUKoeler);
            queryVoeding(listVoeding);
            queryBehuizing(moederbordNode, listBehuizing);

        }
    }
}
