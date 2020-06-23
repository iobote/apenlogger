using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.Logging;
using Apen;

namespace TestLoggerCmd
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new LoggerContextFactory().CreateDbContext(null);


            EasyLogger logger = new EasyLogger(
                new ApenLoggerConfiguration()
                {
                    LogRepository = LogRepository.Database,
                    FileLogOption = new FileLogOption()
                    {
                        LogFileInterval = LogFileInterval.Hourly,
                        FilePath = @".\Logs\"
                    }
                }, context
            );
            EasyAuditor auditor = new EasyAuditor(
                new ApenLoggerConfiguration()
                {
                    LogRepository = LogRepository.Database,
                    FileLogOption = new FileLogOption()
                    {
                        LogFileInterval = LogFileInterval.Hourly,
                        FilePath = @".\Logs\"
                    }
                }, context
            );

            logger.LogInformation("", "", ActionType.Approve, "StartUp", null);
            for (int i = 0; i < 99; i++)
            {
                var d = i <= 30 ? (i + 1) : (i % 30 == 0 ? 1 : (i % 30));
                var x = new WeatherForecastWithPOCOs()
                {
                    Date = DateTime.Now.AddDays(i),
                    TemperatureCelsius = i,
                    Summary = $"Hot",
                    DatesAvailable = new List<DateTimeOffset>()
                        {
                            DateTime.Parse($"2019-08-{d:00}T00:00:00-07:00"),
                            DateTime.Parse($"2019-08-{d:00}T00:00:00-07:00")
                        },
                    SummaryWords = new List<string> { "Cool", "Windy", "Humid" }.ToArray()
                };
                logger.LogInformation(nameof(Program), i.ToString(), ActionType.Execute, "StartUp", x);
                if (i % 2 == 0)
                {
                    logger.LogInformation(nameof(Program), i.ToString(), ActionType.Create, $"Looping Values ({i})", x);
                    auditor.AuditEvent(nameof(Program), i.ToString(), ActionType.Create, "creator@even.com", "Create", x);
                }
                if (i % 3 == 0)
                {
                    logger.LogCritical(nameof(Program), i.ToString(), ActionType.Update, $"Looping Values ({i})", x);
                    auditor.AuditEvent(nameof(Program), i.ToString(), ActionType.Update, "updater@even.com", "Updated", x);
                }
                if (i % 5 == 0)
                {
                    logger.LogError(nameof(Program), i.ToString(), ActionType.Approve, $"Looping Values ({i})", x);
                    auditor.AuditEvent(nameof(Program), i.ToString(), ActionType.Approve, "approver@even.com", "Approve", x);
                }
                if (i % 7 == 0)
                {
                    logger.LogWarning(nameof(Program), i.ToString(), ActionType.Delete, $"Looping Values ({i})", x);
                    auditor.AuditEvent(nameof(Program), i.ToString(), ActionType.Delete, "delete@even.com", "Deleted", x);
                }
            }

            var logs = context.SystemLogs.ToList();
            foreach (var item in logs)
            {
                Console.WriteLine($"{item.Id} | {item.Executed} | {item.LogLevel} | {item.Source} | {item.ActionType} | {item.Action} | {item.Reference} | {item.Detail}");
            }

            var audittrail = context.AuditLogs.ToList();
            foreach (var item in audittrail)
            {
                Console.WriteLine($"{item.Id} | {item.Executed} | {item.Actor} | {item.Source} | {item.ActionType} | {item.Action} | {item.Reference} | {item.Detail}");
            }
        }
    }
    public class LoggerContextFactory : IDesignTimeDbContextFactory<LoggerDbContext>
    {
        public LoggerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LoggerDbContext>();
            optionsBuilder.UseInMemoryDatabase("Logger"); 
            //optionsBuilder.UseSqlite("Data Source=blog.db");

            return new LoggerDbContext(optionsBuilder.Options);
        }
    }
    public class WeatherForecastWithPOCOs
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
        public string SummaryField;
        public List<DateTimeOffset> DatesAvailable { get; set; }
        public Dictionary<string, string> TemperatureRanges { get; set; }
        public string[] SummaryWords { get; set; }
    }
}