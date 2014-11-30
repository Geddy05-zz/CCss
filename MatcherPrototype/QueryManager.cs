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

        public void queryMoederbord(List<Moederbord> listMoederB)
        {
            // Example query to check how the system takes in the nodes and work with it.

            //Create stopwatch to measure performance
            var watch = Stopwatch.StartNew();

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (m:Moederbord{Geheugenslots:'2'})-[a]-(p:Processor{Model:'i5', Cores:'4'}), (m)-[c]->(g:Geheugen{Geheugen:'8gb'})")
                .Where("p.Kloksnelheid >= 2 AND p.Kloksnelheid <= 4")
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

        public void queryProcessor(List<CPU> listProcessor)
        {
            // Example query to check how the system takes in the nodes and work with it.

            //Create stopwatch to measure performance
            var watch = Stopwatch.StartNew();

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (m:Moederbord{Geheugenslots:'2'})-[a]-(p:Processor{Model:'i5', Cores:'4'}), (m)-[c]->(g:Geheugen{Geheugen:'8gb'})")
                .Where("p.Kloksnelheid >= 2 AND p.Kloksnelheid <= 4")
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

        public void queryGeheugenKaart(List<GeheugenKaart> listGeheugenkaart)
        {
            // Example query to check how the system takes in the nodes and work with it.

            //Create stopwatch to measure performance
            var watch = Stopwatch.StartNew();

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (m:Moederbord{Geheugenslots:'2'})-[a]-(p:Processor{Model:'i5', Cores:'4'}), (m)-[c]->(g:Geheugen{Geheugen:'8gb'})")
                .Where("p.Kloksnelheid >= 2 AND p.Kloksnelheid <= 4")
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

        public void runAllQuery(List<Moederbord> ListNodeMoederbord, List<CPU> listProcessor, List<GeheugenKaart> listGeheugenkaart, List<Optischedrives> listNOptischedrives)
        {
            queryMoederbord(ListNodeMoederbord);
            queryProcessor(listProcessor);
            queryGeheugenKaart(listGeheugenkaart);
            queryOptischedrive(listNOptischedrives);
        }
    }
}
