using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatcherPrototype
{
    // The class attributes needs to be of the same name as the Node properties otherwise the data
    // will not be passed on properly.
    class Components
    {
        public string Naam { get; set; }
        public string Prijs { get; set; }
        public string Url { get; set; }

    }

    class Moederbord : Components
    {
        public string Socket { get; set; }
        public string Vormfactor { get; set; }
        public string Geheugenslot { get; set; }
        public string Geheugentype { get; set; }
    }

    class GeheugenKaart : Components
    {
        public string Geheugenkloksnelehid { get; set; }
        public string Geheugentype { get; set; }
        public string Geheugen { get; set; }
        public string Geheugenslots { get; set; }
    }

    class CPUKoeler : Components 
    {
        public string Socket { get; set; }
    }

    class Voeding : Components
    {
        public string Wattage { get; set; }
    }

    class CPU : Components
    {
        public string Socket { get; set; }
        public string Model { get; set; }
        public string Kloksnelheid { get; set; }
        public string Cores { get; set; }
        public int MinimumKloksnelheid { get; set; }
        public int MaximumKloksnelheid { get; set; }
    }

    class GrafischeKaart : Components
    {
        public string Videogeheugen { get; set; }
        public string Typegeheugen { get; set; }
    }

    class Behuizing : Components
    {
        public string Vormfactor { get; set; }
    }

    class Hardeschijf : Components
    {
        public string Soort { get; set; }
        public string Opslag { get; set; }
    }

    class Optischedrives : Components
    {
        public string Categorie { get; set; }
    }

}
