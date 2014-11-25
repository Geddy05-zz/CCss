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
            Console.WriteLine("-------Script loopt goed-------");
            List<Moederbord> listNodeMoederbord = new List<Moederbord>();
            QueryManager qm = new QueryManager();
            qm.exampleQuery(listNodeMoederbord);
            foreach (Moederbord m in listNodeMoederbord)
            {
                Console.WriteLine(m.Naam);
                Console.WriteLine(m.Prijs);
                Console.WriteLine(m.Url);
                Console.WriteLine(m.Vormfactor);
                Console.WriteLine(m.Socket);
                Console.WriteLine(m.Geheugentype);
                //Console.WriteLine(m.WowFactor);
            }
            Console.WriteLine(listNodeMoederbord.Count());
            Console.ReadKey();
        }
    }
}
