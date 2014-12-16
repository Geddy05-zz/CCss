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
            //This was used to test... Do not use this class
            SearchPropertiesModel spm = new SearchPropertiesModel();
            spm.ProcessorSnelheid = "1 - 2";
            spm.HardescrhijfOpslag = "100 - 500";

            CPU processor = new CPU();
            processor.MinimumKloksnelheid = processor.setMinimumRange(spm.ProcessorSnelheid);
            processor.MaximumKloksnelheid = processor.setMaximumRange(spm.ProcessorSnelheid);

            Hardeschijf hdd = new Hardeschijf();
            hdd.MinimumOpslag = hdd.setMinimumRange(spm.HardescrhijfOpslag);
            hdd.MaximumOpslag = hdd.setMaximumRange(spm.HardescrhijfOpslag);

            Console.WriteLine("This is the result of the processor Min: " + processor.MinimumKloksnelheid + " Max: " + processor.MaximumKloksnelheid);
            Console.WriteLine("This is the result of the processor Min: " + hdd.MinimumOpslag + " Max: " + hdd.MaximumOpslag);
            Console.ReadKey();
        }
    }
}
