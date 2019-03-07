using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLab1
{
    public class Fcfs : IPlanningAlgorithm
    {
        public double Simulate(List<Process> processes)
        {
            var processesToTake = new List<Process>(processes);
            var processesQueue = new Queue<Process>();
            int totalAwaitingTime = 0;
            var awaitTimes = new List<int>();
            for (int clock = 0; processes.Any(p => !p.IsDone) && clock < Program.ClockTreshold; ++clock)
            {
                processesToTake.FindAll(p => p.StartTime == clock).ForEach(p =>
                {
                    processesToTake.Remove(p);
                    processesQueue.Enqueue(p);
                });
                while (processesQueue.Any())
                {
                    Process process = processesQueue.Dequeue();
                    awaitTimes.Add(totalAwaitingTime);

                    int execTime = process.EstimatedExecutionTime;
                    totalAwaitingTime += execTime;
                    process.Execute(execTime);
                }
            }
            if(processes.Any(p => !p.IsDone)) throw new Exception("FCFS simulation failed");
            return (double)awaitTimes.Sum() / processes.Count;

        }
    }
}