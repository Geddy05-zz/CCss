using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatcherPrototype
{
    /* This class are the model that represents the nodes in Neo4j database with their
    properties. */
    public abstract class Components
    {
        public string Naam { get; set; }
        public string Prijs { get; set; }
        public string Url { get; set; }

        public int setMinimumRange(string componentRange)
        {
            //This is the pattern to remove the minimum out of the string componentrange and convert as integer
            String patternMinimumOfTheRange = @"^(\d*)";
            int rangeMinimum = Convert.ToInt32(Regex.Match(componentRange, patternMinimumOfTheRange).ToString());

            //return the minimum of the range as integer
            return rangeMinimum;
        }

        public int setMaximumRange(string componentRange)
        {
            //This is the pattern to remove the maximum out of the string componentrange and convert as integer
            String patternMaximumOfTheRange = @"(\d*)$";
            int rangeMaximum = rangeMaximum = Convert.ToInt32(Regex.Match(componentRange, patternMaximumOfTheRange).ToString());

            //return the maximum of the range as integer.
            return rangeMaximum;
        }
    }

    /** Made all component classes public so as to be accessible to the Unit tests**/

    public class Moederbord : Components
    {
        public string Socket { get; set; }
        public string Vormfactor { get; set; }
        public string Geheugenslots { get; set; }
        public string Geheugentype { get; set; }
    }

    public class GeheugenKaart : Components
    {
        /* typo? do not know where geheugenkloksnelheid is further referenced, did not alter*/
        public string Geheugenkloksnelehid { get; set; }
        public string Geheugentype { get; set; }
        public string Geheugen { get; set; }
        public string Geheugenslots { get; set; }
    }

    public class CPUKoeler : Components 
    {
        public string Socket { get; set; }
    }

    public class Voeding : Components
    {
        public string Wattage { get; set; }
    }

    public class CPU : Components
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

    public class GrafischeKaart : Components
    {
        public string Videogeheugen { get; set; }
        public string Typegeheugen { get; set; }
    }

    public class Behuizing : Components
    {
        public string Vormfactor { get; set; }
    }

    public class Hardeschijf : Components
    {
        public string Soort { get; set; }
        public string Opslag { get; set; }
        public int MinimumOpslag { get; set; }
        public int MaximumOpslag { get; set; }
    }

    public class Optischedrives : Components
    {
        public string Categorie { get; set; }
    }

    //This class is only for testing purpose
    class SearchPropertiesModel
    {
        public string ProcessorType { get; set; }
        public string ProcessorSnelheid { get; set; }
        public string ProcessorCores { get; set; }
        public string GeheugenSlots { get; set; }
        public string GeheugenSnelheid { get; set; }
        public string GrafischekaartVideogeheugen { get; set; }
        public string GrafischkaartType { get; set; }
        public string HardeschijfType { get; set; }
        public string HardescrhijfOpslag { get; set; }
        public string HardeschijfRPM { get; set; }
        public string OptischeDrivesCatergorie { get; set; }
        public string BehuizingVormfactor { get; set; }
    }

}
