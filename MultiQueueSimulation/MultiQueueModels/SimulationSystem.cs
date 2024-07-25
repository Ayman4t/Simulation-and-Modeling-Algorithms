using System;
using System.Collections.Generic;



namespace MultiQueueModels
{
    public class SimulationSystem
    {
        public SimulationSystem()
        {

            this.Servers = new List<Server>();
            this.InterarrivalDistribution = new List<TimeDistribution>();
            this.PerformanceMeasures = new PerformanceMeasures();
            this.SimulationTable = new List<SimulationCase>();
        }
        public int selection(SimulationSystem system, SimulationCase simulationCase)
        {
            int contaner = -1;
            Home home = new Home();
            switch (system.SelectionMethod)
            {
                case Enums.SelectionMethod.Random:
                    contaner =(int) home.Random_Server(system, simulationCase);
                    break;
                case Enums.SelectionMethod.HighestPriority:
                    contaner = home.Priority_Server(system, simulationCase);
                    break;

            }
            return contaner;
        }
        public void Run_Simulation(SimulationSystem system, String Path)
        {

            //sending the test case location to the system
            String test_Path = Path;
            ReadDataFromFile reader = new ReadDataFromFile();
            reader.read_test_case_data(system, test_Path);
            Random rnd = new Random(); // to get any random value --> random service , random arrival time
            Home home = new Home();
            int selectedServerNumber = -1;
            system.queueSeconds = new Dictionary<int, List<int>>();
            system.InterarrivalDistribution = home.CommulativeProbability(system.InterarrivalDistribution);
            int ser = system.NumberOfServers;
            for (int i = 0; i <ser ; i++)
            {
                system.Servers[i].TimeDistribution = home.CommulativeProbability(system.Servers[i].TimeDistribution);
            }

            
          
            if (system.StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers)
            {
                for (int i = 0; i < system.StoppingNumber; i++)
                {
                    SimulationCase simulationCase = new SimulationCase();
                    // Set customer ID.
                    simulationCase.CustomerNumber = i + 1;

                    if (i == 0)
                    {
                        // Generate Random Service time number.
                        simulationCase.RandomService = rnd.Next(1, 100);
                        simulationCase.RandomInterArrival = 1;
                        simulationCase.InterArrival = 0;
                        simulationCase.ArrivalTime = 0;

                        // check on server  method --> random or high priority
                        selectedServerNumber = selection(system, simulationCase);

                        simulationCase.AssignedServer = system.Servers[selectedServerNumber - 1];
                        simulationCase.AssignedServer.servedCustomers.Add(simulationCase.CustomerNumber);
                        // check Interarrival Distribution table to get time between arrival colomn
                        simulationCase.ServiceTime = home.Random_Arrival(table: simulationCase.AssignedServer.TimeDistribution, randomValue: simulationCase.RandomService);
                        simulationCase.AssignedServer.FinishTime = simulationCase.ArrivalTime + simulationCase.ServiceTime;
                        simulationCase.AssignedServer.TotalWorkingTime += simulationCase.ServiceTime;
                        simulationCase.TimeInQueue = 0; // first service
                        simulationCase.StartTime = 0;
                        simulationCase.EndTime = simulationCase.ArrivalTime + simulationCase.ServiceTime;
                        system.SimulationTable.Add(simulationCase);  // put this raw in  output table 
                    }
                    else
                    {
                        // Generate Random interarival number.
                         simulationCase.RandomInterArrival = rnd.Next(1, 100);
                        // Get Interarrival time from generated random number.
                        simulationCase.InterArrival = home.Random_Arrival(table: system.InterarrivalDistribution, simulationCase.RandomInterArrival);
                        // set arrival time. 
                        simulationCase.ArrivalTime = system.SimulationTable[i - 1].ArrivalTime + simulationCase.InterArrival;
                        // Generate Random Service time number.
                        simulationCase.RandomService = rnd.Next(1, 100);
                        // check on server method --> random or high priority

                        selectedServerNumber = selection(system, simulationCase);
                        if (selectedServerNumber != -1)
                        {
                            simulationCase.AssignedServer = system.Servers[selectedServerNumber - 1];
                            simulationCase.AssignedServer.servedCustomers.Add(simulationCase.CustomerNumber);
                            simulationCase.ServiceTime = home.Random_Arrival(table: simulationCase.AssignedServer.TimeDistribution, randomValue: simulationCase.RandomService);
                            simulationCase.AssignedServer.FinishTime = simulationCase.ArrivalTime + simulationCase.ServiceTime;
                            simulationCase.AssignedServer.TotalWorkingTime += simulationCase.ServiceTime;
                            simulationCase.TimeInQueue = 0;
                            simulationCase.StartTime = simulationCase.ArrivalTime;
                            simulationCase.EndTime = simulationCase.ArrivalTime + simulationCase.ServiceTime;
                        }
                        else
                        {
                            selectedServerNumber = home.FirstAvailableServer(system, simulationCase);
                            int delay = system.Servers[selectedServerNumber - 1].FinishTime - simulationCase.ArrivalTime;
                            simulationCase.TimeInQueue = delay;
                            for (int j = 0; j < simulationCase.TimeInQueue; j++)
                            {
                                if (system.queueSeconds.ContainsKey(simulationCase.ArrivalTime + j))
                                {
                                    system.queueSeconds[simulationCase.ArrivalTime + j].Add(simulationCase.CustomerNumber);
                                }
                                else
                                {
                                    List<int> customerNumber = new List<int>();
                                    customerNumber.Add(simulationCase.CustomerNumber);
                                    system.queueSeconds.Add(simulationCase.ArrivalTime + j, customerNumber);
                                }
                            }
                            simulationCase.AssignedServer = system.Servers[selectedServerNumber - 1];
                            simulationCase.AssignedServer.servedCustomers.Add(simulationCase.CustomerNumber);
                            simulationCase.ServiceTime = home.Random_Arrival(table: simulationCase.AssignedServer.TimeDistribution, randomValue: simulationCase.RandomService);
                            simulationCase.AssignedServer.TotalWorkingTime += simulationCase.ServiceTime;
                            simulationCase.AssignedServer.FinishTime = simulationCase.AssignedServer.FinishTime + simulationCase.ServiceTime;
                            simulationCase.StartTime = simulationCase.ArrivalTime + simulationCase.TimeInQueue;
                            simulationCase.EndTime = simulationCase.StartTime + simulationCase.ServiceTime;
                        }
                        system.SimulationTable.Add(simulationCase);
                    }
                }
            }

            else if (system.StoppingCriteria == Enums.StoppingCriteria.SimulationEndTime)
            {

                int i = 0;
                while (true)
                {
                    SimulationCase simulationCase = new SimulationCase();
                    // Set customer ID.
                    simulationCase.CustomerNumber = i + 1;

                    if (i == 0)
                    {
                        simulationCase.RandomInterArrival = 1;
                        simulationCase.InterArrival = 0;
                        simulationCase.ArrivalTime = 0;
                        if (simulationCase.ArrivalTime >= system.StoppingNumber)
                        {
                            break;
                        }
                        // Generate Random Service time number.
                        simulationCase.RandomService = rnd.Next(1, 100);
                        // check on server selection
                        int chosenServerNumber = -1;
                        chosenServerNumber = selection(system, simulationCase);
                        simulationCase.AssignedServer = system.Servers[chosenServerNumber - 1];

                        simulationCase.AssignedServer.servedCustomers.Add(simulationCase.CustomerNumber);
                        simulationCase.ServiceTime = home.Random_Arrival(table: simulationCase.AssignedServer.TimeDistribution, randomValue: simulationCase.RandomService);
                        simulationCase.AssignedServer.FinishTime = simulationCase.ArrivalTime + simulationCase.ServiceTime;
                        simulationCase.AssignedServer.TotalWorkingTime += simulationCase.ServiceTime;
                        simulationCase.TimeInQueue = 0;
                        simulationCase.StartTime = 0;
                        simulationCase.EndTime = simulationCase.ArrivalTime + simulationCase.ServiceTime;
                        system.SimulationTable.Add(simulationCase);
                    }
                    else
                    {
                        // Generate Random interarival number.
                        simulationCase.RandomInterArrival = rnd.Next(1, 100);
                        // Get Interarrival time from generated random number.
                        simulationCase.InterArrival = home.Random_Arrival(table: system.InterarrivalDistribution, simulationCase.RandomInterArrival);
                        // set arrival time.
                        simulationCase.ArrivalTime = system.SimulationTable[i - 1].ArrivalTime + simulationCase.InterArrival;
                        if (simulationCase.ArrivalTime >= system.StoppingNumber)
                        {
                            break;
                        }
                        // Generate Random Service time number.
                        simulationCase.RandomService = rnd.Next(1, 100);
                        // check on server selection
                        int chosenServerNumber = -1;
                        chosenServerNumber = selection(system, simulationCase);
                        if (chosenServerNumber != -1)
                        {
                            simulationCase.AssignedServer = system.Servers[chosenServerNumber - 1];
                            simulationCase.AssignedServer.servedCustomers.Add(simulationCase.CustomerNumber);
                            simulationCase.ServiceTime = home.Random_Arrival(table: simulationCase.AssignedServer.TimeDistribution, randomValue: simulationCase.RandomService);
                            simulationCase.AssignedServer.FinishTime = simulationCase.ArrivalTime + simulationCase.ServiceTime;
                            simulationCase.AssignedServer.TotalWorkingTime += simulationCase.ServiceTime;
                            simulationCase.TimeInQueue = 0;
                            simulationCase.StartTime = simulationCase.ArrivalTime;
                            simulationCase.EndTime = simulationCase.ArrivalTime + simulationCase.ServiceTime;
                        }
                        else
                        {
                            chosenServerNumber = home.FirstAvailableServer(system, simulationCase);
                            int delay = system.Servers[chosenServerNumber - 1].FinishTime - simulationCase.ArrivalTime;
                            simulationCase.TimeInQueue = delay;
                            for (int j = 0; j < simulationCase.TimeInQueue; j++)
                            {
                                if (system.queueSeconds.ContainsKey(simulationCase.ArrivalTime + j))
                                {
                                    system.queueSeconds[simulationCase.ArrivalTime + j].Add(simulationCase.CustomerNumber);
                                }
                                else
                                {
                                    List<int> customerNumber = new List<int>();
                                    customerNumber.Add(simulationCase.CustomerNumber);
                                    system.queueSeconds.Add(simulationCase.ArrivalTime + j, customerNumber);
                                }
                            }
                            simulationCase.AssignedServer = system.Servers[chosenServerNumber - 1];
                            simulationCase.AssignedServer.servedCustomers.Add(simulationCase.CustomerNumber);
                            simulationCase.ServiceTime = home.Random_Arrival(table: simulationCase.AssignedServer.TimeDistribution, randomValue: simulationCase.RandomService);
                            simulationCase.AssignedServer.TotalWorkingTime += simulationCase.ServiceTime;
                            simulationCase.AssignedServer.FinishTime = simulationCase.AssignedServer.FinishTime + simulationCase.ServiceTime;
                            simulationCase.StartTime = simulationCase.ArrivalTime + simulationCase.TimeInQueue;
                            simulationCase.EndTime = simulationCase.StartTime + simulationCase.ServiceTime;
                        }
                        system.SimulationTable.Add(simulationCase);
                    }

                    i++;

                }
            }

            int maxQueueLen = 0;
            foreach (KeyValuePair<int, List<int>> entry in system.queueSeconds)
            {
                if (entry.Value.Count > maxQueueLen)
                {
                    maxQueueLen = entry.Value.Count;
                }

            }
       
            system.PerformanceMeasures.MaxQueueLength = maxQueueLen;
            system.PerformanceMeasures.AverageWaitingTime = home.Avarge_Waiting_Time(system);
            system.PerformanceMeasures.WaitingProbability = home.Probability_waiting(system);
           

        }

        public void ServerPerformanceMeasures(SimulationSystem system)
        {

            decimal totalWorkingTime;
            decimal total_waiting_time;
            // calculating total service time for each server and total runtime for the simulation
            for (int i = 0; i < system.SimulationTable.Count; i++)
            {
                // total runtime for system = exact time which last server end END TIME 
                if (system.SimulationTable[i].EndTime >= total_runtime)
                    total_runtime = system.SimulationTable[i].EndTime;
            }

            for (int i = 0; i < system.Servers.Count; i++)
            {
                //calculating idle time for each server and calutaing the probabilitis
                 totalWorkingTime = system.Servers[i].TotalWorkingTime;
                 total_waiting_time = total_runtime - totalWorkingTime;

                //idle probability
                system.Servers[i].IdleProbability = total_waiting_time / total_runtime;
                //utilization probability
                system.Servers[i].Utilization = system.Servers[i].TotalWorkingTime / total_runtime;
               
                decimal AverageServiceTime = 0;
                if (system.Servers[i].servedCustomers.Count > 0)
                {
                    AverageServiceTime = totalWorkingTime / system.Servers[i].servedCustomers.Count;
                }
                //average service time
                system.Servers[i].AverageServiceTime = AverageServiceTime;
            }

        }

        ///////////// INPUTS ///////////// 
        public int NumberOfServers { get; set; }
        public decimal total_runtime { get; set; }
        public int StoppingNumber { get; set; }
        public List<Server> Servers { get; set; }
        public List<TimeDistribution> InterarrivalDistribution { get; set; }
        public Enums.StoppingCriteria StoppingCriteria { get; set; }
        public Enums.SelectionMethod SelectionMethod { get; set; }

        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }
        public Dictionary<int, List<int>> queueSeconds { get; set; }

    }
}