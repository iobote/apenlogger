using System;
using System.Diagnostics.Tracing;
using Apen.Extensions;
using Microsoft.Extensions.Logging;

namespace Apen.Entity
{
    public class SystemLog : LogEntry
    {
        public SystemLog()
        {
            
        }
        public SystemLog(LogLevel logLevel, string source, string reference, ActionType actionType, string message, string detail)
        {
            Source = source;
            Reference = reference;
            ActionType = actionType;
            Message = message;
            Detail = detail;
            LogLevel = logLevel;
            Executed = DateTime.Now;
        }
        public LogLevel LogLevel {get; set;}
    }
}