using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLab1
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var processes = GenerateTestingProcesses();
            double fcfsAvgTime = new Fcfs().Simulate(processes);
            Console.WriteLine($"FCFS average time: {fcfsAvgTime}");
            //double sjfAvgTime = new Sjf().Simulate(processes);
            //Console.WriteLine($"SJF average time: {sjfAvgTime}");
            Console.ReadKey();
        }

        private static List<Process> GenerateTestingProcesses()
        {
            int[] executionTimes = {20, 11, 23, 2, 4, 4, 20, 200, 129, 3, 4, 23, 55, 8, 99};
            return executionTimes.Select(t => new Process(PidGenerator.GetNext(), t, new Random().Next(1, 1001))).ToList();
        }
    }
}