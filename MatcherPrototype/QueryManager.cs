using Neo4jClient;
using System;
using System.Collections.Generic;
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
            Moederbord moederboard = new Moederbord();
            //moederboard.geheugenslot = 2;
            CPU cpu = new CPU();
            cpu.Model = "i5";
            cpu.Cores = "4";
            GeheugenKaart geheugen = new GeheugenKaart();
            geheugen.Geheugen = "8";

            initClientConnection();
            var result = 
                this.client.Cypher
                .Match(" (n:Moederbord{Geheugenslots:'2'})-[a]-(b:Processor{Model:'i5', Cores:'4'}), (n)-[c]->(d:Geheugen{Geheugen:'8gb'}),"
                    + " (e:Grafischekaart{Videogeheugen:'4gb'}), (g:Hardeschijf{Soort:'ssd'}), (f:Optischedrives{Categorie:'dvd'})")
                .Where(" g.Opslag>200 AND g.Opslag<500 AND b.Kloksnelheid >= 2 AND b.Kloksnelheid <= 4")
                .Return((n,b,d,e,g) => new {
                 listN = n.As<Moederbord>(),
                 listB = b.As<CPU>(),
                 listD = d.As<GeheugenKaart>(),
                 listE = e.As<GrafischeKaart>(),
                 listG = g.As<Hardeschijf>()
                })
                .Limit(200)
                .Results;

            foreach(var a in result)
            {
                listMoederB.Add(a.listN);
            }
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
