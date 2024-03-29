﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public static class Logic
    {
        public static void ReadFromFile(string fileName, out int numberOfServers, out Enums.SelectionMethod selectionMethod,
            out Enums.StoppingCriteria stoppingCriteria, out int stoppingNumber, out string systemData, List<string> serverData)
        {
            numberOfServers = 0; selectionMethod = Enums.SelectionMethod.Random; stoppingCriteria = Enums.StoppingCriteria.NumberOfCustomers;
            stoppingNumber = 0; systemData = "";
            //To Do: use the data read from a file to fill in the out parameters.
            //You can look at the file content in the TestCase1.txt
            string line;
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    while ((line = reader.ReadLine()) != null)
                    {

                        if (line.Equals("NumberOfServers"))
                        {
                            line = reader.ReadLine();
                            int.TryParse(line, out numberOfServers);
                        }

                        if (line.Equals("StoppingNumber"))
                        {
                            line = reader.ReadLine();
                            int.TryParse(line, out stoppingNumber);
                        }


                        if (line.Equals("StoppingCriteria"))
                        {
                            line = reader.ReadLine();

                            bool x = int.TryParse(line, out int stc);
                            stoppingCriteria = x ? (Enums.StoppingCriteria)stc : (Enums.StoppingCriteria)Enum.Parse(typeof(Enums.StoppingCriteria), line);
                        }

                        if (line.Equals("SelectionMethod"))
                        {
                            line = reader.ReadLine();

                            bool x = int.TryParse(line, out int sem);
                            selectionMethod = x ? (Enums.SelectionMethod)sem : (Enums.SelectionMethod)Enum.Parse(typeof(Enums.SelectionMethod), line);
                        }

                        if (line.Equals("InterarrivalDistribution"))
                        {
                            while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                            {
                                systemData += line + "\n";
                            }
                        }

                        if (line.StartsWith("ServiceDistribution_Server"))
                        {
                            string _serverData = "";
                            while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                            {
                                _serverData += line + "\n";
                            }
                            serverData.Add(_serverData);
                        }
                    }
                }
            }
            //Done: Yousuf
        }

        public static void CalculateCumulativeAndRange(List<TimeDistribution> timeDistributionList)
        {
            //To Do: calculate the cumulative probability and range for a give time distribution
            for (int i = 1; i < timeDistributionList.Count; i++)
            {

                timeDistributionList[i].CummProbability = timeDistributionList[i - 1].CummProbability + timeDistributionList[i].Probability;

                timeDistributionList[i].MinRange = (timeDistributionList[i - 1].MaxRange + 1);

                timeDistributionList[i].MaxRange = (int)(timeDistributionList[i].CummProbability * 100);

            }
            //Done: Renad
        }

        public static void CalculateServerPerformanceMeasures(Server server, int totalRunTime)
        {
            //To Do: Calculate the performance measures for a given server 
            if(server.TotalNumberOfCustomers != 0)
                server.AverageServiceTime = (decimal)server.TotalWorkingTime / (decimal) server.TotalNumberOfCustomers;
            server.Utilization = (decimal)server.TotalWorkingTime / (decimal)totalRunTime;
            server.IdleProbability = 1 - server.Utilization;
            //Modified and Reviewed: Nofal
            //Done: Renad and Maria
        }

        public static void CalculatePerformanceMeasures(SimulationSystem system)
        {
            //To Do: Calculate the performance measures for the system 
            int totalWaitingTime = 0;
            int waitedCustomersCount = 0;
            int totalWorkingTime = 0;
            List<SimulationCase> simQueue = new List<SimulationCase>();
            system.PerformanceMeasures.MaxQueueLength = 0;
            for (int i=0; i<system.SimulationTable.Count; i++)
            {
                totalWorkingTime = Math.Max(totalWorkingTime, system.SimulationTable[i].EndTime);
                for (int j = 0; j < simQueue.Count; ++j) {
                    if (simQueue[j].StartTime <= system.SimulationTable[i].ArrivalTime)
                        simQueue.RemoveAt(j);
                }
                //system.SimulationTable[i].TimeInQueue = system.SimulationTable[i].StartTime - system.SimulationTable[i].ArrivalTime;
                totalWaitingTime += system.SimulationTable[i].TimeInQueue;
                if(system.SimulationTable[i].TimeInQueue!=0)
                {
                    simQueue.Add(system.SimulationTable[i]);
                    waitedCustomersCount++;
                }
                system.PerformanceMeasures.MaxQueueLength = Math.Max(system.PerformanceMeasures.MaxQueueLength, simQueue.Count);
            }
            system.PerformanceMeasures.AverageWaitingTime = (decimal) totalWaitingTime / (decimal) system.SimulationTable.Count;
            system.PerformanceMeasures.WaitingProbability = (decimal) waitedCustomersCount / (decimal) system.SimulationTable.Count;

            for (int i = 0; i < system.Servers.Count; ++i)
                CalculateServerPerformanceMeasures(system.Servers[i], totalWorkingTime);
            
            
            //Done: Renad
            //Modified: Nofal
        }

        public static int CalculateTime(List<TimeDistribution> timeDistribution, int randomNumber)
        {
            foreach (var item in timeDistribution)
                if (randomNumber >= item.MinRange && randomNumber <= item.MaxRange)
                    return item.Time;
            return 0;
            //Done: Nofal
        }

        public static void ParseDistributionData(string data, List<TimeDistribution> interarrivalTimeDistributions)
        {
            //To Do: Parse the data for a given time distribution
            using (StringReader reader = new StringReader(data))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    int.TryParse(parts[0], out int time);
                    decimal.TryParse(parts[1], out decimal probability);
                    interarrivalTimeDistributions.Add(new TimeDistribution(time, probability));
                }
            }
            //Done: Nofal
        }

        public static void ParseServerDistributionData(List<string> distributionData, List<Server> servers)
        {
            //To Do: Parse the data for each server
            for(int i = 0; i < distributionData.Count; ++i)
            {
                ParseDistributionData(distributionData[i], servers[i].TimeDistribution);
            }
            //Done: Nofal
        }
    }
}
