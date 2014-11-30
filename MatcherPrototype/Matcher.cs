using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatcherPrototype
{
    class Matcher
    {
        //The matcher class has the functions to sort the component lists and create a computer package 
        public void matchComponentsWithLowestPrice(List<Moederbord> listMotherbordsUnsorted, List<CPU> listCPUUnsorted, List<GeheugenKaart> listRamUnsorted,
            List<Optischedrives> listOptischedrivesUnsorted)
        {
            var watch = Stopwatch.StartNew();

            listMotherbordsUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs).CompareTo(Convert.ToDouble(b.Prijs)));
            listCPUUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs).CompareTo(Convert.ToDouble(b.Prijs)));
            listRamUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs).CompareTo(Convert.ToDouble(b.Prijs)));
            listOptischedrivesUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs).CompareTo(Convert.ToDouble(b.Prijs)));

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("matchComponentsWithLowestPrice ElapsedMS: " + elapsedMs);

        }
    }
}
