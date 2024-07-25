using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels
{
    public class SimulationSystem
    {

        public int find_value_of_random(List<Distribution> dist, int randomValue)
        {
            int i = 0;

            while(i < dist.Count)
            {
                if (randomValue >= dist[i].MinRange && randomValue <= dist[i].MaxRange)
                {
                    return dist[i].Value;

                }
                i++;
            }
            return 0;
        }

       

        public void Start_Simulation(SimulationSystem system, String Path)
        {
            
            simulate s=new simulate();
            s.run(system, Path);
            PerformanceMeasures.EndingInventoryAverage /= NumberOfDays;
            PerformanceMeasures.ShortageQuantityAverage /= NumberOfDays;


        }

       
        public SimulationSystem()
        {
            DemandDistribution = new List<Distribution>();
            LeadDaysDistribution = new List<Distribution>();
            SimulationTable = new List<SimulationCase>();
            PerformanceMeasures = new PerformanceMeasures();
        }


        ///////////// INPUTS /////////////

        public int OrderUpTo { get; set; }//M
        public int ReviewPeriod { get; set; } //N
        public int NumberOfDays { get; set; }
        public int StartInventoryQuantity { get; set; }
        public int StartLeadDays { get; set; }
        public int StartOrderQuantity { get; set; }
        public List<Distribution> DemandDistribution { get; set; }
        public List<Distribution> LeadDaysDistribution { get; set; }

        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }


    }

}