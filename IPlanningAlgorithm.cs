using System.Collections.Generic;

namespace SOLab1
{
    public interface IPlanningAlgorithm
    {
        /// <summary>
        /// Returns average execution time
        /// </summary>
        void Simulate(List<Process> processes);
    }
}