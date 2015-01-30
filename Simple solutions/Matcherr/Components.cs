using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simple_solutions
{
    /* These classes are the model that represents the nodes in Neo4j database with their
       properties.
     * The properties are in Dutch and starts with capital letter, this is because of the way they
     * are setup in the neo4j database.*/

    public abstract class Components
    {
        public string Naam { get; set; }
        public string Prijs { get; set; }
        public string Url { get; set; }

        public int setMinimumRange(string componentRange)
        {
            //This is the pattern to remove the minimum out of the string componentrange and convert as integer
            String patternMinimumOfTheRange = @"^(\d*)";
            int rangeMinimum;
            if (componentRange.Equals(null) || componentRange.Equals(""))
            {
                rangeMinimum = 0;
            }
            else
            {
                rangeMinimum = Convert.ToInt32(Regex.Match(componentRange, patternMinimumOfTheRange).ToString());
            }
            //return the minimum of the range as integer
            return rangeMinimum;
        }

        public int setMaximumRange(string componentRange)
        {
            //This is the pattern to remove the maximum out of the string componentrange and convert as integer
            String patternMaximumOfTheRange = @"(\d*)$";
            int rangeMaximum;

            if (componentRange.Equals(null) || componentRange.Equals(""))
            {
                rangeMaximum = 0;
            }
            else
            {
                rangeMaximum = Convert.ToInt32(Regex.Match(componentRange, patternMaximumOfTheRange).ToString());
            }

            //return the maximum of the range as integer.
            return rangeMaximum;
        }
    }

    class Motherboard : Components
    {
        public string Socket { get; set; }
        public string Vormfactor { get; set; }
        public string Geheugenslots { get; set; }
        public string Geheugentype { get; set; }
    }

    class RAM : Components
    {
        public string Geheugenkloksnelheid { get; set; }
        public string Geheugentype { get; set; }
        public string Geheugen { get; set; }
        public string Geheugenslots { get; set; }
    }

    class ProcessorCooler : Components 
    {
        public string Socket { get; set; }
    }

    class PowerSupply : Components
    {
        public string Wattage { get; set; }
    }

    class Processor : Components
    {
        public string Socket { get; set; }
        public string Model { get; set; }
        public string Kloksnelheid { get; set; }
        public string Cores { get; set; }
        public int MinimumKloksnelheid { get; set; }
        public int MaximumKloksnelheid { get; set; }

        public void setMinimumAndMaximumClockFrequency(string processorClockFrequencyRange)
        {
            /*The minimum and the maximum of the range in the string format
            will be removed and converted into integers.*/
            String patternFirstInteger = @"^\d*";
            String patternSecondInteger = @"$\d*";
            int rangeMinimum = Convert.ToInt32(Regex.Match(processorClockFrequencyRange, patternFirstInteger).ToString());
            int rangeMaximum = Convert.ToInt32(Regex.Match(processorClockFrequencyRange, patternSecondInteger).ToString());
            
            //Stores the minimum and the maximum of the range in the following variable 
            this.MinimumKloksnelheid = rangeMinimum;
            this.MaximumKloksnelheid = rangeMaximum;
        }
    }

    class GraphicCard : Components
    {
        public string Videogeheugen { get; set; }
        public string Typegeheugen { get; set; }
    }

    class ComputerCase : Components
    {
        public string Vormfactor { get; set; }
    }

    class HardDrive : Components
    {
        public string Soort { get; set; }
        public string Opslag { get; set; }
        public int MinimumOpslag { get; set; }
        public int MaximumOpslag { get; set; }
    }

    class OpticalDrive : Components
    {
        public string Categorie { get; set; }
    }


}
