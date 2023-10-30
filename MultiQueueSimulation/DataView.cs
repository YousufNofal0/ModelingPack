using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueModels;

namespace MultiQueueSimulation
{
   
    public partial class DataView : Form
    {
        public SimulationSystem _System { set; get; }

        public DataView()
        {
            InitializeComponent();
        }
        public DataView(SimulationSystem system) {
            _System = system;
            InitializeComponent();
            dataGridView1.DataSource = system.SimulationTable;
            waitingProbability.Text = system.PerformanceMeasures.WaitingProbability.ToString();
            avgWaitingTime.Text = system.PerformanceMeasures.AverageWaitingTime.ToString();
            maxQueueLength.Text = system.PerformanceMeasures.MaxQueueLength.ToString();

            List<ComboBoxItem> items = new List<ComboBoxItem>();

            for (int i = 0; i < system.Servers.Count; ++i) 
                items.Add(new ComboBoxItem("Server" + (i+1), i));

            comboBox1.DataSource = items;
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";

            comboBox1.SelectedItem = items[0];

            idleProbability.Text = Math.Round(system.Servers[0].IdleProbability, 2).ToString();
            avgServiceTime.Text = Math.Round(system.Servers[0].AverageServiceTime, 2).ToString();
            utilization.Text = Math.Round(system.Servers[0].Utilization, 2).ToString();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            idleProbability.Text = Math.Round(_System.Servers[int.Parse(comboBox1.SelectedValue.ToString())].IdleProbability, 2).ToString();
            avgServiceTime.Text = Math.Round(_System.Servers[int.Parse(comboBox1.SelectedValue.ToString())].AverageServiceTime, 2).ToString();
            utilization.Text = Math.Round(_System.Servers[int.Parse(comboBox1.SelectedValue.ToString())].Utilization, 2).ToString();
        }
    }
}
