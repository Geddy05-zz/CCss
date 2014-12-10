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
        public List<Moederbord> listNodeMoederbord;
        public List<CPU> listNodeProcessor;
        public List<GeheugenKaart> listNodeGeheugenKaart;
        public List<CPUKoeler> listNodeCPUKoeler;
        public List<Voeding> listNodeVoeding;
        public List<GrafischeKaart> listNodeGrafischeKaart;
        public List<Behuizing> listNodeBehuizing;
        public List<Hardeschijf> listNodeHardeschijf;
        public List<Optischedrives> listNodeOptischedrives;

        private SearchPropertiesModel searchPropertiesModel;


        public MatcherMainProgram(SearchPropertiesModel spm)
        {
            this.searchPropertiesModel = spm;
            initiateComponentsList();
        }

        /* This function initiate the List of the components
         * so that nodes can be put in them.
         */
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
            List<Optischedrives> listNodeOptischedrives = new List<Optischedrives>();
        }

        /* The runMatchProgram runs all the necessary functions to get
         * the nodes from the neo4J database and pickout the ones with
         * the lowest price.
         */
        public void runMatcherProgram()
        {
            //Run the query to retrieve the data from the database.
            QueryManager qm = new QueryManager();
            qm.runAllQuery(searchPropertiesModel, listNodeMoederbord, listNodeProcessor, listNodeGeheugenKaart, listNodeOptischedrives,
            listNodeHardeschijf, listNodeGrafischeKaart, listNodeCPUKoeler, listNodeVoeding, listNodeBehuizing);

            Matcher matcher = new Matcher();
            matcher.matchComponentsWithLowestPrice(listNodeMoederbord, listNodeProcessor, listNodeGeheugenKaart, listNodeOptischedrives,
            listNodeHardeschijf, listNodeGrafischeKaart, listNodeCPUKoeler, listNodeVoeding, listNodeBehuizing);
        }
    }
}
