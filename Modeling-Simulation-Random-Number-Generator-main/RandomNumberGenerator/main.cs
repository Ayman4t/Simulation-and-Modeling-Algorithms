using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace RandomNumberGenerator
{
    public partial class main : Form
    {
        private MainFuctions fun;

        public main()
        {
            InitializeComponent();
            fun = new MainFuctions();
        }


        private void generateButton_Click(object sender, EventArgs e)
        {
            randomNumbersTable.Rows.Clear();
            if (seedTextBox.Text.Equals(String.Empty) || multiplierTextBox.Text.Equals(String.Empty) || incrementTextBox.Equals(String.Empty) || modulusTextBox.Equals(String.Empty) || numberOfIterationsTextBox.Equals(String.Empty))
            {
                MessageBox.Show("Invalid Input, Please Enter Valid Input");
            }else
            {

                double seed = double.Parse(seedTextBox.Text);
                double multiplier = double.Parse(multiplierTextBox.Text);
                double increment = double.Parse(incrementTextBox.Text);
                double modulus = double.Parse(modulusTextBox.Text);
                double iteration = double.Parse(numberOfIterationsTextBox.Text);

                List<double> randomNumber = new List<double>();
                double LongestPeriod = 0;
                if (fun.validateInput(multiplier, increment, modulus, seed))
                {
                    randomNumber = fun.LCG_Generator(multiplier, increment, modulus, seed, iteration);
                    LongestPeriod = fun.calculateActualPeriodLenth(multiplier, increment, modulus, seed);
                }
                else
                {
                    MessageBox.Show("Invalid Input, Please Enter Valid Input");
                }


                for (int i = 0; i < randomNumber.Count; i++)
                {
                    randomNumbersTable.Rows.Add(randomNumber[i]);
                }
                cycleLengthTextBox.Text = LongestPeriod.ToString();

            }
            
        }

        private void main_Load(object sender, EventArgs e)
        {

        }
    }
}
