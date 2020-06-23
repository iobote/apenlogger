using System;

namespace Apen.Entity
{
    public abstract class LogEntry
    {
        public int Id { get; set; } //Log Id
        public DateTime Executed { get; set; } // Time of execution
        public string Source {get; set;} // Application Source ID
        public string Reference {get; set;} //Application Reference
        public ActionType ActionType { get; set; } //Action Type = View, Execute, Delete, Create etc
        public string Message { get; set; } //Title or message
        public string Detail { get; set; } //Stack Trace or object detail in JSON
    }
}