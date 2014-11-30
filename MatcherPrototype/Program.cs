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
            //Create the lists to hold the objects 
            List<Moederbord> listNodeMoederbord = new List<Moederbord>();
            List<CPU> listNodeProcessor = new List<CPU>();
            List<GeheugenKaart> listNodeGeheugenKaart = new List<GeheugenKaart>();
            List<CPUKoeler> listNodeCPUKoeler = new List<CPUKoeler>();
            List<Voeding> listNodeVoeding = new List<Voeding>();
            List<GrafischeKaart> listNodeGrafischeKaart = new List<GrafischeKaart>();
            List<Behuizing> listNodeBehuizing = new List<Behuizing>();
            List<Hardeschijf> listNodeHardeschijf = new List<Hardeschijf>();
            List<Optischedrives> listNodeOptishcedrives = new List<Optischedrives>();


            Console.WriteLine("-------Request Nodes-------");

            QueryManager qm = new QueryManager();
            
            qm.runAllQuery(listNodeMoederbord,listNodeProcessor,listNodeGeheugenKaart,listNodeOptishcedrives);
           
            foreach (Moederbord m in listNodeMoederbord)
            {
                //Console.WriteLine("Naam: " + m.Naam);
                Console.WriteLine("Prijs: " + m.Prijs);
                //Console.WriteLine("url: " + m.Url);
                //Console.WriteLine("VormFactor: " +  m.Vormfactor);
                //Console.WriteLine("Socket: " + m.Socket);
                //Console.WriteLine("GeheugenType: " + m.Geheugentype);
            }

            Console.WriteLine("Now for the show Processor");
            foreach (CPU m in listNodeProcessor)
            {
                //Console.WriteLine("Naam: " + m.Naam);
                Console.WriteLine("Prijs: " + m.Prijs);
            }

            Console.WriteLine("Now for the show GeheugenKaart");
            foreach (GeheugenKaart m in listNodeGeheugenKaart)
            {
                //Console.WriteLine("Naam: " + m.Naam);
                Console.WriteLine("Prijs: " + m.Prijs);
            }

            Console.WriteLine(" listNodeMoederbord: " + listNodeMoederbord.Count()
                + "\n listNodeProcessor: " + listNodeProcessor.Count()
                + "\n listNodeGeheugenKaart: " + listNodeGeheugenKaart.Count());
            
            Console.WriteLine("Now let's take a look at the unsorted list and sort them out"
            +"\n Calling out the matcher class.");
            Matcher matcherClass = new Matcher();
            matcherClass.matchComponentsWithLowestPrice(listNodeMoederbord, listNodeProcessor, listNodeGeheugenKaart,listNodeOptishcedrives);


            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Now for the show Motherboard");
            foreach (Moederbord m in listNodeMoederbord)
            {
                //Console.WriteLine("Naam: " + m.Naam);
                Console.WriteLine("Prijs: " + m.Prijs);
            }

            Console.WriteLine("Now for the show Processor");
            foreach (CPU m in listNodeProcessor)
            {
                //Console.WriteLine("Naam: " + m.Naam);
                Console.WriteLine("Prijs: " + m.Prijs);
            }

            Console.WriteLine("Now for the show GeheugenKaart");
            foreach (GeheugenKaart m in listNodeGeheugenKaart)
            {
                //Console.WriteLine("Naam: " + m.Naam);
                Console.WriteLine("Prijs: " + m.Prijs);
            }

            Console.WriteLine("Now for the show Optischedrives");
            foreach (Optischedrives m in listNodeOptishcedrives)
            {
                //Console.WriteLine("Naam: " + m.Naam);
                Console.WriteLine("Prijs: " + m.Prijs);
            }

            Console.ReadKey();
        }
    }
}
