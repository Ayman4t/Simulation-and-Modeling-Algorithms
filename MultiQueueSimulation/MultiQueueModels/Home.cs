using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class Home
    {
        public List<TimeDistribution>CommulativeProbability(List<TimeDistribution> Interarrival_Distribution_table)
        {
            for (int i = 0; i < Interarrival_Distribution_table.Count; i++)
            {
                if (i == 0)
                {
                    Interarrival_Distribution_table[i].CummProbability = Interarrival_Distribution_table[i].Probability;
                    Interarrival_Distribution_table[i].MinRange = 0;
                    Interarrival_Distribution_table[i].MaxRange = (int)(Interarrival_Distribution_table[i].CummProbability * 100);
                }
                else
                {
                    Interarrival_Distribution_table[i].CummProbability = Interarrival_Distribution_table[i - 1].CummProbability + Interarrival_Distribution_table[i].Probability;
                    Interarrival_Distribution_table[i].MinRange = (int)(Interarrival_Distribution_table[i - 1].MaxRange) + 1;
                    Interarrival_Distribution_table[i].MaxRange = (int)(Interarrival_Distribution_table[i].CummProbability * 100);
                }
            }
            return Interarrival_Distribution_table;
        }
        public int Random_Arrival(List<TimeDistribution> table, int randomValue)
        {
            int time_arrive = 0;
            int counter = table.Count;
            for (int i = 0; i < counter; i++)
            {
                if (randomValue >= table[i].MinRange && randomValue <= table[i].MaxRange)
                {
                    time_arrive = table[i].Time;
                    break;
                }
            }
            return time_arrive;
        }
        public decimal Random_Server(SimulationSystem SS, SimulationCase SC)
        {
            int server_Id = 0;
            List<Server> available = new List<Server>();
           
            for (int i = 0; i < SS.Servers.Count; i++)
            {

                if (SC.ArrivalTime >= SS.Servers[i].FinishTime)
                {
                    available.Add(SS.Servers[i]);
                }
            }
            if (available.Count != 0)
            {
                Random rnd = new Random();
               
                server_Id = available[rnd.Next(0, available.Count-1)].ID;

            }
            
            return server_Id;
        }
        public int Priority_Server(SimulationSystem SS, SimulationCase SC)
        {
            int server_Id = -1;
            List<Server> available = new List<Server>();
            // get all available servers;
            for (int i = 0; i < SS.Servers.Count; i++)
            {

                if (SC.ArrivalTime >= SS.Servers[i].FinishTime)
                {
                    available.Add(SS.Servers[i]);
                }
            }
            if (available.Count != 0)
            {
                server_Id = available[0].ID;
            }
            return server_Id;
        }
       
        public int FirstAvailableServer(SimulationSystem SS, SimulationCase SC)
        {
            int nextTime = 10000000;
            int server_Id = -1;
            for (int i = 0; i < SS.NumberOfServers; i++)
            {
                if (SS.Servers[i].FinishTime < nextTime)
                {
                    nextTime = SS.Servers[i].FinishTime;
                    server_Id = SS.Servers[i].ID;
                }
            }
            return server_Id;
        }
        public decimal Avarge_Waiting_Time(SimulationSystem SS)
        {
            decimal totalTimeInQueue = 0;
            decimal averageWaitingTime = 0;

            for (int i = 0; i < SS.SimulationTable.Count; i++)
                foreach (SimulationCase SC in SS.SimulationTable)
                {
                    totalTimeInQueue += SC.TimeInQueue;
                }
            if (SS.SimulationTable.Count > 0)
                averageWaitingTime = totalTimeInQueue / SS.SimulationTable.Count;
            return averageWaitingTime /100;
        }
        
        public decimal Probability_waiting(SimulationSystem SS)
        {
            decimal NO_customer_waited = 0;
            decimal probability_waiting = 0;
            foreach (SimulationCase Sc in SS.SimulationTable)
            {
                if (Sc.TimeInQueue > 0)
                {
                    NO_customer_waited++;
                }
            }
            
            probability_waiting = NO_customer_waited / SS.SimulationTable.Count;
            return probability_waiting;
        }


       
    }
}
