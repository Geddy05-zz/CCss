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
        public void matchComponentsWithLowestPrice(List<Motherboard> listMotherboardUnsorted, List<Processor> listProcessorUnsorted, List<RAM> listRAMUnsorted,
            List<OpticalDrive> listOpticalDriveUnsorted,List<HardDrive> listHardDriveUnsorted,List<GraphicCard> listGraphicCardUnsorted, List<ProcessorCooler> listProcessorCoolerUnsorted
            , List<PowerSupply> listPowerSupplyUnsorted, List<ComputerCase> listComputerCaseUnsorted)
        {
            listMotherboardUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs.Replace(".", "")).CompareTo(Convert.ToDouble(b.Prijs.Replace(".", ""))));
            listProcessorUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs.Replace(".", "")).CompareTo(Convert.ToDouble(b.Prijs.Replace(".", ""))));
            listRAMUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs.Replace(".", "")).CompareTo(Convert.ToDouble(b.Prijs.Replace(".", ""))));
            listOpticalDriveUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs.Replace(".", "")).CompareTo(Convert.ToDouble(b.Prijs.Replace(".", ""))));
            listHardDriveUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs.Replace(".","")).CompareTo(Convert.ToDouble(b.Prijs.Replace(".",""))));
            listGraphicCardUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs.Replace(".", "")).CompareTo(Convert.ToDouble(b.Prijs.Replace(".", ""))));
            listComputerCaseUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs.Replace(".", "")).CompareTo(Convert.ToDouble(b.Prijs.Replace(".", ""))));
            listPowerSupplyUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs.Replace(".", "")).CompareTo(Convert.ToDouble(b.Prijs.Replace(".", ""))));
            listProcessorCoolerUnsorted.Sort((a, b) => Convert.ToDouble(a.Prijs.Replace(".", "")).CompareTo(Convert.ToDouble(b.Prijs.Replace(".", ""))));

        }
    }
}
