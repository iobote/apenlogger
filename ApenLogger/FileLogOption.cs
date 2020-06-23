namespace Apen
{
    public class FileLogOption
    {
        public LogFileInterval LogFileInterval {get; set;} = LogFileInterval.Hourly;
        public string FilePath {get; set;} = @".\Logs\";
    }
}