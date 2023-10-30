using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public void ProcessTable(ref int i, ref int nearestIdle, ref int nearestJ, ref Random rnd, ref int currentTime)
        {
            system.SimulationTable.Add(new SimulationCase(i + 1, rnd.Next() % 100 + 1, rnd.Next() % 100 + 1));

            system.SimulationTable[i].InterArrival = i == 0 ? 0 : Logic.CalculateTime(system.InterarrivalDistribution, system.SimulationTable[i].RandomInterArrival);
            system.SimulationTable[i].ArrivalTime = i == 0 ? 0 : system.SimulationTable[i - 1].ArrivalTime + system.SimulationTable[i].InterArrival;


            bool assigned = false;
            currentTime = system.SimulationTable[i].ArrivalTime;
            nearestIdle = system.Servers[0].NextIdle; nearestJ = 0;
            for (int j = 0; j < system.Servers.Count; ++j)
            {
                if (system.Servers[j].NextIdle <= currentTime)
                {
                    system.SimulationTable[i].AssignedServer = system.Servers[j];
                    system.SimulationTable[i].StartTime = currentTime;
                    assigned = true;
                    break;
                }
            }
            for (int j = 0; j < system.Servers.Count; ++j)
                if (nearestIdle > system.Servers[j].NextIdle)
                {
                    nearestJ = j;
                    nearestIdle = system.Servers[j].NextIdle;
                }


            if (!assigned)
            {
                system.SimulationTable[i].AssignedServer = system.Servers[nearestJ];
                system.SimulationTable[i].StartTime = nearestIdle;
                system.SimulationTable[i].TimeInQueue = nearestIdle - currentTime;
            }
            system.SimulationTable[i].ServiceTime = Logic.CalculateTime(system.SimulationTable[i].AssignedServer.TimeDistribution,
                system.SimulationTable[i].RandomService);
            system.SimulationTable[i].EndTime = system.SimulationTable[i].AssignedServer.NextIdle = system.SimulationTable[i].StartTime +
                system.SimulationTable[i].ServiceTime;
            system.SimulationTable[i].AssignedServer.TotalWorkingTime += system.SimulationTable[i].ServiceTime;
            system.SimulationTable[i].AssignedServer.TotalNumberOfCustomers++;
        }

        public void processTableLeastUtilization(ref int i, ref int nearestIdle, ref int nearestJ, ref Random rnd, ref int currentTime)
        {
            system.SimulationTable.Add(new SimulationCase(i + 1, rnd.Next() % 100 + 1, rnd.Next() % 100 + 1));

            system.SimulationTable[i].InterArrival = i == 0 ? 0 : Logic.CalculateTime(system.InterarrivalDistribution, system.SimulationTable[i].RandomInterArrival);
            system.SimulationTable[i].ArrivalTime = i == 0 ? 0 : system.SimulationTable[i - 1].ArrivalTime + system.SimulationTable[i].InterArrival;


            bool assigned = false;
            currentTime = system.SimulationTable[i].ArrivalTime;
            nearestIdle = system.Servers[0].NextIdle; nearestJ = 0;
            List<Server> availableServers = new List<Server>();
            for (int j = 0; j < system.Servers.Count; ++j)
            {
                if(currentTime != 0)
                    system.Servers[j].Utilization = (decimal)system.Servers[j].TotalWorkingTime / (decimal) currentTime;
                if (system.Servers[j].NextIdle <= currentTime)
                    availableServers.Add(system.Servers[j]);
            }

            if (availableServers.Count == 1)
            {
                system.SimulationTable[i].AssignedServer = availableServers[0];
                system.SimulationTable[i].StartTime = currentTime;
                assigned = true;
            }

            else if (availableServers.Count > 1) {
                decimal minUtil = int.MaxValue; int minIndex= 0;
                for (int j = 0; j < availableServers.Count; ++j) 
                    if (minUtil > availableServers[j].Utilization)
                    {
                        minUtil = availableServers[j].Utilization;
                        minIndex = j;
                    }
                
                system.SimulationTable[i].AssignedServer = availableServers[minIndex];
                system.SimulationTable[i].StartTime = currentTime;
                assigned = true;
            }

            for (int j = 0; j < system.Servers.Count; ++j)
                if (nearestIdle > system.Servers[j].NextIdle)
                {
                    nearestJ = j;
                    nearestIdle = system.Servers[j].NextIdle;
                }
                else if (nearestIdle == system.Servers[j].NextIdle)
                    if (system.Servers[j].Utilization < system.Servers[nearestJ].Utilization)
                        nearestJ = j;
                

            if (!assigned)
            {
                system.SimulationTable[i].AssignedServer = system.Servers[nearestJ];
                system.SimulationTable[i].StartTime = nearestIdle;
                system.SimulationTable[i].TimeInQueue = nearestIdle - currentTime;
            }


            system.SimulationTable[i].ServiceTime = Logic.CalculateTime(system.SimulationTable[i].AssignedServer.TimeDistribution,
                system.SimulationTable[i].RandomService);
            system.SimulationTable[i].EndTime = system.SimulationTable[i].AssignedServer.NextIdle = system.SimulationTable[i].StartTime +
                system.SimulationTable[i].ServiceTime;
            system.SimulationTable[i].AssignedServer.TotalWorkingTime += system.SimulationTable[i].ServiceTime;
            system.SimulationTable[i].AssignedServer.TotalNumberOfCustomers++;
            
        }

        public void Run()
        {

            #region PreCalculations
            Logic.CalculateCumulativeAndRange(system.InterarrivalDistribution);

            for (int i = 0; i < system.Servers.Count; ++i)
                Logic.CalculateCumulativeAndRange(system.Servers[i].TimeDistribution);
            #endregion

            #region NumberOfCustomers
            if (system.StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers)
            {
                int currentTime = 0;
                Random rnd = new Random();
                int nearestIdle = 0, nearestJ = 0;
                for (int i = 0; i < system.StoppingNumber; ++i)
                    if(system.SelectionMethod != Enums.SelectionMethod.LeastUtilization)
                        ProcessTable(ref i, ref nearestIdle, ref nearestJ, ref rnd, ref currentTime);
                    else
                        processTableLeastUtilization(ref i, ref nearestIdle, ref nearestJ, ref rnd, ref currentTime);

            }
            #endregion

            #region SimulationEndTime
            if (system.StoppingCriteria == Enums.StoppingCriteria.SimulationEndTime) {
                int currentTime = 0;
                Random rnd = new Random();
                int nearestIdle = 0, nearestJ = 0, i = 0;

                while(currentTime <= system.StoppingNumber)
                {
                    if (system.SelectionMethod != Enums.SelectionMethod.LeastUtilization)
                        ProcessTable(ref i, ref nearestIdle, ref nearestJ, ref rnd, ref currentTime);
                    else
                        processTableLeastUtilization(ref i, ref nearestIdle, ref nearestJ, ref rnd, ref currentTime);
                    ++i;
                }

            }
            #endregion

            #region PostCalculations
            Logic.CalculatePerformanceMeasures(system);
            #endregion
        }
    }
}
