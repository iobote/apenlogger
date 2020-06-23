using Apen.Entity;
using Microsoft.Extensions.Logging;

namespace Apen
{
    public class ApenLoggerConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;
        public int EventId { get; set; } = 0;
        public string SourceName {get; set;}
        public FileLogOption FileLogOption { get; set; }
        public LogRepository LogRepository {get; set;}
        public bool LogWithVersioning { get; set; }
    }
}
