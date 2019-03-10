using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLab1
{
    internal static class Program
    {
        public const int ClockTreshold = 1000000;
        private static readonly Random Random = new Random();
        public static void Main()
        {
            try
            {
                List<Process> processes = GenerateTestingProcesses();
                
                new Fcfs().Simulate(processes);
                //Print(processes.OrderBy(p => p.ArrivalTime).ToList());
                Console.WriteLine($"FCFS average time: {(double)processes.Select(p => p.TurnAroundTime).Sum() / processes.Count}");
                processes.ForEach(p => p.Reset());
                
                new Sjf().Simulate(processes);
                processes.ForEach(p => p.Reset());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private static List<Process> GenerateTestingProcesses()
        {
            int[] executionTimes = {20, 11, 23, 2, 4, 4, 20, 200, 129, 3, 4, 23, 55, 8, 99};
            return executionTimes.Select(t => new Process(PidGenerator.GetNext(), t, Random.Next(1, 1001))).ToList();
        }

        private static void Print(List<Process> processes)
        {
            const string formatString = "|{0,3}|{1,8}|{2,6}|{3,12}|{4,8}|";
            
            Console.WriteLine(formatString, "PID", "Arrival", "Burst", "Turn around", "Waiting");
            processes.ForEach(p => Console.WriteLine(formatString, p.Pid, p.ArrivalTime, p.BurstTime, p.TurnAroundTime, p.WaitingTime));
            
        }
    }
}