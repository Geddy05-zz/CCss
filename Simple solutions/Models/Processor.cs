using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Simple_solutions.Models
{
     public class SearchPropertiesModel
     {
         public int ID                                { get; set; }
         public string processorType                  { get; set; }
         public string processorClockSpeed            { get; set; }
         public string processorcores                 { get; set; }
         public string memorySlots                    { get; set; }
         public string memorySpeed                    { get; set; }
         public string graphicCardSpeed               { get; set; }
         public string graphicCardType                { get; set; }
         public string hardDrivetype                  { get; set; }
         public string hardDriveCapacity              { get; set; }
         public string opticalDriveCategory           { get; set; }
         public string systemUnitFormfactor           { get; set; } 
        
    }
}