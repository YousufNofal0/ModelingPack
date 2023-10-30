using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class Server
    {
        public Server()
        {
            this.TimeDistribution = new List<TimeDistribution>();
        }

        public Server(int id)
        {
            ID = id;
            TimeDistribution = new List<TimeDistribution>();
            TotalWorkingTime = 0;
            TotalNumberOfCustomers = 0;
            Utilization = 0;
        }

        override
        public string ToString()
        {
            return ID.ToString();
        }

        public int ID { get; set; }
        public decimal IdleProbability { get; set; }
        public decimal AverageServiceTime { get; set; } 
        public decimal Utilization { get; set; }

        public List<TimeDistribution> TimeDistribution;

        //optional if needed use them
        public int FinishTime { get; set; }
        public int TotalWorkingTime { get; set; }
        public int NextIdle { get; set; }
        public int TotalNumberOfCustomers { get; set; }
    }
}
