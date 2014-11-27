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

                this.client = new GraphClient(new Uri("http://145.24.222.101:8001/db/data"));
                this.client.Connect();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not make connection to database, check if database server is on and try again.");
            }


        }

        public void exampleQuery(List<Moederbord> listMoederB)
        {
            // Example query to check how the system takes in the nodes and work with it.
            // To DO's :
            // Duplicate out of the list.
            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (n:Moederbord{Geheugenslots:'2'})-[a]-(b:Processor{Model:'i5', Cores:'4'}), (n)-[c]->(d:Geheugen{Geheugen:'8gb'})")
                .Where("b.Kloksnelheid >= 2 AND b.Kloksnelheid <= 4")
                .ReturnDistinct((n) => new
                {
                    listN = n.As<Moederbord>(),
                })
                .Limit(999)
                .Results;
                

            foreach(var a in result)
            {
                listMoederB.Add(a.listN);
            }
        }

        public void exampleQueryFull(List<Moederbord> listMoederBord,List<GeheugenKaart> listGeheugenKaart, List<CPU> listCPU)
        {
            // Example query to check how the system takes in the nodes and work with it.
            // To DO's :
            // Duplicate out of the list.

            //Create stopwatch to measure performance
            var watch = Stopwatch.StartNew();

            List<Moederbord> listNodeDuplicatesMoederbord = new List<Moederbord>();
            List<GeheugenKaart> listNodeDuplicatesGeheugenKaart = new List<GeheugenKaart>();
            List<CPU> listNodeDuplicatesProcessor = new List<CPU>();

            initClientConnection();
            var result =
                this.client.Cypher
                .Match(" (n:Moederbord{Geheugenslots:'2'})-[a]-(b:Processor{Model:'i5', Cores:'4'}), (n)-[c]->(d:Geheugen{Geheugen:'8gb'})")
                .Where("b.Kloksnelheid >= 2 AND b.Kloksnelheid <= 4")
                .ReturnDistinct((n,b,d) => new
                {
                    listN = n.As<Moederbord>(),
                    listD = d.As<GeheugenKaart>(),
                    listB = b.As<CPU>()
                })
                .Limit(999)
                .Results;

            

            foreach (var a in result)
            {
                listMoederBord.Add(a.listN);
                listCPU.Add(a.listB);
                listGeheugenKaart.Add(a.listD);
            }



            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("ElapsedMS: " + elapsedMs);
        }

        public void exampleQueryTest(List<Moederbord> listMoederB)
        {
            initClientConnection();
            var result =
                this.client.Cypher
                .Match("(n:Moederbord)")
                .Return(n => n.As<Moederbord>())
                .Limit(15)
                .Results;
            
            foreach (var a in result)
            {
                listMoederB.Add(a);
            }
        }
    }
}
