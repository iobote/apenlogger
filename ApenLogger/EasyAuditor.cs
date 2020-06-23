using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Apen.Entity;
using Apen.Extensions;

namespace Apen
{
    public class EasyAuditor
    {
        private CultureInfo _culture { get; set; }
        private readonly LoggerDbContext _context;
        private readonly ApenLoggerConfiguration _config;
        public EasyAuditor(ApenLoggerConfiguration config, LoggerDbContext context)
        {
            switch (config.LogRepository)
            {
                case LogRepository.Database:
                    if (context == null)
                        throw new MissingFieldException("Apply the DbContext inorder to be able to use the database logging option.");
                    _context = context;
                    break;
                case LogRepository.WindowsEvents:
                    if (string.IsNullOrEmpty(config.SourceName))
                        throw new MissingFieldException("SourceName cannot be null when Windows Events Logging is selected.");
                    break;
                case LogRepository.File:
                    if (config.FileLogOption == null)
                        config.FileLogOption = new FileLogOption();
                    if (string.IsNullOrEmpty(config.FileLogOption.FilePath))
                        throw new MissingFieldException("FileLogOption cannot be null when File Logging is selected.");
                    if (!Directory.Exists(config.FileLogOption.FilePath))
                        Directory.CreateDirectory(config.FileLogOption.FilePath);
                    break;
                default:
                    break;
            }

            _culture = new CultureInfo("en-US");
            _config = config;
        }
        public EasyAuditor(string source, LoggerDbContext context)
        {
            _config = new ApenLoggerConfiguration
            {
                SourceName = source,
                LogRepository = LogRepository.Database
            };
            _culture = new CultureInfo("en-US");
            _context = context;
        }
        private void SaveToDatabase(string source, string reference, ActionType actionType, string actor, string message, object obj)
        {
            AuditLog newEntry = new AuditLog(source, reference, actionType, actor, message, obj.ToJsonString());
            _context.AuditLogs.Add(newEntry);
            _context.SaveChanges();

            if (obj != null)
                if (obj.GetType().GetProperties().FirstOrDefault(p => "Version".Contains(p.Name)) != null)
                    AddVersion(source, (obj as Auditable).Id, actor, (obj as Auditable).Version, obj.ToJsonString());

            return;
        }
        private int AddVersion(string item, int itemid, string user, int version, string detail)
        {
            ItemVersion itemVersion = new ItemVersion()
            {
                Item = item,
                Date = DateTime.Now,
                Detail = detail,
                ItemId = itemid,
                User = user,
                Version = version
            };
            _context.ItemVersions.Add(itemVersion);
            _context.SaveChanges();
            return itemVersion.Id;
        }
        private void AppendLogFile(string source, string reference, ActionType actionType, string actor, string message, object obj)
        {
            string path = Path.Combine(_config.FileLogOption.FilePath, $"{_config.SourceName}_{GetFileNameDate(_config.FileLogOption.LogFileInterval, DateTime.Now)}.audit.log");
            string line = $"{DateTime.Now}: {source} : {Enum.GetName(typeof(ActionType), actionType)} : {actor} : {message} : {reference} : {obj.ToJsonString()}\r\n";
            File.AppendAllText(path, line);
        }
        private string GetFileNameDate(LogFileInterval interval, DateTime date)
        {
            switch (interval)
            {
                case LogFileInterval.Hourly:
                    return date.ToString("yyyyMMddHH");
                case LogFileInterval.Daily:
                    return date.ToString("yyyyMMdd");
                case LogFileInterval.Weekly:
                    return string.Concat(date.ToString("yyyy"), _culture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFullWeek, DayOfWeek.Sunday));
                case LogFileInterval.Monthly:
                    return date.ToString("yyyyMM");
                default:
                    return date.ToString("yyyyMMddHH");
            }
        }
        private void AddToWindowsEvents(string source, string reference, ActionType actionType, string actor, string message, object obj)
        {
            throw new NotImplementedException();
        }
        private void PrintInConsole(string source, string reference, ActionType actionType, string actor, string message, object obj)
        {
            string line = $"{DateTime.Now}: {source} : {Enum.GetName(typeof(ActionType), actionType)} : {actor} : {message} : {reference} : {obj.ToJsonString()}";
            Console.WriteLine(line);
        }
        private void LogEntry(string source, string reference, ActionType actionType, string actor, string message, object obj)
        {
            source = string.IsNullOrEmpty(source) ? _config.SourceName : source;
            switch (_config.LogRepository)
            {
                case LogRepository.Database:
                    SaveToDatabase(source, reference, actionType, actor, message, obj);
                    return;
                case LogRepository.WindowsEvents:
                    AddToWindowsEvents(source, reference, actionType, actor, message, obj);
                    return;
                case LogRepository.Console:
                    PrintInConsole(source, reference, actionType, actor, message, obj);
                    return;
                case LogRepository.File:
                    AppendLogFile(source, reference, actionType, actor, message, obj);
                    return;
                default:
                    return;
            }
        }
        public void AuditEvent(string source, string reference, ActionType actionType, string actor, string message, object obj)
        {
            LogEntry(source, reference, actionType, actor, message, obj);
            return;
        }
        public void AuditEvent<T>(string source, string reference, ActionType actionType, string actor, string message, T obj)
        {
            LogEntry(typeof(T).Name, reference, actionType, actor, message, obj);
            return;
        }
    }
}