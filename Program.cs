using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLab1
{
    internal static class Program
    {
        public const int ClockTreshold = 1000000;
        private const int RoundRobinTimeSlice = 3;
        private const int TestSeries = 50;
        private static readonly Random Random = new Random();
        public static void Main()
        {
            var fcfsTimes = new List<double>();
            var sjfNonPreemptiveTimes = new List<double>();
            var sjfPreemptiveTimes = new List<double>();
            var roundRobinTimes = new List<double>();
            try
            {
                var fcfs = new Fcfs();
                var sjfNonPreemptive = new SjfNonPreemptive();
                var sjfPreemptive = new SjfPreemptive();
                var roundRobin = new RoundRobin(RoundRobinTimeSlice);
                for (int i = 0; i < TestSeries; ++i)
                {
                    List<Process> processes = GenerateTestingProcesses();
                    
                    fcfs.Simulate(processes);
                    fcfsTimes.Add(GetAverageTurnAroundTime(processes));
                    Reset(processes);
                    
                    sjfNonPreemptive.Simulate(processes);
                    sjfNonPreemptiveTimes.Add(GetAverageTurnAroundTime(processes));
                    Reset(processes);
                    
                    sjfPreemptive.Simulate(processes);
                    sjfPreemptiveTimes.Add(GetAverageTurnAroundTime(processes));
                    Reset(processes);
                    
                    roundRobin.Simulate(processes);
                    roundRobinTimes.Add(GetAverageTurnAroundTime(processes));
                    Reset(processes);
                }
                
                Console.WriteLine($"FCFS average time: {fcfsTimes.Average()}");
                Console.WriteLine($"SJF Non-preemptive average time: {sjfNonPreemptiveTimes.Average()}");
                Console.WriteLine($"SJF Preemptive average time: {sjfPreemptiveTimes.Average()}");
                Console.WriteLine($"Round Robin average time: {roundRobinTimes.Average()}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private static double GetAverageTurnAroundTime(List<Process> processes)
            => (double) processes.Select(p => p.TurnAroundTime).Sum() / processes.Count;

        private static List<Process> GenerateTestingProcesses()
        {
            int[] executionTimes = {20, 11, 23, 2, 4, 4, 20, 200, 129, 3, 4, 23, 55, 8, 99};
            return executionTimes.Select(t => new Process(PidGenerator.GetNext(), t, Random.Next(1, 1001))).ToList();
        }

        private static void Reset(List<Process> processes) => processes.ForEach(p => p.Reset());
        private static void Print(List<Process> processes)
        {
            const string formatString = "|{0,3}|{1,8}|{2,6}|{3,12}|{4,8}|";
            
            Console.WriteLine(formatString, "PID", "Arrival", "Burst", "Turn around", "Waiting");
            processes.ForEach(p => Console.WriteLine(formatString, p.Pid, p.ArrivalTime, p.BurstTime, p.TurnAroundTime, p.WaitingTime));
            
        }
    }
}