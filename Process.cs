namespace SOLab1
{
    public class Process
    {
        public readonly int Pid;
        public readonly int ArrivalTime; //Time at which the process arrives in the ready queue
        public readonly int BurstTime;  //Time required by a process for CPU execution
        
        public int CompletionTime { get; private set; } //Time at which process completes its execution
        public int ExecTime { get; private set; } //Execution time
        
        public int TurnAroundTime => CompletionTime - ArrivalTime;
        public int WaitingTime => TurnAroundTime - BurstTime;
        public int RemaingExecutionTime => BurstTime - ExecTime;
        public bool IsCompleted => CompletionTime != 0;

        public Process(int pid, int burstTime, int arrivalTime)
        {
            Pid = pid;
            BurstTime = burstTime;
            ArrivalTime = arrivalTime;
        }

//        public void Execute(int time) => ExecTime += time;
        public void Execute() => ++ExecTime;
        public void Complete(int time) => CompletionTime = time;

        public void Reset()
        {
            ExecTime = 0;
            CompletionTime = 0;
        }

//        public override string ToString() => $"PID: {Pid}\tEstimated exec time: {EstimatedExecutionTime}\tIsDone: {IsDone}";
    }
}