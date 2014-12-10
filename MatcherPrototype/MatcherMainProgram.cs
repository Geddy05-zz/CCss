using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatcherPrototype
{
    class MatcherMainProgram
    {
        //List that will contain all of nodes that will be retrieved from the database.
        private List<Moederbord> listNodeMoederbord;
        private List<CPU> listNodeProcessor;
        private List<GeheugenKaart> listNodeGeheugenKaart;
        private List<CPUKoeler> listNodeCPUKoeler;
        private List<Voeding> listNodeVoeding;
        private List<GrafischeKaart> listNodeGrafischeKaart;
        private List<Behuizing> listNodeBehuizing;
        private List<Hardeschijf> listNodeHardeschijf;
        private List<Optischedrives> listNodeOptishcedrives;

        //These are the compononents that will be used throughout this program.
        private Moederbord moederbord;
        private CPU cpu;
        private GeheugenKaart geheugenKaart;
        private CPUKoeler cpuKoeler;
        private Hardeschijf hardeschijf;
        private GrafischeKaart grafischeKaart;
        private Optischedrives optischeDrives;
        private Behuizing behuizing;
        private Voeding voeding;

        public MatcherMainProgram(CPU cpuFromWeb, GeheugenKaart geheugenKaartFromWeb, Hardeschijf hardeschijfFromWeb
            , GrafischeKaart grafischeKaartFromWeb, Optischedrives optischeDrivesFromWeb, Behuizing behuizingFromWeb)
        {
            this.cpu = cpuFromWeb;
            this.geheugenKaart = geheugenKaartFromWeb;
            this.hardeschijf = hardeschijfFromWeb;
            this.grafischeKaart = grafischeKaartFromWeb;
            this.optischeDrives = optischeDrivesFromWeb;
            this.behuizing = behuizingFromWeb;

            initiateComponentsList();


        }

        private void initiateComponentsList()
        {
            List<Moederbord> listNodeMoederbord = new List<Moederbord>();
            List<CPU> listNodeProcessor = new List<CPU>();
            List<GeheugenKaart> listNodeGeheugenKaart = new List<GeheugenKaart>();
            List<CPUKoeler> listNodeCPUKoeler = new List<CPUKoeler>();
            List<Voeding> listNodeVoeding = new List<Voeding>();
            List<GrafischeKaart> listNodeGrafischeKaart = new List<GrafischeKaart>();
            List<Behuizing> listNodeBehuizing = new List<Behuizing>();
            List<Hardeschijf> listNodeHardeschijf = new List<Hardeschijf>();
            List<Optischedrives> listNodeOptishcedrives = new List<Optischedrives>();
        }

        public void runMatcherProgram()
        {
            QueryManager qm = new QueryManager();

        }
    }
}
