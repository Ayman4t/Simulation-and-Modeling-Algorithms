using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels
{
    public class simulate
    {
        public void run(SimulationSystem system, String Path)
        {
            ReadDataFromFile reader = new ReadDataFromFile();

            reader.read_test_case_data(system, Path);

            int daysUntilOrderArrives = system.StartLeadDays;
            int dayWithinCycle = 1;
            int shortage = 0;
            int cycle = 1;
            var rand = new Random();

            for (int i = 0; i < system.NumberOfDays; i++)

            {
                SimulationCase outtable = new SimulationCase();
                outtable.Day = i + 1;
                outtable.Cycle = cycle;
                outtable.DayWithinCycle = dayWithinCycle;
                outtable.BeginningInventory = system.StartInventoryQuantity;
                outtable.RandomDemand = rand.Next(1, 100);


                system.DemandDistribution = reader.Commulative(system.DemandDistribution);
                outtable.Demand = system.find_value_of_random(system.DemandDistribution, outtable.RandomDemand);
                // normal days



                if (outtable.BeginningInventory >outtable.Demand)
                {

                    outtable.EndingInventory = outtable.BeginningInventory - outtable.Demand;
                    
                }
                else
                {
                    outtable.EndingInventory = 0;
                    outtable.ShortageQuantity = outtable.Demand - outtable.BeginningInventory;
                    shortage += outtable.ShortageQuantity;
                }


                if (outtable.EndingInventory > shortage)
                {
                    outtable.EndingInventory -= shortage;
                    shortage = 0;
                }
                else
                {

                    shortage = shortage - outtable.EndingInventory;
                    outtable.EndingInventory = 0;
                }



                outtable.ShortageQuantity = shortage;
                system.StartInventoryQuantity = outtable.EndingInventory;


                if (daysUntilOrderArrives != 0)
                {
                    daysUntilOrderArrives--;


                    if (daysUntilOrderArrives == 0)
                    {
                       system. StartInventoryQuantity +=system. StartOrderQuantity;
                        system.StartOrderQuantity = 0;
                    }
                }
               

                ////// special day /////
                if (system.ReviewPeriod==outtable.DayWithinCycle)
                {
                    outtable.OrderQuantity = outtable.ShortageQuantity + system. OrderUpTo - outtable.EndingInventory;
                    outtable.RandomLeadDays = rand.Next(1, 100);
                    system.LeadDaysDistribution = reader.Commulative(system.LeadDaysDistribution);
                    outtable.LeadDays = system.find_value_of_random(system.LeadDaysDistribution, outtable.RandomLeadDays);

                    system.StartOrderQuantity = outtable.OrderQuantity;
                    dayWithinCycle = 0;

                    daysUntilOrderArrives = outtable.LeadDays;
                    cycle++;
                }


                dayWithinCycle++;

                outtable.DaysUntilOrderArrives = daysUntilOrderArrives;
                system. SimulationTable.Add(outtable);


               system. PerformanceMeasures.EndingInventoryAverage += outtable.EndingInventory;
               system. PerformanceMeasures.ShortageQuantityAverage += outtable.ShortageQuantity;

            }
        }
    }
}
