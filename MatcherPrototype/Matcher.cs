using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatcherPrototype
{
    public class Matcher
    {
        //The matcher class has the functions to sort the component lists and create a computer package 
        public void matchComponentsWithLowestPrice(List<Moederbord> listMoederbordsUnsorted, List<CPU> listCPUUnsorted 
            , List<GeheugenKaart> listGeheugenUnsorted, List<Optischedrives> listOptischedrivesUnsorted,List<Hardeschijf> listHardeschijfUnsorted 
            , List<GrafischeKaart> listGrafischekaartUnsorted, List<CPUKoeler> listCPUKoelerUnsorted, List<Voeding> listVoedingUnsorted
            , List<Behuizing> listBehuizingUnsorted
            )
        {
            var watch = Stopwatch.StartNew();

            listMoederbordsUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs).CompareTo(Convert.ToDouble(b.Prijs)));
            listCPUUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs).CompareTo(Convert.ToDouble(b.Prijs)));
            listGeheugenUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs).CompareTo(Convert.ToDouble(b.Prijs)));
            listOptischedrivesUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs).CompareTo(Convert.ToDouble(b.Prijs)));
            listHardeschijfUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs).CompareTo(Convert.ToDouble(b.Prijs)));
            listGrafischekaartUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs).CompareTo(Convert.ToDouble(b.Prijs)));
            listBehuizingUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs).CompareTo(Convert.ToDouble(b.Prijs)));
            listVoedingUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs).CompareTo(Convert.ToDouble(b.Prijs)));
            listCPUKoelerUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs).CompareTo(Convert.ToDouble(b.Prijs)));

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("matchComponentsWithLowestPrice ElapsedMS: " + elapsedMs);

        }
    }
}
