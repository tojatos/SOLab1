using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLab1
{
    public class SjfNonPreemptive : IPlanningAlgorithm
    {
        public void Simulate(List<Process> processes)
        {
            var processesToTake = new List<Process>(processes);
            var processesQueue = new Queue<Process>();
            for (int clock = 0; processes.Any(p => !p.IsCompleted) && clock < Program.ClockTreshold; ++clock)
            {
                processesToTake.FindAll(p => p.ArrivalTime == clock).ForEach(p =>
                {
                    processesToTake.Remove(p);
                    processesQueue.Enqueue(p);
                });
                if (!processesQueue.Any()) continue;
                Process process = processesQueue.Peek();
                process.Execute();
                if (process.BurstTime != process.ExecTime) continue;
                process.Complete(clock + 1);
                processesQueue.Dequeue();
                processesQueue = new Queue<Process>(processesQueue.OrderBy(p => p.BurstTime));
            }
            if(processes.Any(p => !p.IsCompleted)) throw new Exception("SJF non-preemtive simulation failed");

        }
    }
}
