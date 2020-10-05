namespace SageOneApi.Client.Utils
{
    public class ProgressUpdate
    {
        public ProgressUpdate(string message)
        {
            Message = message;
        }

        public ProgressUpdate(string message, int progress, int totalCount, string entity) : this(message)
        {
            Progress = progress;
            TotalCount = totalCount;
            Entity = entity;
        }

        public string Message { get; }
        public int Progress { get; }
        public int TotalCount { get; }
        public string Entity { get; }
    }
}
