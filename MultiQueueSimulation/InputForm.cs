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
                        if (selectionMethod.SelectedItem.ToString() == "Random")
                            SelectionMethod = Enums.SelectionMethod.Random;
                        else if (selectionMethod.SelectedItem.ToString() == "Least Utilization")
                            SelectionMethod = Enums.SelectionMethod.LeastUtilization;
                        else
                            SelectionMethod = Enums.SelectionMethod.HighestPriority;

                        if (stoppingCriteria.SelectedItem.ToString() == "Simulation End Time")
                            StoppingCriteria = Enums.StoppingCriteria.SimulationEndTime;
                        else
                            StoppingCriteria = Enums.StoppingCriteria.NumberOfCustomers;

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
                            textBox.Text = "Textbox " + (i + 1);
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
                            List<string> serverData = new List<string>();
                            foreach (var textbox in serverTextboxes)
                            {
                                serverData.Add(textbox.Text);
                            }


                            MessageBox.Show(string.Join(Environment.NewLine, serverData));
                            this.Close();
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
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Done!");
                    FileName = openFileDialog.FileName;
                    this.Close();
                }
            }
        }
    }
}
