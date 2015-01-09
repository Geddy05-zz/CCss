using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Simple_solutions.Models;


namespace Simple_solutions.Matcher
{
    public class HomeController : Controller
    {
        MatcherMainProgram matcher;
        private AdminContext db = new AdminContext();

        public ActionResult Index()
        {
            List<SelectListItem> processorType = new List<SelectListItem>();
            processorType.Add(new SelectListItem { Text = "", Value = "i3" });
            processorType.Add(new SelectListItem { Text = "i3", Value = "i3" });
            processorType.Add(new SelectListItem { Text = "i5", Value = "i5" });
            processorType.Add(new SelectListItem { Text = "i7", Value = "i7" });
            processorType.Add(new SelectListItem { Text = "g3220", Value = "g3220" });
            processorType.Add(new SelectListItem { Text = "AMD fx", Value = "fx" });
            processorType.Add(new SelectListItem { Text = "AMD a10", Value = "a10" });
            processorType.Add(new SelectListItem { Text = "AMD a4", Value = "a4" });
            processorType.Add(new SelectListItem { Text = "AMD a8", Value = "a8" });
            ViewData["processorTypeDD"] = processorType;

            List<SelectListItem> processorClockSpeed = new List<SelectListItem>();
            processorClockSpeed.Add(new SelectListItem { Text = "", Value = "1 - 2" });
            processorClockSpeed.Add(new SelectListItem { Text = "1-2 GHZ", Value = "1 - 2" });
            processorClockSpeed.Add(new SelectListItem { Text = "2-3 GHZ", Value = "2 - 3" });
            processorClockSpeed.Add(new SelectListItem { Text = "3-4 GHZ", Value = "3 - 4" });
            processorClockSpeed.Add(new SelectListItem { Text = "4-5 GHZ", Value = "4 - 5" });
            ViewData["processorClockSpeedDD"] = processorClockSpeed;

            List<SelectListItem> processorCores = new List<SelectListItem>();
            processorCores.Add(new SelectListItem { Text = "", Value = "1" });
            processorCores.Add(new SelectListItem { Text = "1", Value = "1" });
            processorCores.Add(new SelectListItem { Text = "2", Value = "2" });
            processorCores.Add(new SelectListItem { Text = "3", Value = "3" });
            processorCores.Add(new SelectListItem { Text = "4", Value = "4" });
            processorCores.Add(new SelectListItem { Text = "6", Value = "6" });
            processorCores.Add(new SelectListItem { Text = "8", Value = "8" });
            processorCores.Add(new SelectListItem { Text = "12", Value = "12" });
            ViewData["processorCoresDD"] = processorCores;

            List<SelectListItem> memorySlots = new List<SelectListItem>();
            memorySlots.Add(new SelectListItem { Text = "", Value = "2" });
            memorySlots.Add(new SelectListItem { Text = "2", Value = "2" });
            memorySlots.Add(new SelectListItem { Text = "4", Value = "4" });
            memorySlots.Add(new SelectListItem { Text = "6", Value = "6" });
            memorySlots.Add(new SelectListItem { Text = "8", Value = "8" });
            ViewData["memorySlotsDD"] = memorySlots;

            List<SelectListItem> memorySpeed = new List<SelectListItem>();
            memorySpeed.Add(new SelectListItem { Text = "", Value = "1" });
            memorySpeed.Add(new SelectListItem { Text = "1 gb", Value = "1" });
            memorySpeed.Add(new SelectListItem { Text = "2 gb", Value = "2" });
            memorySpeed.Add(new SelectListItem { Text = "4 gb", Value = "4" });
            memorySpeed.Add(new SelectListItem { Text = "8 gb", Value = "8" });
            memorySpeed.Add(new SelectListItem { Text = "16 gb", Value = "16" });
            memorySpeed.Add(new SelectListItem { Text = "32 gb", Value = "32" });
            ViewData["memorySpeedDD"] = memorySpeed;

            List<SelectListItem> graphicCardSpeed = new List<SelectListItem>();
            graphicCardSpeed.Add(new SelectListItem { Text = "", Value = "1gb" });
            graphicCardSpeed.Add(new SelectListItem { Text = "1gb", Value = "1gb" });
            graphicCardSpeed.Add(new SelectListItem { Text = "2gb", Value = "2gb" });
            graphicCardSpeed.Add(new SelectListItem { Text = "4gb", Value = "4gb" });
            graphicCardSpeed.Add(new SelectListItem { Text = "8gb", Value = "8gb" });
            graphicCardSpeed.Add(new SelectListItem { Text = "12gb", Value = "12gb" });
            ViewData["graphicCardSpeedDD"] = graphicCardSpeed;

            List<SelectListItem> graphicCardType = new List<SelectListItem>();
            graphicCardType.Add(new SelectListItem { Text = "", Value = "ddr2" });
            graphicCardType.Add(new SelectListItem { Text = "ddr", Value = "ddr" });
            graphicCardType.Add(new SelectListItem { Text = "ddr2", Value = "ddr2" });
            graphicCardType.Add(new SelectListItem { Text = "ddr3", Value = "ddr3" });
            graphicCardType.Add(new SelectListItem { Text = "gddr3", Value = "gddr3" });
            graphicCardType.Add(new SelectListItem { Text = "gddr5", Value = "gddr5" });
            ViewData["graphicCardTypeDD"] = graphicCardType;

            List<SelectListItem> hardDriveType = new List<SelectListItem>();
            hardDriveType.Add(new SelectListItem { Text = "", Value = "hdd" });
            hardDriveType.Add(new SelectListItem { Text = "hdd", Value = "hdd" });
            hardDriveType.Add(new SelectListItem { Text = "ssd", Value = "ssd" });
            ViewData["hardDriveTypeDD"] = hardDriveType;

            List<SelectListItem> hardDriveCapacity = new List<SelectListItem>();
            hardDriveCapacity.Add(new SelectListItem { Text = "", Value = "50 - 100" });
            hardDriveCapacity.Add(new SelectListItem { Text = "50-100 GB", Value = "50 - 100" });
            hardDriveCapacity.Add(new SelectListItem { Text = "100-200 GB", Value = "100 - 200" });
            hardDriveCapacity.Add(new SelectListItem { Text = "200-400 GB", Value = "200 - 400" });
            hardDriveCapacity.Add(new SelectListItem { Text = "400-1000 GB", Value = "400 - 1000" });
            hardDriveCapacity.Add(new SelectListItem { Text = "1000-2000 GB", Value = "1000 - 2000" });
            ViewData["hardDriveCapacityDD"] = hardDriveCapacity;

            List<SelectListItem> hardDiskRpm = new List<SelectListItem>();
            hardDiskRpm.Add(new SelectListItem { Text = "", Value = "dvd" });
            hardDiskRpm.Add(new SelectListItem { Text = "BLU-RAY", Value = "bluray" });
            hardDiskRpm.Add(new SelectListItem { Text = "DVD", Value = "dvd" });
            ViewData["opticalDriveCategoryDD"] = hardDiskRpm;

            List<SelectListItem> systemUnitFormfactor = new List<SelectListItem>();
            systemUnitFormfactor.Add(new SelectListItem { Text = "", Value = "atx" });
            systemUnitFormfactor.Add(new SelectListItem { Text = "atx", Value = "atx" });
            systemUnitFormfactor.Add(new SelectListItem { Text = "nuc", Value = "nuc" });
            systemUnitFormfactor.Add(new SelectListItem { Text = "xlatx", Value = "xlatx" });
            systemUnitFormfactor.Add(new SelectListItem { Text = "e-atx", Value = "e-atx" });
            systemUnitFormfactor.Add(new SelectListItem { Text = "hptx", Value = "hptx" });
            systemUnitFormfactor.Add(new SelectListItem { Text = "itx", Value = "itx" });
            systemUnitFormfactor.Add(new SelectListItem { Text = "microatx", Value = "microatx" });
            systemUnitFormfactor.Add(new SelectListItem { Text = "mini itx", Value = "mini itx" });
            ViewData["systemUnitFormfactorDD"] = systemUnitFormfactor;

            return View();
        }
        [HttpPost]
        public ActionResult Index(string processorTypeResult, string processorClockSpeedResult, string processorCoresResult, string memorySlotsResult, string memorySpeedResult, string graphicCardSpeedResult, string graphicCardTypeResult,
           string hardDriveTypeResult, string hardDriveCapacityResult, string hardDriveRpmResult, string opticalDriveCategoryResult, string systemUnitFormfactorResult)
        {
            var searchResults = new SearchPropertiesModel();
            searchResults.processorType = processorTypeResult;
            searchResults.processorClockSpeed = processorClockSpeedResult;
            searchResults.processorcores = processorCoresResult;
            searchResults.memorySlots = memorySlotsResult;
            searchResults.memorySpeed = memorySpeedResult;
            searchResults.graphicCardSpeed = graphicCardSpeedResult;
            searchResults.graphicCardType = graphicCardTypeResult;
            searchResults.hardDrivetype = hardDriveTypeResult;
            searchResults.hardDriveCapacity = hardDriveCapacityResult;
            searchResults.opticalDriveCategory = opticalDriveCategoryResult;
            searchResults.systemUnitFormfactor = systemUnitFormfactorResult;

            db.SearchPropertiesModels.Add(searchResults);
            db.SaveChanges();

            matcher = new MatcherMainProgram(searchResults);
            matcher.runMatcherProgram();


            TempData["results"] = matcher;
            //return Redirect("javascript:window.open('http://www.google.com','_blank')");
            return RedirectToAction("About");
        }

        public ActionResult About()
        {
            var searchResults = TempData["results"] as MatcherMainProgram;

            //Processor
            ViewBag.processorType = searchResults.listNodeProcessor[0].Model;
            ViewBag.processorSnelheid = searchResults.listNodeProcessor[0].Kloksnelheid;
            ViewBag.processorCores = searchResults.listNodeProcessor[0].Cores;
            ViewBag.processorNaam = searchResults.listNodeProcessor[0].Naam;
            ViewBag.processorPrijs = searchResults.listNodeProcessor[0].Prijs;
            ViewBag.processorSocket = searchResults.listNodeProcessor[0].Socket;
            ViewBag.processorUrl = searchResults.listNodeProcessor[0].Url;

            //Moederbord
            ViewBag.moederbordNaam = searchResults.listNodeMotherboard[0].Naam;
            ViewBag.moederbordType = searchResults.listNodeMotherboard[0].Geheugentype;
            ViewBag.moederbordSlots = searchResults.listNodeMotherboard[0].Geheugenslots;
            ViewBag.moederbordFormfactor = searchResults.listNodeMotherboard[0].Vormfactor;
            ViewBag.moederbordSocket = searchResults.listNodeMotherboard[0].Socket;
            ViewBag.moederbordPrijs = searchResults.listNodeMotherboard[0].Prijs;
            ViewBag.moederbordUrl = searchResults.listNodeMotherboard[0].Url;

            //Werkgeheugen
            ViewBag.geheugen = searchResults.listNodeRAM[0].Geheugen;
            ViewBag.geheugenSnelheid = searchResults.listNodeRAM[0].Geheugenkloksnelheid;
            ViewBag.geheugenSlots = searchResults.listNodeRAM[0].Geheugenslots;
            ViewBag.geheugenType = searchResults.listNodeRAM[0].Geheugentype;
            ViewBag.geheugenNaam = searchResults.listNodeRAM[0].Naam;
            ViewBag.geheugenPrijs = searchResults.listNodeRAM[0].Prijs;
            ViewBag.geheugenUrl = searchResults.listNodeRAM[0].Url;

            //GrafischeKaart
            ViewBag.grafischekaartvideogeheugen = searchResults.listNodeGraphicCard[0].Videogeheugen;
            ViewBag.grafischekaarttype = searchResults.listNodeGraphicCard[0].Typegeheugen;
            ViewBag.grafischekaartnaam = searchResults.listNodeGraphicCard[0].Naam;
            ViewBag.grafischekaartPrijs = searchResults.listNodeGraphicCard[0].Prijs;
            ViewBag.grafischekaartUrl = searchResults.listNodeGraphicCard[0].Url;

            //Hardeschijf
            ViewBag.hardeschijfType = searchResults.listNodeHardDrive[0].Soort;
            ViewBag.hardeschijfOpslag = searchResults.listNodeHardDrive[0].Opslag;
            ViewBag.hardeschijfNaam = searchResults.listNodeHardDrive[0].Naam;
            ViewBag.harderschijfPrijs = searchResults.listNodeHardDrive[0].Prijs;
            ViewBag.harderschijfUrl = searchResults.listNodeHardDrive[0].Url;

            //OptischeDrive
            ViewBag.optischedrivesCategorie = searchResults.listNodeOpticalDrive[0].Categorie;
            ViewBag.optischedrivesNaam = searchResults.listNodeOpticalDrive[0].Naam;
            ViewBag.optischedrivesPrijs = searchResults.listNodeOpticalDrive[0].Prijs;
            ViewBag.optischedrivesUrl = searchResults.listNodeOpticalDrive[0].Url;

            //Behuizing
            ViewBag.behuizingVormfactor = searchResults.listNodeComputerCase[0].Vormfactor;
            ViewBag.behuizingNaam = searchResults.listNodeComputerCase[0].Naam;
            ViewBag.behuizingPrijs = searchResults.listNodeComputerCase[0].Prijs;
            ViewBag.behuizingUrl = searchResults.listNodeComputerCase[0].Url;

            //Voeding
            ViewBag.voedingNaam = searchResults.listNodePowerSupply[0].Naam;
            ViewBag.voedingWatt = searchResults.listNodePowerSupply[0].Wattage;
            ViewBag.voedingPrijs = searchResults.listNodePowerSupply[0].Prijs;
            ViewBag.voedingUrl = searchResults.listNodePowerSupply[0].Url;

            //Koeler
            ViewBag.koelerNaam = searchResults.listNodeProcessorCooler[0].Naam;
            ViewBag.koelerPrijs = searchResults.listNodeProcessorCooler[0].Prijs;
            ViewBag.koelerUrl = searchResults.listNodeProcessorCooler[0].Url;
            ViewBag.koelerSocket = searchResults.listNodeProcessorCooler[0].Socket;

            return View();
        }

        [HttpPost]
        public ActionResult About(string a)
        {
          
            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
