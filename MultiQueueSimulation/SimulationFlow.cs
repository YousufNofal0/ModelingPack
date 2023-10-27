using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiQueueModels;


namespace MultiQueueSimulation
{
    class SimulationFlow
    {
        public SimulationFlow() {
            system = new SimulationSystem();
        }
        public SimulationSystem system { set; get; }

        public void ParseInputs(string fileName) {
            List<string> serverData = new List<string>();
            Logic.ReadFromFile(fileName, out int numberOfServers, out Enums.SelectionMethod selectionMethod, out Enums.StoppingCriteria stoppingCriteria, out int stoppingNumber, out string systemData, serverData);
            system.NumberOfServers = numberOfServers;
            system.SelectionMethod = selectionMethod;
            system.StoppingCriteria = stoppingCriteria;
            system.StoppingNumber = stoppingNumber;
            Logic.ParseDistributionData(systemData, system.InterarrivalDistribution);
            Logic.ParseServerDistributionData(serverData, system.Servers);
        }

        public void ParseInputs(int numberOfServers, int stoppingNumber, Enums.StoppingCriteria stoppingCriteria, Enums.SelectionMethod selectionMethod, string systemData, List<string> serverData)
        {
            system.NumberOfServers = numberOfServers;
            system.SelectionMethod = selectionMethod;
            system.StoppingCriteria = stoppingCriteria;
            system.StoppingNumber = stoppingNumber;
            Logic.ParseDistributionData(systemData, system.InterarrivalDistribution);
            Logic.ParseServerDistributionData(serverData, system.Servers);
        }

        public void Run()
        {

            foreach (Server server in system.Servers)
                Logic.CalculateComulativeAndRange(server.TimeDistribution);

            Logic.CalculateComulativeAndRange(system.InterarrivalDistribution);

            Logic.CalculateSystemPerformanceMeasures(system);
        }
    }
}
