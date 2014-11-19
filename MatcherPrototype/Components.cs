using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatcherPrototype
{
    class Components
    {
        private string naam { get; set; }
        private int price { get; set; }
        private string url { get; set; }
        private string beschrijving { get; set; }
        private string bedrijfsnaam { get; set; }
    }

    class Moederbord : Components
    {
        private string socket { get; set; }
        private string vormFactor { get; set; }
        private int geheugenslot { get; set; }
        private string geheugenkloksneleheid { get; set; }
        private string geheugentype { get; set; }
        private int maxgeheugen { get; set; }
        private string aansluiting { get; set;}
    }

    class Geheugen : Components
    {
        private string geheugenkloksnelehid { get; set; }
        private string geheugentype { get; set; }
        private int geheugen { get; set; }
        private int aantal { get; set; }
    }

    class CPUKoeler : Components 
    {
        private string socket { get; set; }
    }

    class Voeding : Components
    {
        private int wattage { get; set; }
    }

    class CPU : Components
    {
        private string socket { get; set; }
        private int kloksnelheid { get; set; }
        private int cores { get; set; }
    }

    class GrafischeKaart : Components
    {
        private string aansluiting { get; set; }
        private int videoGeheugen { get; set; }
        private string typeGeheugen { get; set; }
    }

    class Behuizing : Components
    {
        private string vormFactor { get; set; }
    }

    class Hardeschijf : Components
    {
        private string soort { get; set; }
        private int opslag { get; set; }
        private string rpm { get; set;}
    }

    class OptischeDrives : Components
    {
        private string categorie { get; set; }
    }
}
