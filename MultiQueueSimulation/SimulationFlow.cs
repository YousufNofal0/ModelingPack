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
            Logic.ReadFromFile(fileName, out int numberOfServers, out Enums.SelectionMethod selectionMethod,
                out Enums.StoppingCriteria stoppingCriteria, out int stoppingNumber, out string systemData, serverData);

            for (int i = 0; i < numberOfServers; ++i)
                system.Servers.Add(new Server(i+1));

            system.NumberOfServers = numberOfServers;
            system.SelectionMethod = selectionMethod;
            system.StoppingCriteria = stoppingCriteria;
            system.StoppingNumber = stoppingNumber;
            Logic.ParseDistributionData(systemData, system.InterarrivalDistribution);
            Logic.ParseServerDistributionData(serverData, system.Servers);
        }

        public void ParseInputs(int numberOfServers, int stoppingNumber, Enums.StoppingCriteria stoppingCriteria,
            Enums.SelectionMethod selectionMethod, string systemData, List<string> serverData)
        { 
            for (int i = 0; i < numberOfServers; ++i)
                system.Servers.Add(new Server(i + 1));

            system.NumberOfServers = numberOfServers;
            system.SelectionMethod = selectionMethod;
            system.StoppingCriteria = stoppingCriteria;
            system.StoppingNumber = stoppingNumber;
            Logic.ParseDistributionData(systemData, system.InterarrivalDistribution);
            Logic.ParseServerDistributionData(serverData, system.Servers);
        }

        public void Run()
        {
            Logic.CalculateCumulativeAndRange(system.InterarrivalDistribution);

            foreach (Server server in system.Servers)
                Logic.CalculateCumulativeAndRange(server.TimeDistribution);

            if (system.StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers)
            {                
                Random rnd = new Random();
                for (int i = 0; i < system.StoppingNumber; ++i)
                {
                    system.SimulationTable.Add(new SimulationCase(i+1, rnd.Next() % 100, rnd.Next() % 100));
                    if (i != 0) {
                        system.SimulationTable[i].InterArrival = Logic.CalculateTime(system.InterarrivalDistribution, system.SimulationTable[i].RandomInterArrival);
                        system.SimulationTable[i].ArrivalTime = system.SimulationTable[i-1].ArrivalTime + system.SimulationTable[i].InterArrival;
                    }
                }




                //for (int i = 0; i < system.StoppingNumber; ++i) {
                //    system.SimulationTable[i].ServiceTime = Logic.CalculateTime(system.SimulationTable[i].AssignedServer.TimeDistribution, system.SimulationTable[i].RandomService);
                //}
                
            }

            Logic.CalculateSystemPerformanceMeasures(system);
        }
    }
}
