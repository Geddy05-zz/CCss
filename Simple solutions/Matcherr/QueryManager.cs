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

        private void initClientConnection()
        {
            /* this function makes connection with the neo4j database
             * it checks everytime to make sure that only one connection exist.
             */

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
       
        public void queryReadMotherboard(Motherboard motherboardNode,Processor processorNode,RAM ramNode,List<Motherboard> listMotherboard)
        {
            // This query is to return the motherbord node.

            initClientConnection();

            var result =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor),(g:Geheugen)")
                .Where((Motherboard m) => m.Geheugenslots == motherboardNode.Geheugenslots)
                .AndWhere((Processor p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere((RAM g) => g.Geheugen == ramNode.Geheugen)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .AndWhere("g.Geheugentype = m.Geheugentype")
                .ReturnDistinct((m) => new
                {
                    listM = m.As<Motherboard>(),
                })
                .Results;
               
            foreach(var a in result)
            {
                listMotherboard.Add(a.listM);
            }

            //if the first query did not yield any result.
            if(listMotherboard.Count == 0)
            {
                result =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor),(g:Geheugen)")
                .Where((Motherboard m) => m.Geheugenslots == motherboardNode.Geheugenslots)
                .AndWhere((Processor p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere((RAM g) => g.Geheugen == ramNode.Geheugen)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .ReturnDistinct((m) => new
                {
                    listM = m.As<Motherboard>(),
                })
                .Results;

                foreach (var a in result)
                {
                    listMotherboard.Add(a.listM);
                }
            }

        }

        public void queryReadProcessor(Motherboard motherboardNode,Processor processorNode,RAM RAMNode,List<Processor> listProcessor)
        {
            // This query is to return the CPU node.

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor),(g:Geheugen)")
                .Where((Motherboard m) => m.Geheugenslots == motherboardNode.Geheugenslots)
                .AndWhere((Processor p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere((RAM g) => g.Geheugen == RAMNode.Geheugen)
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

            //if the first query did not yield any result.
            if(listProcessor.Count == 0)
            {
                result =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor),(g:Geheugen)")
                .Where((Motherboard m) => m.Geheugenslots == motherboardNode.Geheugenslots)
                .AndWhere((Processor p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere((RAM g) => g.Geheugen == RAMNode.Geheugen)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
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

        }
        
        public void queryReadRAM(Motherboard motherboardNode,Processor processorNode,RAM RAMNode,List<RAM> listRAM)
        {
            // This query is to return the RAM node.

            initClientConnection();

            var result =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor),(g:Geheugen)")
                .Where((Motherboard m) => m.Geheugenslots == motherboardNode.Geheugenslots)
                .AndWhere((Processor p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere((RAM g) => g.Geheugen == RAMNode.Geheugen)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .AndWhere("g.Geheugentype = m.Geheugentype")
                .ReturnDistinct((g) => new
                {
                    listG = g.As<RAM>(),
                })
                .Results;



            foreach (var a in result)
            {
                listRAM.Add(a.listG);
            }

            //if the first query did not yield any result.
            if(listRAM.Count == 0)
            {
                result =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor),(g:Geheugen)")
                .Where((Motherboard m) => m.Geheugenslots == motherboardNode.Geheugenslots)
                .AndWhere((Processor p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere((RAM g) => g.Geheugen == RAMNode.Geheugen)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .ReturnDistinct((g) => new
                {
                    listG = g.As<RAM>(),
                })
                .Results;

                foreach (var a in result)
                {
                    listRAM.Add(a.listG);
                }
            }

        }

        public void queryReadOpticalDrive(OpticalDrive optischeDrivesNode, List<OpticalDrive> listOptischeDrives)
        {
            // This query is to return the OpticalDrive node.

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

        public void queryReadHardDrive(HardDrive hardDriveNode, List<HardDrive> listHardDrive)
        {
            // This query is to return the HardDrive node.

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (h:Hardeschijf)")
                .Where("h.Opslag >= " + hardDriveNode.MinimumOpslag + " AND h.Opslag <= " + hardDriveNode.MaximumOpslag)
                .AndWhere((HardDrive h) => h.Soort == hardDriveNode.Soort)
                .ReturnDistinct((h) => new
                {
                    listH = h.As<HardDrive>(),
                })
                .Limit(500)
                .Results;


            foreach (var a in result)
            {
                listHardDrive.Add(a.listH);
            }

        }

        public void queryReadPowerSupply(List<PowerSupply> listPowerSupply)
        {
            // This query is to retrieve the PowerSupply node.

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
                listPowerSupply.Add(a.listV);
            }

        }

        public void queryReadGraphicCard(GraphicCard graphicCardNode, List<GraphicCard> listGraphicCard)
        {
            // This query is to return the GraphicCard node.

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (g:Grafischekaart)")
                .Where((GraphicCard g) => g.Typegeheugen == graphicCardNode.Typegeheugen && g.Videogeheugen == graphicCardNode.Videogeheugen )
                .ReturnDistinct((g) => new
                {
                    listG = g.As<GraphicCard>(),
                })
                .Limit(500)
                .Results;


            foreach (var a in result)
            {
                listGraphicCard.Add(a.listG);
            }

            //if the first query did not yield any result. 
            if(listGraphicCard.Count == 0)
            {
                var Videogeheugen = graphicCardNode.Videogeheugen.Split('g');
                graphicCardNode.Videogeheugen = Videogeheugen[0];
                
                
                result =
                this.client.Cypher
                .Match(" (g:Grafischekaart)")
                .Where(" g.Typegeheugen = " + "'" + graphicCardNode.Typegeheugen + "'" + " AND g.Videogeheugen = " + Convert.ToInt32(graphicCardNode.Videogeheugen))
                .ReturnDistinct((g) => new
                {
                    listG = g.As<GraphicCard>(),
                })
                .Limit(500)
                .Results;

                foreach (var a in result)
                {
                    listGraphicCard.Add(a.listG);
                }
            }
        }

        public void queryReadCooler(Processor processorNode,List<ProcessorCooler> listProcessorCooler)
        {
            // This query is to retrieve the Processor cooler node.

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
                listProcessorCooler.Add(a.listK);
            }

        }

        public void queryReadComputerCase(Motherboard motherboardNode, List<ComputerCase> listComputerCase)
        {
            // This query is to retrieve the behuizing node

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (m:Moederbord),(b:Behuizing)")
                .Where((Motherboard m) => m.Geheugenslots == motherboardNode.Geheugenslots)
                //.AndWhere(" m.Vormfactor = b.Vormfactor")
                .ReturnDistinct((b) => new
                {
                    listB = b.As<ComputerCase>(),
                })
                .Limit(500)
                .Results;


            foreach (var a in result)
            {
                listComputerCase.Add(a.listB);
            }

        }

        public void queryReadProcessorMotherboardDefined(Processor processorNode, Motherboard motherboardNode, List<Processor> listProcessor, 
            List<Motherboard> listMotherboard, List<RAM> listRAM)
        {
            //this query is run only when the processor and motherboard are defined and we are missing the
            //ram component(not defined).

            initClientConnection();

            var resultMotherboard =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor),(g:Geheugen)")
                .Where((Motherboard m) => m.Geheugenslots == motherboardNode.Geheugenslots)
                .AndWhere((Processor p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .AndWhere("g.Geheugen = m.Geheugenslots")
                .ReturnDistinct((m) => new
                {
                    listM = m.As<Motherboard>(),
                })
                .Results;

            foreach (var a in resultMotherboard)
            {
                listMotherboard.Add(a.listM);
            }

            var resultProcessor =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor),(g:Geheugen)")
                .Where((Motherboard m) => m.Geheugenslots == motherboardNode.Geheugenslots)
                .AndWhere((Processor p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .AndWhere("g.Geheugen = m.Geheugenslots")
                .ReturnDistinct((p) => new
                {
                    listP = p.As<Processor>(),
                })
                .Results;

            foreach (var a in resultProcessor)
            {
                listProcessor.Add(a.listP);
            }

            var resultRAM =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor),(g:Geheugen)")
                .Where((Motherboard m) => m.Geheugenslots == motherboardNode.Geheugenslots)
                .AndWhere((Processor p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .AndWhere("g.Geheugen = m.Geheugenslots")
                .ReturnDistinct((g) => new
                {
                    listR = g.As<RAM>(),
                })
                .Results;

            foreach (var a in resultRAM)
            {
                listRAM.Add(a.listR);
            } 
        }

        public void queryReadProcessorRAMDefined(Processor processorNode, RAM RAMNode, List<Processor> listProcessor, 
            List<Motherboard> listMotherboard, List<RAM> listRAM)
        {
            //this query is run only when the processor and motherboard are defined and we are missing the
            //ram component(not defined).
            
            initClientConnection();

            var resultMotherboard =
                this.client.Cypher
                .Match(" (p:Processor)-[a]-(m:Moederbord),(g:Geheugen)")
                .Where((Processor p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .AndWhere((RAM g) => g.Geheugen == RAMNode.Geheugen)
                .AndWhere("g.Geheugen = m.Geheugenslots")
                .ReturnDistinct((m) => new
                {
                    listM = m.As<Motherboard>(),
                })
                .Results;

            foreach (var a in resultMotherboard)
            {
                listMotherboard.Add(a.listM);
            }

            var resultProcessor =
                this.client.Cypher
                .Match(" (p:Processor)-[a]-(m:Moederbord),(g:Geheugen)")
                .Where((Processor p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .AndWhere((RAM g) => g.Geheugen == RAMNode.Geheugen)
                .AndWhere("g.Geheugen = m.Geheugenslots")
                .ReturnDistinct((p) => new
                {
                    listP = p.As<Processor>(),
                })
                .Results;

            foreach (var a in resultProcessor)
            {
                listProcessor.Add(a.listP);
            }

            var resultRAM =
                this.client.Cypher
                .Match(" (p:Processor)-[a]-(m:Moederbord),(g:Geheugen)")
                .Where((Processor p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .AndWhere((RAM g) => g.Geheugen == RAMNode.Geheugen)
                .AndWhere("g.Geheugen = m.Geheugenslots")
                .ReturnDistinct((g) => new
                {
                    listR = g.As<RAM>(),
                })
                .Results;

            foreach (var a in resultRAM)
            {
                listRAM.Add(a.listR);
            } 
        }

        public void queryReadProcessorOnlyDefined(Processor processorNode, List<Processor> listProcessor, 
            List<Motherboard> listMotherboard, List<RAM> listRAM)
        {
            //this query is run only when the processor is defined.

            initClientConnection();

            var resultMotherboard =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor),(g:Geheugen)")
                .Where((Processor p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .AndWhere("g.Geheugen = m.Geheugenslots")
                .ReturnDistinct((m) => new
                {
                    listM = m.As<Motherboard>(),
                })
                .Results;

            foreach (var a in resultMotherboard)
            {
                listMotherboard.Add(a.listM);
            }

            var resultProcessor =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor),(g:Geheugen)")
                .Where((Processor p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .AndWhere("g.Geheugen = m.Geheugenslots")
                .ReturnDistinct((p) => new
                {
                    listP = p.As<Processor>(),
                })
                .Results;

            foreach (var a in resultProcessor)
            {
                listProcessor.Add(a.listP);
            }

            var resultRAM =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor),(g:Geheugen)")
                .Where((Processor p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .AndWhere("g.Geheugen = m.Geheugenslots")
                .ReturnDistinct((g) => new
                {
                    listR = g.As<RAM>(),
                })
                .Results;

            foreach (var a in resultRAM)
            {
                listRAM.Add(a.listR);
            } 
        }

        public Boolean isCPUPropertiesFilled(Processor cpu)
        {
            //Checks if the properties of the components processor has been filled in by the end-user.
            Boolean isFilled = false;

            if(cpu.Model.Length > 0  && cpu.Cores.Length > 0)
            {
                isFilled = true;
            }

            return isFilled;
        }

        public Boolean isMotherboardPropertiesFilled(Motherboard motherboard)
        {
            //Checks if the properties of the components motherboard has been filled in by the end-user.
            Boolean isFilled = false;

            if(motherboard.Geheugenslots.Length > 0)
            {
                isFilled = true;
            }

            return isFilled;
        }

        public Boolean isRAMPropertiesFilled(RAM ram)
        {
            //Checks if the properties of the components ram has been filled in by the end-user.
            Boolean isFilled = false;

            if(ram.Geheugen.Length > 0)
            {
                isFilled = true;
            }

            return isFilled;
        }

        public void runAllQuery(SearchPropertiesModel searchPropertiesModel, List<Motherboard> listMotherboard, List<Processor> listProcessor, List<RAM> listRAM, List<OpticalDrive> listOpticalDrive,
            List<HardDrive> listHardDrive, List<GraphicCard> listGraphicCard, List<ProcessorCooler> listProcessorCooler,
            List<PowerSupply> listPowerSupply, List<ComputerCase> listComputerCase)
        {     

            //Create objects With the properties needed to run the queries.

            Motherboard motherboardNode = new Motherboard();
            motherboardNode.Geheugenslots = searchPropertiesModel.memorySlots;


            Processor processorNode = new Processor();
            processorNode.Cores = searchPropertiesModel.processorcores;
            processorNode.Model = searchPropertiesModel.processorType;
            processorNode.MinimumKloksnelheid = processorNode.setMinimumRange(searchPropertiesModel.processorClockSpeed);
            processorNode.MaximumKloksnelheid = processorNode.setMaximumRange(searchPropertiesModel.processorClockSpeed);

            RAM ramNode = new RAM();
            ramNode.Geheugenslots = searchPropertiesModel.memorySlots;
            ramNode.Geheugen = searchPropertiesModel.memorySpeed;

            HardDrive hardDriveNode = new HardDrive();
            hardDriveNode.Soort = searchPropertiesModel.hardDrivetype;
            hardDriveNode.MinimumOpslag = hardDriveNode.setMinimumRange(searchPropertiesModel.hardDriveCapacity);
            hardDriveNode.MaximumOpslag = hardDriveNode.setMaximumRange(searchPropertiesModel.hardDriveCapacity);

            GraphicCard graphicCardNode = new GraphicCard();
            graphicCardNode.Videogeheugen = searchPropertiesModel.graphicCardSpeed;
            graphicCardNode.Typegeheugen = searchPropertiesModel.graphicCardType;

            OpticalDrive opticalDriveNode = new OpticalDrive();
            opticalDriveNode.Categorie = searchPropertiesModel.opticalDriveCategory;

            //Check if the cpu

            if((isMotherboardPropertiesFilled(motherboardNode)) && (isRAMPropertiesFilled(ramNode)) && (isCPUPropertiesFilled(processorNode)))
            {
                queryReadMotherboard(motherboardNode, processorNode, ramNode, listMotherboard);
                queryReadProcessor(motherboardNode, processorNode, ramNode, listProcessor);
                queryReadRAM(motherboardNode, processorNode, ramNode, listRAM);
            }
            else if (isCPUPropertiesFilled(processorNode))
            {
                if (isMotherboardPropertiesFilled(motherboardNode))
                {
                    //Run Query with CPU and Motherboard defined
                    queryReadProcessorMotherboardDefined(processorNode, motherboardNode, listProcessor, listMotherboard, listRAM);
                }
                else if(isRAMPropertiesFilled(ramNode))
                {
                    //Run Query with CPU and RAM defined
                    queryReadProcessorRAMDefined(processorNode, ramNode, listProcessor, listMotherboard, listRAM);
                }
                else
                {
                    //Run Query with CPU only defined. 
                    queryReadProcessorOnlyDefined(processorNode, listProcessor, listMotherboard, listRAM);
                }
            }
            else
            {
                //Abort operation.
            }
                


            //Run all the queries necesary to retrieve the nodes
            /*
            queryReadMotherboard(motherboardNode, processorNode, ramNode, listMotherboard);
            queryReadProcessor(motherboardNode, processorNode, ramNode, listProcessor);
            queryReadRAM(motherboardNode, processorNode, ramNode, listRAM);
             */
            queryReadComputerCase(motherboardNode, listComputerCase);   
            queryReadHardDrive(hardDriveNode, listHardDrive);
            queryReadGraphicCard(graphicCardNode, listGraphicCard);
            queryReadOpticalDrive(opticalDriveNode,listOpticalDrive);
            queryReadCooler(processorNode, listProcessorCooler);
            queryReadPowerSupply(listPowerSupply);
            

        }
    }
}
