using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class TimeDistribution
    {
        public TimeDistribution(int time, decimal probability)
        {
            Time = time;
            Probability = probability;
            CummProbability = probability;
            MinRange = 1;
            MaxRange = (int)(probability * 100);
        }
        public int Time { get; set; }
        public decimal Probability { get; set; }
        public decimal CummProbability { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }

    }
}
