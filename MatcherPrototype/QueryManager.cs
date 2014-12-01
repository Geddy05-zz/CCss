using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatcherPrototype
{
    class QueryManager
    {
        private GraphClient client;

        private void initClientConnection()
        {
            try
            {
                if (this.client != null)
                {
                    return;
                }
                //http://145.24.222.101:8001/db/data
                this.client = new GraphClient(new Uri("http://localhost:7474/db/data"));
                this.client.Connect();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not make connection to database, check if database server is on and try again.");
            }


        }

        public void queryMoederbord(Moederbord moederbordNode,CPU processorNode,GeheugenKaart geheugenNode,List<Moederbord> listMoederB)
        {
            // Example query to check how the system takes in the nodes and work with it.

            //Create stopwatch to measure performance
            var watch = Stopwatch.StartNew();

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor), (m)-[c]->(g:Geheugen)")
                .Where((Moederbord m) => m.Geheugenslots == moederbordNode.Geheugenslots)
                .AndWhere((CPU p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere((GeheugenKaart g) => g.Geheugen == geheugenNode.Geheugen)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .ReturnDistinct((m) => new
                {
                    listM = m.As<Moederbord>(),
                })
                .Results;
                

            foreach(var a in result)
            {
                listMoederB.Add(a.listM);
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("queryMoederbord ElapsedMS: " + elapsedMs);
        }

        public void queryProcessor(Moederbord moederbordNode,CPU processorNode,GeheugenKaart geheugenNode,List<CPU> listProcessor)
        {
            // Example query to check how the system takes in the nodes and work with it.

            //Create stopwatch to measure performance
            var watch = Stopwatch.StartNew();

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor), (m)-[c]->(g:Geheugen)")
                .Where((Moederbord m) => m.Geheugenslots == moederbordNode.Geheugenslots)
                .AndWhere((CPU p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere((GeheugenKaart g) => g.Geheugen == geheugenNode.Geheugen)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .ReturnDistinct((p) => new
                {
                    listP = p.As<CPU>(),
                })
                .Results;


            foreach (var a in result)
            {
                listProcessor.Add(a.listP);
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("queryProcessor ElapsedMS: " + elapsedMs);
        }

        public void queryGeheugenKaart(Moederbord moederbordNode,CPU processorNode,GeheugenKaart geheugenNode,List<GeheugenKaart> listGeheugenkaart)
        {
            // Example query to check how the system takes in the nodes and work with it.

            //Create stopwatch to measure performance
            var watch = Stopwatch.StartNew();

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(p:Processor), (m)-[c]->(g:Geheugen)")
                .Where((Moederbord m) => m.Geheugenslots == moederbordNode.Geheugenslots)
                .AndWhere((CPU p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
                .AndWhere((GeheugenKaart g) => g.Geheugen == geheugenNode.Geheugen)
                .AndWhere("p.Kloksnelheid >= " + processorNode.MinimumKloksnelheid + " AND p.Kloksnelheid <= " + processorNode.MaximumKloksnelheid)
                .ReturnDistinct((g) => new
                {
                    listG = g.As<GeheugenKaart>(),
                })
                .Results;


            foreach (var a in result)
            {
                listGeheugenkaart.Add(a.listG);
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("queryGeheugenKaart ElapsedMS: " + elapsedMs);
        }

        public void queryOptischedrive(List<Optischedrives> listOptischeDrives)
        {
            // Example query to check how the system takes in the nodes and work with it.

            //Create stopwatch to measure performance
            var watch = Stopwatch.StartNew();

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (o:Optischedrives)")
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

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("queryOptischedrives ElapsedMS: " + elapsedMs);
        }

        public void queryHardeschijf(Hardeschijf hardeschijfNode, List<Hardeschijf> listHardeschijf)
        {
            // Example query to check how the system takes in the nodes and work with it.

            //Create stopwatch to measure performance
            var watch = Stopwatch.StartNew();

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (h:Hardeschijf)")
                .Where("h.Opslag >= " + hardeschijfNode.MinimumOpslag + " AND h.Opslag <= " + hardeschijfNode.MaximumOpslag)
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

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("queryHardeschijf ElapsedMS: " + elapsedMs);
        }

        public void queryVoeding(List<Voeding> listVoeding)
        {
            // Example query to check how the system takes in the nodes and work with it.

            //Create stopwatch to measure performance
            var watch = Stopwatch.StartNew();

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

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("queryVoeding ElapsedMS: " + elapsedMs);
        }

        public void queryGrafischekaart(GrafischeKaart grafischekaartNode, List<GrafischeKaart> listGrafischeKaart)
        {
            // Example query to check how the system takes in the nodes and work with it.

            //Create stopwatch to measure performance
            var watch = Stopwatch.StartNew();

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

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("queryGrafischeKaart ElapsedMS: " + elapsedMs);
        }

        public void queryKoeler(CPU processorNode,List<CPUKoeler> listCPUKoeler)
        {
            // Example query to check how the system takes in the nodes and work with it.

            //Create stopwatch to measure performance
            var watch = Stopwatch.StartNew();

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (p:Processor)-[a]-(k:Koeler)")
                .Where((CPU p) => p.Model == processorNode.Model && p.Cores == processorNode.Cores)
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

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("queryKoeler ElapsedMS: " + elapsedMs);
        }

        public void queryBehuizing(Moederbord moederbordNode, List<Behuizing> listBehuizing)
        {
            // Example query to check how the system takes in the nodes and work with it.

            //Create stopwatch to measure performance
            var watch = Stopwatch.StartNew();

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (m:Moederbord)-[a]-(b:Behuizing)")
                .Where((Moederbord m) => m.Geheugenslots == moederbordNode.Geheugenslots)
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

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("queryBehuizing ElapsedMS: " + elapsedMs);
        }

        public void runAllQuery(Moederbord moederbordNode,CPU processorNode,GeheugenKaart geheugenNode, Hardeschijf hardeschijfNode,
            GrafischeKaart grafischekaartNode, List<Moederbord> ListNodeMoederbord, List<CPU> listProcessor, 
            List<GeheugenKaart> listGeheugenkaart,List<Optischedrives> listNOptischedrives, List<Hardeschijf> listHardeschijf, List<GrafischeKaart> listGrafischekaart)
        {
            //Create stopwatch to measure performance
            var watch = Stopwatch.StartNew();

            queryMoederbord(moederbordNode, processorNode, geheugenNode, ListNodeMoederbord);
            queryProcessor(moederbordNode, processorNode, geheugenNode, listProcessor);
            queryGeheugenKaart(moederbordNode, processorNode, geheugenNode, listGeheugenkaart);
            queryHardeschijf(hardeschijfNode, listHardeschijf);
            queryGrafischekaart(grafischekaartNode, listGrafischekaart);
            queryOptischedrive(listNOptischedrives);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("runAllQuery ElapsedMS: " + elapsedMs);
        }
    }
}
