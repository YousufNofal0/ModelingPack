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
            #region Testing
            int i = 1;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SimulationFlow simulationFlow = new SimulationFlow();
            simulationFlow.ParseInputs(Constants.FileNames.TestCase1);
            simulationFlow.Run();
            string result = TestingManager.Test(simulationFlow.system, Constants.FileNames.TestCase1);
            MessageBox.Show(result + "\nfor case: " + i++);
            DataView view = new DataView(simulationFlow.system);
            Application.Run(view);

            simulationFlow = new SimulationFlow();
            simulationFlow.ParseInputs(Constants.FileNames.TestCase2);
            simulationFlow.Run();
            result = TestingManager.Test(simulationFlow.system, Constants.FileNames.TestCase2);
            MessageBox.Show(result + "\nfor case: " + i++);
            view = new DataView(simulationFlow.system);
            Application.Run(view);

            simulationFlow = new SimulationFlow();
            simulationFlow.ParseInputs(Constants.FileNames.TestCase3);
            simulationFlow.Run();
            result = TestingManager.Test(simulationFlow.system, Constants.FileNames.TestCase3);
            MessageBox.Show(result + "\nfor case: " + i++);
            view = new DataView(simulationFlow.system);
            Application.Run(view);

            simulationFlow = new SimulationFlow();
            simulationFlow.ParseInputs(Constants.FileNames.TestCase4);
            simulationFlow.Run();
            result = TestingManager.Test(simulationFlow.system, Constants.FileNames.TestCase4);
            MessageBox.Show(result + "\nfor case: " + i++);
            view = new DataView(simulationFlow.system);
            Application.Run(view);

            simulationFlow = new SimulationFlow();
            simulationFlow.ParseInputs(Constants.FileNames.TestCase5);
            simulationFlow.Run();
            result = TestingManager.Test(simulationFlow.system, Constants.FileNames.TestCase5);
            MessageBox.Show(result + "\nfor case: " + i++);
            view = new DataView(simulationFlow.system);
            Application.Run(view);

            simulationFlow = new SimulationFlow();
            simulationFlow.ParseInputs(Constants.FileNames.TestCase6);
            simulationFlow.Run();
            result = TestingManager.Test(simulationFlow.system, Constants.FileNames.TestCase6);
            MessageBox.Show(result + "\nfor case: " + i++);
            view = new DataView(simulationFlow.system);
            Application.Run(view);
            #endregion

            InputForm formInput = new InputForm();
            Application.Run(formInput);
        }
    }
}
