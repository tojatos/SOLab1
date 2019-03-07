namespace SOLab1
{
    public static class PidGenerator
    {
        private static int _lastPid = 0;
        public static int GetNext() => ++_lastPid;
    }
}