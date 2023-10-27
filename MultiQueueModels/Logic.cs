using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public static class Logic
    {
        public static void ReadFromFile(string fileName, out int numberOfServers, out Enums.SelectionMethod selectionMethod, out Enums.StoppingCriteria stoppingCriteria, out int stoppingNumber, out string systemData, List<string> serverData)
        {
            string fileContent;
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }
            throw new NotImplementedException();
            //To Do: use the data read from a file to fill in the out parameters.
            //You can look at the file content in the TestCase1.txt
        }

        public static void CalculateComulativeAndRange(List<TimeDistribution> timeDistributionList)
        {
            //To Do: calculate the commulative probability and range for a give time distribution
        }

        public static void CalculateServerPerformanceMeasures(Server server)
        {
            //To Do: Calculate the performance measures for a given server 
        }

        public static void CalculateSystemPerformanceMeasures(SimulationSystem system)
        {
            //To Do: Calculate the performance measures for the system 
        }

        public static void ParseDistributionData(string data, List<TimeDistribution> interarrivalTimeDistributions)
        {
            //To Do: Parse the data for a given time distribution
        }

        public static void ParseServerDistributionData(List<string> distributionData, List<Server> servers)
        {
            //To Do: Parse the data for each server
        }
    }
}
