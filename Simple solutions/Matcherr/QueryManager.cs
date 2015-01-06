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
    /// <summary>
    /// QueryManager class has all the queries necessary 
    /// </summary>
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
       
        public void queryReadMotherboard(Motherboard moederbordNode,Processor processorNode,RAM geheugenNode,List<Motherboard> listMoederB)
        {
            // This query is to return the motherbord node.

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor),(g:Geheugen)")
                .Where((Motherboard m) => m.Geheugenslots == moederbordNode.Geheugenslots)
                .AndWhere((Processor p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere((RAM g) => g.Geheugen == geheugenNode.Geheugen)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .AndWhere("g.Geheugentype = m.Geheugentype")
                .ReturnDistinct((m) => new
                {
                    listM = m.As<Motherboard>(),
                })
                .Results;
                

            foreach(var a in result)
            {
                listMoederB.Add(a.listM);
            }

        }

        public void queryReadProcessor(Motherboard moederbordNode,Processor processorNode,RAM geheugenNode,List<Processor> listProcessor)
        {
            // This query is to return the CPU node.

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor),(g:Geheugen)")
                .Where((Motherboard m) => m.Geheugenslots == moederbordNode.Geheugenslots)
                .AndWhere((Processor p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere((RAM g) => g.Geheugen == geheugenNode.Geheugen)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .AndWhere("g.Geheugentype = m.Geheugentype")
                .ReturnDistinct((p) => new
                {
                    listP = p.As<Processor>(),
                })
                .Results;


            foreach (var a in result)
            {
                listProcessor.Add(a.listP);
            }

        }
        
        public void queryReadRAM(Motherboard moederbordNode,Processor processorNode,RAM geheugenNode,List<RAM> listGeheugenkaart)
        {
            // This query is to return the RAM node.

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor),(g:Geheugen)")
                .Where((Motherboard m) => m.Geheugenslots == moederbordNode.Geheugenslots)
                .AndWhere((Processor p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere((RAM g) => g.Geheugen == geheugenNode.Geheugen)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .AndWhere("g.Geheugentype = m.Geheugentype")
                .ReturnDistinct((g) => new
                {
                    listG = g.As<RAM>(),
                })
                .Results;


            foreach (var a in result)
            {
                listGeheugenkaart.Add(a.listG);
            }

        }

        public void queryReadOpticalDrive(OpticalDrive optischeDrivesNode, List<OpticalDrive> listOptischeDrives)
        {
            // This query is to return the optical drive node.

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (o:Optischedrives)")
                .Where((OpticalDrive o) => o.Categorie == optischeDrivesNode.Categorie)
                .ReturnDistinct((o) => new
                {
                    listO = o.As<OpticalDrive>(),
                })
                .Limit(500)
                .Results;


            foreach (var a in result)
            {
                listOptischeDrives.Add(a.listO);
            }

        }

        public void queryReadHardDrive(HardDrive hardeschijfNode, List<HardDrive> listHardeschijf)
        {
            // This query is to return the hard drive node.

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (h:Hardeschijf)")
                .Where("h.Opslag >= " + hardeschijfNode.MinimumOpslag + " AND h.Opslag <= " + hardeschijfNode.MaximumOpslag)
                .AndWhere((HardDrive h) => h.Soort == hardeschijfNode.Soort)
                .ReturnDistinct((h) => new
                {
                    listH = h.As<HardDrive>(),
                })
                .Limit(500)
                .Results;


            foreach (var a in result)
            {
                listHardeschijf.Add(a.listH);
            }

        }

        public void queryReadPowerSupply(List<PowerSupply> listVoeding)
        {
            // This query is to retrieve the psu node.

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (v:Voeding)")
                .ReturnDistinct((v) => new
                {
                    listV = v.As<PowerSupply>(),
                })
                .Limit(500)
                .Results;


            foreach (var a in result)
            {
                listVoeding.Add(a.listV);
            }

        }

        public void queryReadGraphicCard(GraphicCard grafischekaartNode, List<GraphicCard> listGrafischeKaart)
        {
            // This query is to return the grafic Card node.

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (g:Grafischekaart)")
                .Where((GraphicCard g) => g.Typegeheugen == grafischekaartNode.Typegeheugen && g.Videogeheugen == grafischekaartNode.Videogeheugen )
                .ReturnDistinct((g) => new
                {
                    listG = g.As<GraphicCard>(),
                })
                .Limit(500)
                .Results;


            foreach (var a in result)
            {
                listGrafischeKaart.Add(a.listG);
            }

        }

        public void queryReadCooler(Processor processorNode,List<ProcessorCooler> listCPUKoeler)
        {
            // This query is to retrieve the cpu cooler node.

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (p:Processor),(k:Koeler)")
                .Where((Processor p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere("p.Socket = k.Socket")
                .ReturnDistinct((k) => new
                {
                    listK = k.As<ProcessorCooler>(),
                })
                .Limit(500)
                .Results;


            foreach (var a in result)
            {
                listCPUKoeler.Add(a.listK);
            }

        }

        public void queryReadComputerCase(Motherboard moederbordNode, List<ComputerCase> listBehuizing)
        {
            // This query is to retrieve the behuizing node

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (m:Moederbord),(b:Behuizing)")
                .Where((Motherboard m) => m.Geheugenslots == moederbordNode.Geheugenslots)
                .AndWhere(" m.Vormfactor = b.Vormfactor")
                .ReturnDistinct((b) => new
                {
                    listB = b.As<ComputerCase>(),
                })
                .Limit(500)
                .Results;


            foreach (var a in result)
            {
                listBehuizing.Add(a.listB);
            }

        }

        public void runAllQuery(SearchPropertiesModel searchPropertiesModel, List<Motherboard> ListNodeMoederbord, List<Processor> listProcessor, List<RAM> listGeheugenkaart, List<OpticalDrive> listNOptischedrives,
            List<HardDrive> listHardeschijf, List<GraphicCard> listGrafischekaart, List<ProcessorCooler> listCPUKoeler,
            List<PowerSupply> listVoeding, List<ComputerCase> listBehuizing)
        {

            //Create objects With the properties needed to run the queries.

            Motherboard moederbordNode = new Motherboard();
            moederbordNode.Geheugenslots = searchPropertiesModel.memorySlots;


            Processor processorNode = new Processor();
            processorNode.Cores = searchPropertiesModel.processorcores;
            processorNode.Model = searchPropertiesModel.processorType;
            processorNode.MinimumKloksnelheid = processorNode.setMinimumRange(searchPropertiesModel.processorClockSpeed);
            processorNode.MaximumKloksnelheid = processorNode.setMaximumRange(searchPropertiesModel.processorClockSpeed);

            RAM geheugenNode = new RAM();
            geheugenNode.Geheugenslots = searchPropertiesModel.memorySlots;
            geheugenNode.Geheugen = searchPropertiesModel.memorySpeed;

            HardDrive hardeschijfNode = new HardDrive();
            hardeschijfNode.Soort = searchPropertiesModel.hardDrivetype;
            hardeschijfNode.MinimumOpslag = hardeschijfNode.setMinimumRange(searchPropertiesModel.hardDriveCapacity);
            hardeschijfNode.MaximumOpslag = hardeschijfNode.setMaximumRange(searchPropertiesModel.hardDriveCapacity);

            GraphicCard grafischekaartNode = new GraphicCard();
            grafischekaartNode.Videogeheugen = searchPropertiesModel.graphicCardSpeed;
            grafischekaartNode.Typegeheugen = searchPropertiesModel.graphicCardType;

            OpticalDrive optischedrivesNode = new OpticalDrive();
            optischedrivesNode.Categorie = searchPropertiesModel.opticalDriveCategory;

            //Run all the queries necesary to retrieve the nodes
            queryReadMotherboard(moederbordNode, processorNode, geheugenNode, ListNodeMoederbord);
            queryReadProcessor(moederbordNode, processorNode, geheugenNode, listProcessor);
            queryReadRAM(moederbordNode, processorNode, geheugenNode, listGeheugenkaart);
            queryReadHardDrive(hardeschijfNode, listHardeschijf);
            queryReadGraphicCard(grafischekaartNode, listGrafischekaart);
            queryReadOpticalDrive(optischedrivesNode,listNOptischedrives);
            queryReadCooler(processorNode, listCPUKoeler);
            queryReadPowerSupply(listVoeding);
            queryReadComputerCase(moederbordNode, listBehuizing);

        }
    }
}
