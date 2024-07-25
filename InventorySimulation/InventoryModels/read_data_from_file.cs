using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels
{

    public class ReadDataFromFile
    {

       
        public List<Distribution> Commulative(List<Distribution> Distribution_table)
        {
            for (int i = 0; i < Distribution_table.Count; i++)
            {
                if (i == 0)
                {
                    Distribution_table[i].CummProbability = Distribution_table[i].Probability;
                    Distribution_table[i].MinRange = 0;
                    Distribution_table[i].MaxRange = (int)(Distribution_table[i].CummProbability * 100);
                }
                else
                {
                    Distribution_table[i].CummProbability = Distribution_table[i - 1].CummProbability + Distribution_table[i].Probability;
                    Distribution_table[i].MinRange = (int)(Distribution_table[i - 1].MaxRange) + 1;
                    Distribution_table[i].MaxRange = (int)(Distribution_table[i].CummProbability * 100);
                }
            }
            return Distribution_table;
        }

        public SimulationSystem read_test_case_data(SimulationSystem simulator, String path)
        {
            String fileName = path;
            String[] file_lines = File.ReadAllLines(fileName);
            simulator.OrderUpTo = int.Parse(file_lines[1]);
            simulator.ReviewPeriod = int.Parse(file_lines[4]);
            simulator.StartInventoryQuantity = int.Parse(file_lines[7]);
            simulator.StartLeadDays = int.Parse(file_lines[10]);
            simulator.StartOrderQuantity = int.Parse(file_lines[13]);
            simulator.NumberOfDays = int.Parse(file_lines[16]);
            
            // loop to get demand table.
            for (int i = 19; i <= file_lines.Length; i++)
            {
                // demand table is ended.
                if (file_lines[i] == "")
                {
    
                    break;
                }
                // there is more data in demand table.
                else
                {
                    // split the line to demand value and probability
                    String[] lineWords = file_lines[i].Split(',');
                    Distribution DemandDistribution = new Distribution();
                    // set demand value.
                    DemandDistribution.Value = int.Parse(lineWords[0]);
                    // set demand probability.
                    DemandDistribution.Probability = decimal.Parse(lineWords[1]);
                   
                    
                    // add the demand Distribution to the demand Distribution of the system.
                    simulator.DemandDistribution.Add(DemandDistribution);
                }

            }
            // loop to get leadDays table.
            for (int i = 26; i < file_lines.Length; i++)
            {
                // leadDays table is ended.
                if (file_lines[i] == "")
                {

                    break;
                }
                // there is more data in leadDays table.
                else
                {
                    // split the line to leadDays value and probability
                    String[] lineWords = file_lines[i].Split(',');
                    Distribution LeadDistribution = new Distribution();
                    // set leadDays value.
                    LeadDistribution.Value = int.Parse(lineWords[0]);
                    // set leadDays probability.
                    LeadDistribution.Probability = decimal.Parse(lineWords[1]);
                    // add the leadDaysDistribution to the leadDays Distribution of the system.

                    simulator.LeadDaysDistribution.Add(LeadDistribution);

                }

            }
            return simulator;
        }
    }
}
