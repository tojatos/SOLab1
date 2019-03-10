using System.Collections.Generic;
using System.Linq;

namespace SOLab1
{
    public class Sjf : IPlanningAlgorithm
    {
        public void Simulate(List<Process> processes)
        {
//            var processesToTake = new List<Process>(processes);
//            var processesQueue = new Queue<Process>();
//            var clock = 0;
//            var totalAwaitingTime = 0;
//            var awaitTimes = new List<int>();
//            while (processes.Any(p => !p.IsDone))
//            {
//                clock++;
//                processesToTake.FindAll(p => p.StartTime == clock).ForEach(processesQueue.Enqueue);
//                while (processesQueue.Any())
//                {
//                    awaitTimes.Add(totalAwaitingTime);
//                    var process = processesQueue.Dequeue();
//
//                    var execTime = process.EstimatedExecutionTime;
//                    totalAwaitingTime += execTime;
//                    process.Execute(execTime);
//                }
//            }
//            return (double)awaitTimes.Sum() / processes.Count;
        }
    }
}