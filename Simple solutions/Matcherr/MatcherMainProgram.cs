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
        public List<Motherboard> listNodeMoederbord;
        public List<Processor> listNodeProcessor;
        public List<RAM> listNodeGeheugenKaart;
        public List<ProcessorCooler> listNodeCPUKoeler;
        public List<PowerSupply> listNodeVoeding;
        public List<GraphicCard> listNodeGrafischeKaart;
        public List<ComputerCase> listNodeBehuizing;
        public List<HardDrive> listNodeHardeschijf;
        public List<OpticalDrive> listNodeOptischedrives;

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
            listNodeMoederbord = new List<Motherboard>();
            listNodeProcessor = new List<Processor>();
            listNodeGeheugenKaart = new List<RAM>();
            listNodeCPUKoeler = new List<ProcessorCooler>();
            listNodeVoeding = new List<PowerSupply>();
            listNodeGrafischeKaart = new List<GraphicCard>();
            listNodeBehuizing = new List<ComputerCase>();
            listNodeHardeschijf = new List<HardDrive>();
            listNodeOptischedrives = new List<OpticalDrive>();
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

            //Run the match to compare all the nodes and sort them in orde of lowest price.
            ComponentsMatcher matcher = new ComponentsMatcher();
            matcher.matchComponentsWithLowestPrice(listNodeMoederbord, listNodeProcessor, listNodeGeheugenKaart, listNodeOptischedrives,
            listNodeHardeschijf, listNodeGrafischeKaart, listNodeCPUKoeler, listNodeVoeding, listNodeBehuizing);
        }
        
    }
}
