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
using MultiQueueTesting;

namespace MultiQueueSimulation
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
            stoppingCriteria.DataSource = new[] {
                new { Text = "Maximum Number of Customers", Value = "NumberOfCustomers" },
                new { Text = "Simulation End Time", Value = "SimulationEndTime" },
            };

            stoppingCriteria.DisplayMember = "Text";
            stoppingCriteria.ValueMember = "Value";

            selectionMethod.DataSource = new[] {
                new { Text = "Priority", Value = "HighestPriority"  },
                new { Text = "Random", Value = "Random"},
                new { Text = "LeastUtilization", Value = "LeastUtilization"},
            };

            selectionMethod.DisplayMember = "Text";
            selectionMethod.ValueMember = "Value";

            stoppingCriteria.Text = "Maximum Number of Customers";
            selectionMethod.Text = "Priority";
        }

        public string FileName { set; get; }
        public int NumberOfServers { set;  get; }
        public int StoppingNumber { set; get; }
        public Enums.StoppingCriteria StoppingCriteria { set; get; }
        public Enums.SelectionMethod SelectionMethod { set; get; }
        public List<string> ServerData { set; get; }
        public string SystemData { set; get; }
        private void Next_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(systemData.Text))
            {
                SystemData = systemData.Text;
                if (int.TryParse(stoppingNumber.Text, out int _stoppingNumber))
                {
                    StoppingNumber = _stoppingNumber;
                    if (int.TryParse(numberOfServers.Text, out int _numberOfServers))
                    {
                        NumberOfServers = _numberOfServers;
                        StoppingCriteria = (Enums.StoppingCriteria)Enum.Parse(typeof(Enums.StoppingCriteria), stoppingCriteria.SelectedValue.ToString());

                        SelectionMethod = (Enums.SelectionMethod)Enum.Parse(typeof(Enums.SelectionMethod), selectionMethod.SelectedValue.ToString());
                    
                        ServerData = new List<string>(_numberOfServers);
                        // Create a new form
                        Form serverDataForm = new Form();
                        serverDataForm.Text = "Server Data Form";
                        serverDataForm.Size = new System.Drawing.Size(300, 300); // Set the initial size of the form
                        serverDataForm.AutoScroll = true; // Enable auto-scrolling
                        List<TextBox> serverTextboxes = new List<TextBox>();

                        int textboxHeight = 60; // Adjust the height as needed
                        int yPos = 10;
                        for (int i = 0; i < _numberOfServers; i++)
                        {
                            TextBox textBox = new TextBox();
                            textBox.Name = "server" + i;
                            textBox.Text = "Probability Distribution for Server " + (i + 1);
                            textBox.Multiline = true;
                            textBox.ScrollBars = ScrollBars.Vertical;
                            textBox.Text = "Server " + (i + 1);
                            textBox.Size = new System.Drawing.Size(200, textboxHeight);
                            textBox.Location = new System.Drawing.Point(10, yPos);
                            serverDataForm.Controls.Add(textBox);
                            serverTextboxes.Add(textBox);
                            yPos += textboxHeight + 10;
                        }
                        Button btnSaveData = new Button();
                        btnSaveData.Text = "Ok";
                        btnSaveData.Location = new Point(10, yPos);
                        serverDataForm.Controls.Add(btnSaveData);

                        btnSaveData.Click += (s, args) =>
                        {
                            foreach (var textbox in serverTextboxes)
                            {
                                ServerData.Add(textbox.Text);
                            }
                            //this.Hide();
                            //serverDataForm.Hide();
                            SimulationFlow simulationFlow = new SimulationFlow();
                            simulationFlow.ParseInputs(NumberOfServers, StoppingNumber, StoppingCriteria,
                                SelectionMethod, SystemData, ServerData);


                            simulationFlow.Run();
                            DataView view = new DataView(simulationFlow.system);
                            view.ShowDialog();
                        };
                        // Show the new form
                        serverDataForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Enter a valid number for servers.");
                    }
                }
                else
                    MessageBox.Show("Enter a valid stopping number.");
            }
            else
                MessageBox.Show("Enter the interarrival distribution data");
        }

        private void SelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                    MessageBox.Show("Done!");
                    FileName = openFileDialog.FileName;
                    SimulationFlow simulationFlow = new SimulationFlow();
                    simulationFlow.ParseInputs(FileName);

                    simulationFlow.Run();
                    DataView view = new DataView(simulationFlow.system);
                    view.ShowDialog();
            }
        }
    }
}
