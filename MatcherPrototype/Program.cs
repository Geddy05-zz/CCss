using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatcherPrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------Script loopt lekker-------");
            List<Moederbord> listNodeMoederbord = new List<Moederbord>();
            List<GeheugenKaart> listNodeGeheugenKaart = new List<GeheugenKaart>();
            List<CPU> listNodeCPU = new List<CPU>();
            QueryManager qm = new QueryManager();
            qm.exampleQueryFull(listNodeMoederbord,listNodeGeheugenKaart,listNodeCPU);
            /*foreach (Moederbord m in listNodeMoederbord)
            {
                Console.WriteLine("Naam: " + m.Naam);
                Console.WriteLine("Prijs: " + m.Prijs);
                Console.WriteLine("url: " + m.Url);
                Console.WriteLine("VormFactor: " +  m.Vormfactor);
                Console.WriteLine("Socket: " + m.Socket);
                Console.WriteLine("GeheugenType: " + m.Geheugentype);
            }*/
            Console.WriteLine("CountMoederbord: " + listNodeMoederbord.Count() 
                + "/n CountGeheugenkaart: " + listNodeGeheugenKaart.Count()
                + "/n CountProcessor: " + listNodeCPU.Count());
            Console.ReadKey();
        }
    }
}
