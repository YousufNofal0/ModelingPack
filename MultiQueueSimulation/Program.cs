using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueTesting;
using MultiQueueModels;

namespace MultiQueueSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InputForm formInput = new InputForm();
            Application.Run(formInput);
            SimulationFlow simulationFlow = new SimulationFlow();
            if (String.IsNullOrEmpty(formInput.FileName))
                simulationFlow.ParseInputs(formInput.NumberOfServers, formInput.StoppingNumber, formInput.StoppingCriteria,
                    formInput.SelectionMethod, formInput.SystemData, formInput.ServerData);
            else
                simulationFlow.ParseInputs(formInput.FileName);
            //SimulationSystem system = new SimulationSystem();
            //string result = TestingManager.Test(system, Constants.FileNames.TestCase1);
            //MessageBox.Show(result);
        }
    }
}
