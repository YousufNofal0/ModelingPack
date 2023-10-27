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
        public static void ReadFromFile(string fileName)
        {
            string fileContent;
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }
            //To Do: use the data read from a file
        }

        public static void CalculateCommulativeAndRange(List<TimeDistribution> timeDistributionList)
        {
            //To Do: calculate the commulative probability and range for a give time distribution
        }

        public static void CalculateServerPerformanceMeasures(Server server)
        {
            //To Do: Calculate the performance measures for a given server 
        }

        public static void CalculateSystemPerformanceMeasures()
        {
            //To Do: Calculate the performance measures for the system 
        }

    }
}
