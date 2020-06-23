using System;
using System.Globalization;
using System.IO;
using Apen;
using Apen.Entity;
using Apen.Extensions;
using Microsoft.Extensions.Logging;

namespace Apen
{
    public class EasyLogger
    {
        private CultureInfo _culture { get; set; }
        private readonly LoggerDbContext _context;
        private readonly ApenLoggerConfiguration _config;
        public EasyLogger(ApenLoggerConfiguration config, LoggerDbContext context)
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
        public EasyLogger(string source, LoggerDbContext context)
        {
            _config = new ApenLoggerConfiguration
            {
                SourceName = source,
                LogRepository = LogRepository.Database
            };
            _culture = new CultureInfo("en-US");
            _context = context;
        }
        private void SaveToDatabase(LogLevel logLevel, string source, string reference, ActionType actionType, string message, object obj)
        {
            SystemLog newEntry = new SystemLog(logLevel, source, reference, actionType, message, obj.ToJsonString());
            _context.SystemLogs.Add(newEntry);
            _context.SaveChanges();
            return;
        }
        private void AppendLogFile(LogLevel logLevel, string source, string reference, ActionType actionType, string message, object obj)
        {
            string path = Path.Combine(_config.FileLogOption.FilePath, $"{_config.SourceName}_{GetFileNameDate(_config.FileLogOption.LogFileInterval, DateTime.Now)}.log");
            string line = $"{DateTime.Now}: {Enum.GetName(typeof(LogLevel), logLevel)} : {source} : {Enum.GetName(typeof(ActionType), actionType)} : {message} : {reference} : {obj.ToJsonString()}\r\n";
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
        private void AddToWindowsEvents(LogLevel logLevel, string source, string reference, ActionType actionType, string message, object obj)
        {
            throw new NotImplementedException();
        }
        private void PrintInConsole(LogLevel logLevel, string source, string reference, ActionType actionType, string message, object obj)
        {
            string jsondetail = obj.ToJsonString();
            string line = $"{DateTime.Now}: {Enum.GetName(typeof(LogLevel), logLevel)} : {source} : {Enum.GetName(typeof(ActionType), actionType)} : {message} : {reference} : {jsondetail}";
            Console.WriteLine(line);
        }

        private void LogEntry(LogLevel logLevel, string source, string reference, ActionType actionType, string message, object obj)
        {
            source = string.IsNullOrEmpty(source) ? _config.SourceName : source;
            switch (_config.LogRepository)
            {
                case LogRepository.Database:
                    SaveToDatabase(logLevel, source, reference, actionType, message, obj);
                    return;
                case LogRepository.WindowsEvents:
                    AddToWindowsEvents(logLevel, source, reference, actionType, message, obj);
                    return;
                case LogRepository.Console:
                    PrintInConsole(logLevel, source, reference, actionType, message, obj);
                    return;
                case LogRepository.File:
                    AppendLogFile(logLevel, source, reference, actionType, message, obj);
                    return;
                default:
                    return;
            }
        }
        public void LogInformation(string source, string reference, ActionType actionType, string message, object obj)
        {
            LogEntry(LogLevel.Information, source, reference, actionType, message, obj);
            return;
        }
        public void LogError(string source, string reference, ActionType actionType, string message, object obj)
        {
            LogEntry(LogLevel.Error, source, reference, actionType, message, obj);
            return;
        }
        public void LogDebug(string source, string reference, ActionType actionType, string message, object obj)
        {
            LogEntry(LogLevel.Debug, source, reference, actionType, message, obj);
            return;
        }
        public void LogWarning(string source, string reference, ActionType actionType, string message, object obj)
        {
            LogEntry(LogLevel.Warning, source, reference, actionType, message, obj);
            return;
        }
        public void LogTrace(string source, string reference, ActionType actionType, string message, object obj)
        {
            LogEntry(LogLevel.Trace, source, reference, actionType, message, obj);
            return;
        }
        public void LogCritical(string source, string reference, ActionType actionType, string message, object obj)
        {
            LogEntry(LogLevel.Critical, source, reference, actionType, message, obj);
            return;
        }
    }
}