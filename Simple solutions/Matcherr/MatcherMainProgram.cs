using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simple_solutions.Models;

namespace Simple_solutions
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
            listNodeMoederbord = new List<Moederbord>();
            listNodeProcessor = new List<CPU>();
            listNodeGeheugenKaart = new List<GeheugenKaart>();
            listNodeCPUKoeler = new List<CPUKoeler>();
            listNodeVoeding = new List<Voeding>();
            listNodeGrafischeKaart = new List<GrafischeKaart>();
            listNodeBehuizing = new List<Behuizing>();
            listNodeHardeschijf = new List<Hardeschijf>();
            listNodeOptischedrives = new List<Optischedrives>();
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

            Matcherr matcher = new Matcherr();
            matcher.matchComponentsWithLowestPrice(listNodeMoederbord, listNodeProcessor, listNodeGeheugenKaart, listNodeOptischedrives,
            listNodeHardeschijf, listNodeGrafischeKaart, listNodeCPUKoeler, listNodeVoeding, listNodeBehuizing);
        }
        
    }
}
