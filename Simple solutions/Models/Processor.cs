using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Simple_solutions.Models
{
     public class SearchPropertiesModel
     {
         public string processorType                { get; set; }
         public string processorsnelheid            { get; set; }
         public string processorcores               { get; set; }
         public string geheugenslots                { get; set; }
         public string geheugensnelheid             { get; set; }
         public string grafischekaartvideogeheugen  { get; set; }
         public string grafischekaarttype           { get; set; }
         public string hardeschijftype              { get; set; }
         public string hardeschijfopslag            { get; set; }
         public string hardeschijfrpm               { get; set; }
         public string optischedrivescategorie      { get; set; }
         public string behuizingvormfactor          { get; set; } 
        
    }
}