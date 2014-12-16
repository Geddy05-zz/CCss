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
          MatcherMainProgram prog;

        public ActionResult Index()
        {
            List<SelectListItem> processortype = new List<SelectListItem>();
            processortype.Add(new SelectListItem { Text = "", Value = "i3" });
            processortype.Add(new SelectListItem { Text = "i3", Value = "i3" });
            processortype.Add(new SelectListItem { Text = "i5", Value = "i5" });
            processortype.Add(new SelectListItem { Text = "i7", Value = "i7" });
            processortype.Add(new SelectListItem { Text = "g3220", Value = "g3220" });
            processortype.Add(new SelectListItem { Text = "AMD fx", Value = "fx" });
            processortype.Add(new SelectListItem { Text = "AMD a10", Value = "a10" });
            processortype.Add(new SelectListItem { Text = "AMD a4", Value = "a4" });
            processortype.Add(new SelectListItem { Text = "AMD a8", Value = "a8" });
            ViewData["processortypeDD"] = processortype;
            
            List<SelectListItem> processorsnelheid = new List<SelectListItem>();
            processorsnelheid.Add(new SelectListItem { Text = "", Value = "1 - 2" });
            processorsnelheid.Add(new SelectListItem { Text = "1-2 GHZ", Value = "1 - 2" });
            processorsnelheid.Add(new SelectListItem { Text = "2-3 GHZ", Value = "2 - 3" });
            processorsnelheid.Add(new SelectListItem { Text = "3-4 GHZ", Value = "3 - 4" });
            processorsnelheid.Add(new SelectListItem { Text = "4-5 GHZ", Value = "4 - 5" });
            ViewData["processorsnelheidDD"] = processorsnelheid;

            
            List<SelectListItem> processorcores = new List<SelectListItem>();
            processorcores.Add(new SelectListItem { Text = "", Value = "1" });
            processorcores.Add(new SelectListItem { Text = "1", Value = "1" });
            processorcores.Add(new SelectListItem { Text = "2", Value = "2" });
            processorcores.Add(new SelectListItem { Text = "3", Value = "3" });
            processorcores.Add(new SelectListItem { Text = "4", Value = "4" });
            processorcores.Add(new SelectListItem { Text = "6", Value = "6" });
            processorcores.Add(new SelectListItem { Text = "8", Value ="8" });
            processorcores.Add(new SelectListItem { Text = "12", Value = "12" });
            ViewData["processorcoresDD"] = processorcores;

            List<SelectListItem> geheugenslots = new List<SelectListItem>();
            geheugenslots.Add(new SelectListItem { Text = "", Value = "2" });
            geheugenslots.Add(new SelectListItem { Text = "2", Value = "2" });
            geheugenslots.Add(new SelectListItem { Text = "4", Value = "4" });
            geheugenslots.Add(new SelectListItem { Text = "6", Value = "6" });
            geheugenslots.Add(new SelectListItem { Text = "8", Value = "8" });
            ViewData["geheugenslotsDD"] = geheugenslots;

            List<SelectListItem> geheugensnelheid = new List<SelectListItem>();
            geheugensnelheid.Add(new SelectListItem { Text = "", Value = "1" });
            geheugensnelheid.Add(new SelectListItem { Text = "1 gb", Value = "1" });
            geheugensnelheid.Add(new SelectListItem { Text = "2 gb", Value = "2" });
            geheugensnelheid.Add(new SelectListItem { Text = "4 gb", Value = "4" });
            geheugensnelheid.Add(new SelectListItem { Text = "8 gb", Value = "8" });
            geheugensnelheid.Add(new SelectListItem { Text = "16 gb", Value = "16" });
            geheugensnelheid.Add(new SelectListItem { Text = "32 gb", Value = "32" });
            ViewData["geheugensnelheidDD"] = geheugensnelheid;

            List<SelectListItem> grafischekaartvideogeheugen = new List<SelectListItem>();
            grafischekaartvideogeheugen.Add(new SelectListItem { Text = "", Value = "1gb" });
            grafischekaartvideogeheugen.Add(new SelectListItem { Text = "1gb", Value = "1gb" });
            grafischekaartvideogeheugen.Add(new SelectListItem { Text = "2gb", Value = "2gb" });
            grafischekaartvideogeheugen.Add(new SelectListItem { Text = "4gb", Value = "4gb" });
            grafischekaartvideogeheugen.Add(new SelectListItem { Text = "8gb", Value = "8gb" });
            grafischekaartvideogeheugen.Add(new SelectListItem { Text = "12gb", Value = "12gb" });
            ViewData["grafischekaartvideogeheugenDD"] = grafischekaartvideogeheugen;

            List<SelectListItem> grafischekaarttype = new List<SelectListItem>();
            grafischekaarttype.Add(new SelectListItem { Text = "", Value = "ddr2" });
            grafischekaarttype.Add(new SelectListItem { Text = "ddr", Value = "ddr" });
            grafischekaarttype.Add(new SelectListItem { Text = "ddr2", Value = "ddr2" });
            grafischekaarttype.Add(new SelectListItem { Text = "ddr3", Value = "ddr3" });
            grafischekaarttype.Add(new SelectListItem { Text = "gddr3", Value = "gddr3" });
            grafischekaarttype.Add(new SelectListItem { Text = "gddr5", Value = "gddr5" });
            ViewData["grafischekaarttypeDD"] = grafischekaarttype;

            List<SelectListItem> hardeschijftype = new List<SelectListItem>();
            hardeschijftype.Add(new SelectListItem { Text = "", Value = "hdd" });
            hardeschijftype.Add(new SelectListItem { Text = "hdd", Value = "hdd" });
            hardeschijftype.Add(new SelectListItem { Text = "ssd", Value = "ssd" });
            ViewData["hardeschijftypeDD"] = hardeschijftype;

            List<SelectListItem> hardeschijfopslag = new List<SelectListItem>();
            hardeschijfopslag.Add(new SelectListItem { Text = "", Value = "50 - 100" });
            hardeschijfopslag.Add(new SelectListItem { Text = "50-100 GB", Value = "50 - 100" });
            hardeschijfopslag.Add(new SelectListItem { Text = "100-200 GB", Value = "100 - 200" });
            hardeschijfopslag.Add(new SelectListItem { Text = "200-400 GB", Value = "200 - 400" });
            hardeschijfopslag.Add(new SelectListItem { Text = "400-1000 GB", Value = "400 - 1000" });
            hardeschijfopslag.Add(new SelectListItem { Text = "1000-2000 GB", Value = "1000 - 2000" });
            ViewData["hardeschijfopslagDD"] = hardeschijfopslag;

            List<SelectListItem> optischedrivescategorie = new List<SelectListItem>();
            optischedrivescategorie.Add(new SelectListItem { Text = "", Value = "0" });
            optischedrivescategorie.Add(new SelectListItem { Text = "BLU-RAY", Value = "bluray" });
            optischedrivescategorie.Add(new SelectListItem { Text = "DVD RW", Value = "dvd" });
            ViewData["optischedrivescategorieDD"] = optischedrivescategorie;

            List<SelectListItem> behuizingvormfactor = new List<SelectListItem>();
            behuizingvormfactor.Add(new SelectListItem { Text = "", Value = "0" });
            behuizingvormfactor.Add(new SelectListItem { Text = "atx", Value = "atx" });
            behuizingvormfactor.Add(new SelectListItem { Text = "miniatx", Value = "atx" });
            behuizingvormfactor.Add(new SelectListItem { Text = "200-300 RPM", Value = "200-300 RPM" });
            ViewData["behuizingvormfactorDD"] = behuizingvormfactor;

            
            return View();
        }
        [HttpPost]
        public ActionResult Index(string processortypeResult, string processorsnelheidResult, string processorcoresResult, string geheugenslotsResult, string geheugensnelheidResult, string grafischekaartvideogeheugenResult, string grafischekaarttypeResult,
           string hardeschijftypeResult, string hardeschijfopslagResult, string hardeschijfrpmResult, string optischedrivescategorieResult, string behuizingvormfactorResult)
        {
            var searchResults = new SearchPropertiesModel();
            searchResults.processorType = processortypeResult;
            searchResults.processorsnelheid = processorsnelheidResult;
            searchResults.processorcores = processorcoresResult;
            searchResults.geheugenslots = geheugenslotsResult;
            searchResults.geheugensnelheid = geheugensnelheidResult;
            searchResults.grafischekaartvideogeheugen = grafischekaartvideogeheugenResult; 
            searchResults.grafischekaarttype = grafischekaarttypeResult;
            searchResults.hardeschijftype = hardeschijftypeResult;
            searchResults.hardeschijfopslag = hardeschijfopslagResult;
            searchResults.hardeschijfrpm = hardeschijfrpmResult;
            searchResults.optischedrivescategorie = optischedrivescategorieResult;
            searchResults.behuizingvormfactor = behuizingvormfactorResult;

            prog = new MatcherMainProgram(searchResults);
            prog.runMatcherProgram();


            TempData["results"] = prog;
            return RedirectToAction("About");
        }
        
        public ActionResult About()
        {
            var searchResults = TempData["results"] as MatcherMainProgram;
            ViewBag.processorType = searchResults.listNodeProcessor[0].Model; 
            ViewBag.processorsnelheid = searchResults.listNodeProcessor[0].Kloksnelheid + " Ghz";
            ViewBag.processorcores = searchResults.listNodeProcessor[0].Cores;
            ViewBag.geheugenslots = searchResults.listNodeGeheugenKaart[0].Geheugenslots;
            ViewBag.geheugensnelheid = searchResults.listNodeGeheugenKaart[0].Geheugenkloksnelheid;
            ViewBag.grafischekaartvideogeheugen = searchResults.listNodeGrafischeKaart[0].Videogeheugen;
            ViewBag.grafischekaarttype = searchResults.listNodeGrafischeKaart[0].Typegeheugen;
            ViewBag.grafischekaartnaam = searchResults.listNodeGrafischeKaart[0].Naam;
            ViewBag.grafischekaartPrijs = searchResults.listNodeGrafischeKaart[0].Prijs;
            ViewBag.grafischekaartUrl = searchResults.listNodeGrafischeKaart[0].Url;
            ViewBag.hardeschijftype = "test";
            ViewBag.hardeschijfopslag = "test";
            ViewBag.hardeschijfrpm = "test";
            ViewBag.optischedrivescategorie = "test";
            ViewBag.behuizingvormfactor = searchResults.listNodeBehuizing[0].Naam;


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
