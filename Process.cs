namespace SOLab1
{
    public class Process
    {
        public readonly int Pid;
        public readonly int EstimatedExecutionTime;
        public readonly int StartTime;
        public int ExecTime { get; private set; } = 0;
        public bool IsDone => ExecTime >= EstimatedExecutionTime;

        public Process(int pid, int estimatedExecutionTime, int startTime)
        {
            Pid = pid;
            EstimatedExecutionTime = estimatedExecutionTime;
            StartTime = startTime;
        }

        public void Execute(int time) => ExecTime += time;

        public void Reset()
        {
            ExecTime = 0;
        }

        public override string ToString() => $"PID: {Pid}\tEstimated exec time: {EstimatedExecutionTime}\tIsDone: {IsDone}";
    }
}