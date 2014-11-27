using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatcherPrototype
{
    // The class attributes needs to be of the same name as the Node properties otherwise the data
    // will not be passed on properly.
    class Components : IEquatable<Components>
    {
        public string Naam { get; set; }
        public string Prijs { get; set; }
        public string Url { get; set; }

        public bool Equals(Components other)
        {
            //Check whether the compared object is null.
            if (Object.ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (Object.ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal.
            return Naam.Equals(other.Naam) && Url.Equals(other.Url);
        }

        public override int GetHashCode()
        {
            //Get hash code for the Name field if it is not null.
            int hashComponentNaam = Naam == null ? 0 : Naam.GetHashCode();

            //Get hash code for the Code field.
            int hashComponentUrl = Url.GetHashCode();

            //Calculate the hash code for the product.
            return hashComponentNaam ^ hashComponentUrl;
        }

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
