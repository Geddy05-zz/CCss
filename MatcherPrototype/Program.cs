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
            Dictionary<string, Components> dictionary = new Dictionary<string, Components>();
            Moederbord mb = new Moederbord();
            mb.Socket = "1150";
            dictionary.Add("Moederboard", mb);
            Moederbord mb2 = (Moederbord)dictionary["Moederboard"];

            Dictionary<string, Components> dictionary2 = dictionary;
            Console.WriteLine("MB " + mb.Socket);
            Console.WriteLine("MB2 " + mb2.Socket);

            Moederbord mb3 = (Moederbord)dictionary["Moederboard"];
            Console.WriteLine("MB " + mb.Socket);
            Console.WriteLine("MB3 " + mb3.Socket);


            
            
            /*
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

            // Create the objects for this test
            Moederbord moederbordInput = new Moederbord();
            moederbordInput.Geheugenslots = "2";

            CPU processorInput = new CPU();
            processorInput.Cores = "4";
            processorInput.Model = "i5";
            processorInput.MinimumKloksnelheid = 2;
            processorInput.MaximumKloksnelheid = 4;

            GeheugenKaart geheugenInput = new GeheugenKaart();
            geheugenInput.Geheugen = "8gb";

            Hardeschijf hardeschijfInput = new Hardeschijf();
            hardeschijfInput.MinimumOpslag = 200;
            hardeschijfInput.MaximumOpslag = 600;

            GrafischeKaart grafischekaartInput = new GrafischeKaart();
            grafischekaartInput.Typegeheugen = "ddr5";
            grafischekaartInput.Videogeheugen = "2gb";




            Console.WriteLine("-------Request Nodes-------");

            QueryManager qm = new QueryManager();

            qm.runAllQuery(moederbordInput, processorInput, geheugenInput, hardeschijfInput, grafischekaartInput, listNodeMoederbord, listNodeProcessor, 
                listNodeGeheugenKaart, listNodeOptishcedrives, listNodeHardeschijf, listNodeGrafischeKaart);

            Console.WriteLine("show the Motherboard");

            foreach (Moederbord m in listNodeMoederbord)
            {
                //Console.WriteLine("Naam: " + m.Naam);
                Console.WriteLine("Prijs: " + m.Prijs);
            }
            
            Console.WriteLine("show the Processor");
           
            foreach (CPU m in listNodeProcessor)
            {
                //Console.WriteLine("Naam: " + m.Naam);
                Console.WriteLine("Prijs: " + m.Prijs);
            }

            Console.WriteLine("show the GeheugenKaart");
           
            
            foreach (GeheugenKaart m in listNodeGeheugenKaart)
            {
                //Console.WriteLine("Naam: " + m.Naam);
                Console.WriteLine("Prijs: " + m.Prijs);
            }

            Console.WriteLine("Now for the show Hardeschijf");
           
            foreach (Hardeschijf h in listNodeHardeschijf)
            {
                //Console.WriteLine("Naam: " + m.Naam);
                Console.WriteLine("Prijs: " + h.Prijs);
            }
            
            Console.WriteLine(" listNodeMoederbord: " + listNodeMoederbord.Count()
                + "\n listNodeProcessor: " + listNodeProcessor.Count()
                + "\n listNodeGeheugenKaart: " + listNodeGeheugenKaart.Count());
            
             */
            Console.ReadKey();
        }
    }
}
