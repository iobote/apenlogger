using System;

namespace Apen.Entity
{
    public class AuditLog : LogEntry
    {
        public AuditLog()
        {
            
        }
        public AuditLog(string source, string reference, ActionType actionType, string actor, string message, string detail)
        {
            Source = source;
            Reference = reference;
            ActionType = actionType;
            Message = message;
            Detail = detail;
            Actor = actor;
            Executed = DateTime.Now;
        }
        public string Actor { get; set; }
    }
}