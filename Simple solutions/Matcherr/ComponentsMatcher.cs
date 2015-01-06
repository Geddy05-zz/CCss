using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_solutions
{
    class ComponentsMatcher
    {
        //The matcher class has the functions to sort the component lists and create a computer package 
        public void matchComponentsWithLowestPrice(List<Motherboard> listMoederbordsUnsorted, List<Processor> listCPUUnsorted, List<RAM> listGeheugenUnsorted,
            List<OpticalDrive> listOptischedrivesUnsorted,List<HardDrive> listHardeschijfUnsorted,List<GraphicCard> listGrafischekaartUnsorted, List<ProcessorCooler> listCPUKoelerUnsorted
            , List<PowerSupply> listVoedingUnsorted, List<ComputerCase> listBehuizingUnsorted)
        {
            listMoederbordsUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs.Replace(".", "")).CompareTo(Convert.ToDouble(b.Prijs.Replace(".", ""))));
            listCPUUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs.Replace(".", "")).CompareTo(Convert.ToDouble(b.Prijs.Replace(".", ""))));
            listGeheugenUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs.Replace(".", "")).CompareTo(Convert.ToDouble(b.Prijs.Replace(".", ""))));
            listOptischedrivesUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs.Replace(".", "")).CompareTo(Convert.ToDouble(b.Prijs.Replace(".", ""))));
            listHardeschijfUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs.Replace(".","")).CompareTo(Convert.ToDouble(b.Prijs.Replace(".",""))));
            listGrafischekaartUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs.Replace(".", "")).CompareTo(Convert.ToDouble(b.Prijs.Replace(".", ""))));
            listBehuizingUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs.Replace(".", "")).CompareTo(Convert.ToDouble(b.Prijs.Replace(".", ""))));
            listVoedingUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs.Replace(".", "")).CompareTo(Convert.ToDouble(b.Prijs.Replace(".", ""))));
            listCPUKoelerUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs.Replace(".", "")).CompareTo(Convert.ToDouble(b.Prijs.Replace(".", ""))));

        }
    }
}
