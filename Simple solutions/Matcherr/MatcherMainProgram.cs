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
        public List<Motherboard> listNodeMotherboard;
        public List<Processor> listNodeProcessor;
        public List<RAM> listNodeRAM;
        public List<ProcessorCooler> listNodeProcessorCooler;
        public List<PowerSupply> listNodePowerSupply;
        public List<GraphicCard> listNodeGraphicCard;
        public List<ComputerCase> listNodeComputerCase;
        public List<HardDrive> listNodeHardDrive;
        public List<OpticalDrive> listNodeOpticalDrive;

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
            listNodeMotherboard = new List<Motherboard>();
            listNodeProcessor = new List<Processor>();
            listNodeRAM = new List<RAM>();
            listNodeProcessorCooler = new List<ProcessorCooler>();
            listNodePowerSupply = new List<PowerSupply>();
            listNodeGraphicCard = new List<GraphicCard>();
            listNodeComputerCase = new List<ComputerCase>();
            listNodeHardDrive = new List<HardDrive>();
            listNodeOpticalDrive = new List<OpticalDrive>();
        }

        /* The runMatchProgram runs all the necessary functions to get
         * the nodes from the neo4J database and pickout the ones with
         * the lowest price.
         */
        
        public void runMatcherProgram()
        {
            //Run the query to retrieve the data from the database.
            QueryManager qm = new QueryManager(); 
            qm.runAllQuery(searchPropertiesModel, listNodeMotherboard, listNodeProcessor, listNodeRAM, listNodeOpticalDrive,
            listNodeHardDrive, listNodeGraphicCard, listNodeProcessorCooler, listNodePowerSupply, listNodeComputerCase);

            //Run the match to compare all the nodes and sort them in orde of lowest price.
            ComponentsMatcher matcher = new ComponentsMatcher();
            matcher.matchComponentsWithLowestPrice(listNodeMotherboard, listNodeProcessor, listNodeRAM, listNodeOpticalDrive,
            listNodeHardDrive, listNodeGraphicCard, listNodeProcessorCooler, listNodePowerSupply, listNodeComputerCase);
        }
        
    }
}
