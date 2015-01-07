using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Simple_solutions.Models
{
    public class searchResult 
    {
        public int ID                       {get;set;}
        public string processorType         {get;set;}
        public string processorClockSpeed   {get;set;}
        public string processorCores        {get;set;}
        public string memorySlots           {get;set;}
        public string memorySpeed           {get;set;}
        public string graphicCardSpeed      {get;set;}
        public string graphicCardType       {get;set;}
        public string hardDriveType         {get;set;}
        public string hardDriveCapacity     {get;set;}
        public string hardDriveRpm          {get;set;}
        public string opticalDriveCategory  {get;set;}
        public string systemUnitFormfactor  {get;set;}
    }
     public class searchResultDbContext : DbContext
    {
        public DbSet searchResults { get; set; }
    }

    public class selled
    {
        public int ID { get; set; }
        public string productName { get; set; }
        public string url { get; set; }
        public double prijs { get; set; }
    }
}