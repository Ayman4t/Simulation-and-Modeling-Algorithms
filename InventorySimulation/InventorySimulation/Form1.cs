using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using InventoryModels;
using InventoryTesting;

namespace InventorySimulation
{
    public partial class Form1 : Form
    {
        SimulationSystem Sim_System= new SimulationSystem() ;
         string path ;

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Test Case 1");
            comboBox1.Items.Add("Test Case 2");

        }


        private void browse_Click(object sender, EventArgs e)
        {
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedItem.ToString() == "Test Case 1")
            {
                 path = "D:\\fourth year first term\\modeling and simulating system\\tasks\\Lab7_Task 3\\[Students]_Template\\InventorySimulation\\InventorySimulation\\TestCases\\TestCase1.txt";
            }
            else if (comboBox1.SelectedItem.ToString() == "Test Case 2")
            {
                 path = "D:\\fourth year first term\\modeling and simulating system\\tasks\\Lab7_Task 3\\[Students]_Template\\InventorySimulation\\InventorySimulation\\TestCases\\TestCase4.txt";
            }
        }

        private void simulate_Click(object sender, EventArgs e)
        {
            
            Sim_System = new SimulationSystem();
            Sim_System.Start_Simulation(Sim_System, path);
           
            

            dataGridView1.Rows.Clear();
            for (int i = 0; i < Sim_System.SimulationTable.Count(); i++)
            {
                //getting new row
                int n = dataGridView1.Rows.Add();

                //completing the table
                dataGridView1.Rows[n].Cells[0].Value = Sim_System.SimulationTable[n].Day;
                dataGridView1.Rows[n].Cells[1].Value = Sim_System.SimulationTable[n].Cycle;
                dataGridView1.Rows[n].Cells[2].Value = Sim_System.SimulationTable[n].DayWithinCycle;
                dataGridView1.Rows[n].Cells[3].Value = Sim_System.SimulationTable[n].BeginningInventory;
                dataGridView1.Rows[n].Cells[4].Value = Sim_System.SimulationTable[n].RandomDemand;
                dataGridView1.Rows[n].Cells[5].Value = Sim_System.SimulationTable[n].Demand;
                dataGridView1.Rows[n].Cells[6].Value = Sim_System.SimulationTable[n].EndingInventory;
                dataGridView1.Rows[n].Cells[7].Value = Sim_System.SimulationTable[n].ShortageQuantity;
                dataGridView1.Rows[n].Cells[8].Value = Sim_System.SimulationTable[n].OrderQuantity;
                dataGridView1.Rows[n].Cells[9].Value = Sim_System.SimulationTable[n].RandomLeadDays;
                dataGridView1.Rows[n].Cells[10].Value = Sim_System.SimulationTable[n].LeadDays;
                dataGridView1.Rows[n].Cells[11].Value = Sim_System.SimulationTable[n].DaysUntilOrderArrives;


                ae.Text = Sim_System.PerformanceMeasures.EndingInventoryAverage.ToString();
                As.Text = Sim_System.PerformanceMeasures.ShortageQuantityAverage.ToString();


            }



            string result = "";
            Console.WriteLine(comboBox1.SelectedItem.ToString());
            if (comboBox1.SelectedItem.ToString() == "Test Case 1")
            {
                

                result = TestingManager.Test(Sim_System, Constants.FileNames.TestCase1);
            }
            else if (comboBox1.SelectedItem.ToString() == "Test Case 2")
            {
                

                result = TestingManager.Test(Sim_System, Constants.FileNames.TestCase4);
            }



            MessageBox.Show(result);
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void Case_TextChanged(object sender, EventArgs e)
        {

        }

        private void ad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ae_TextChanged(object sender, EventArgs e)
        {



        }
    }
}
