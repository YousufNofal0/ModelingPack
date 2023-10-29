namespace MultiQueueModels
{
    public class SimulationCase
    {
        public SimulationCase()
        {
            this.AssignedServer = new Server();
        }

        public SimulationCase(int customerNumber, int randomInterArrival, int randomService)
        {
            CustomerNumber = customerNumber;
            RandomInterArrival = randomInterArrival;
            RandomService = randomService;
            InterArrival = 0;
            ArrivalTime = 0;
        }

        public int CustomerNumber { get; set; }
        public int RandomInterArrival { get; set; }
        public int InterArrival { get; set; }
        public int ArrivalTime { get; set; }
        public int RandomService { get; set; }
        public int ServiceTime { get; set; }
        public Server AssignedServer { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int TimeInQueue { get; set; }
    }
}
