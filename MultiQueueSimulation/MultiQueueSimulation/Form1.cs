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
    public partial class Form1 : Form
    {
        SimulationSystem Sim_System = new SimulationSystem();
        Home h1 = new Home();
       
        
        String Path;
       
        public Form1(SimulationSystem system)
        {
            Sim_System = system;            InitializeComponent();
            //filling combobox 1
            comboBox1.Items.Add("Test Case 1");
            comboBox1.Items.Add("Test Case 2");
            comboBox1.Items.Add("Test Case 3");
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString()=="Test Case 1")
            {
                Path = "C:/Users/Ahmed M. Farid/Desktop/Lab 2_Task1/Template_Students/MultiQueueSimulation/MultiQueueSimulation/TestCases/TestCase1.txt";
            }
            else if(comboBox1.SelectedItem.ToString() == "Test Case 2")
            {
                Path = "C:/Users/Ahmed M. Farid/Desktop/Lab 2_Task1/Template_Students/MultiQueueSimulation/MultiQueueSimulation/TestCases/TestCase2.txt";
            }
            else if(comboBox1.SelectedItem.ToString() == "Test Case 2")
            {   
               Path = "C:/Users/Ahmed M. Farid/Desktop/Lab 2_Task1/Template_Students/MultiQueueSimulation/MultiQueueSimulation/TestCases/TestCase3.txt";
            }
        }

       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Sim_System = new SimulationSystem();

           


            //simulation running is required
            Sim_System.Run_Simulation(Sim_System, Path);

            Sim_System.ServerPerformanceMeasures(Sim_System);

            Servers_ComboBox.Items.Clear();
            for (int i = 0; i < Sim_System.Servers.Count; i++)
            {
                Servers_ComboBox.Items.Add("Server " + (i + 1).ToString());
            }





            //writing the table
            for (int i = 0; i < Sim_System.SimulationTable.Count(); i++)
            {
                //getting new row
                int n = dataGridView1.Rows.Add();

                //completing the table
                dataGridView1.Rows[n].Cells[0].Value = Sim_System.SimulationTable[n].CustomerNumber;
                dataGridView1.Rows[n].Cells[1].Value = Sim_System.SimulationTable[n].RandomInterArrival;
                dataGridView1.Rows[n].Cells[2].Value = Sim_System.SimulationTable[n].InterArrival;
                dataGridView1.Rows[n].Cells[3].Value = Sim_System.SimulationTable[n].ArrivalTime;
                dataGridView1.Rows[n].Cells[4].Value = Sim_System.SimulationTable[n].RandomService;
                dataGridView1.Rows[n].Cells[5].Value = Sim_System.SimulationTable[n].AssignedServer.ID;
                dataGridView1.Rows[n].Cells[6].Value = Sim_System.SimulationTable[n].StartTime;
                dataGridView1.Rows[n].Cells[7].Value = Sim_System.SimulationTable[n].EndTime;
                dataGridView1.Rows[n].Cells[8].Value = Sim_System.SimulationTable[n].ServiceTime;
                dataGridView1.Rows[n].Cells[9].Value = Sim_System.SimulationTable[n].TimeInQueue;
            }

            //filling text boxes of performance measures
            textBox1.Text = Sim_System.PerformanceMeasures.AverageWaitingTime.ToString();
            textBox2.Text = Sim_System.PerformanceMeasures.WaitingProbability.ToString();
            textBox3.Text = Sim_System.PerformanceMeasures.MaxQueueLength.ToString();

            string result = "";
            Console.WriteLine(comboBox1.SelectedItem.ToString());
            if (comboBox1.SelectedItem.ToString() == "Test Case 1")
            {
                Console.WriteLine(comboBox1.SelectedItem.ToString());

                result = TestingManager.Test(Sim_System, Constants.FileNames.TestCase1);
            }
            else if (comboBox1.SelectedItem.ToString() == "Test Case 2")
            {
                Console.WriteLine(comboBox1.SelectedItem.ToString());

                result = TestingManager.Test(Sim_System, Constants.FileNames.TestCase2);
            }

            else if (comboBox1.SelectedItem.ToString() == "Test Case 3")
            {
                Console.WriteLine(comboBox1.SelectedItem.ToString());

                result = TestingManager.Test(Sim_System, Constants.FileNames.TestCase3);
            }

            MessageBox.Show(result);

        

    }
       

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].Points.Clear();

            //plotting empty plot
            for (int i = 0; i < Sim_System.SimulationTable.Count; i++)
            {
                //Servers_ComboBox.Items.Add(i + 1);
                for (int j = 0; j < Sim_System.total_runtime; j++)
                {
                    chart1.Series["Series1"].Points.AddXY(j, 0);
                }

            }

            //drawing busy plot
            for (int i = 0; i < Sim_System.SimulationTable.Count; i++)
            {
                
                if (Sim_System.SimulationTable[i].AssignedServer.ID == Servers_ComboBox.SelectedIndex + 1)
                {
                    for (int j = 0; j < Sim_System.SimulationTable[i].ServiceTime; j++)
                    {
                        chart1.Series["Series1"].Points.AddXY(j + Sim_System.SimulationTable[i].StartTime, 1);
                    }
                }
            }
            textBox6.Text = Sim_System.Servers[Servers_ComboBox.SelectedIndex].Utilization.ToString();
            textBox4.Text = Sim_System.Servers[Servers_ComboBox.SelectedIndex].AverageServiceTime.ToString();
            textBox5.Text = Sim_System.Servers[Servers_ComboBox.SelectedIndex].IdleProbability.ToString();


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

