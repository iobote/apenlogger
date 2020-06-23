using System;
using System.Collections.Generic;
using System.Diagnostics;
using Apen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestLoggerMvc.Models;

namespace TestLoggerMvc.Controllers
{
    public class HomeController : Controller
    {
        // private readonly LogManager _logger;
        // private readonly AuditManager _auditor;
        private readonly EasyLogger _logger;
        private readonly EasyAuditor _auditor;

        public HomeController(LoggerDbContext logContext)
        {
            _logger = new EasyLogger(nameof(HomeController), logContext);
            _auditor = new EasyAuditor(nameof(HomeController), logContext);
        }

        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                _auditor.AuditEvent("Index", null, ActionType.View, HttpContext.User.Identity.Name, "View Page", null);
            }

            _logger.LogInformation("Index", null, ActionType.View, "View Page", null);
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            try
            {
                Customer customer = new Customer()
                {
                    FirstName = "Isaac",
                    LastName = "Obote",
                    Age = new Age()
                    {
                        DOB = DateTime.Today
                    },
                    Contact = new Contact()
                    {
                        Email = "Isaac@email.com",
                        Phone = new List<string>() { "256(772)1234756", "256(780)1209399" }
                    }
                };

                _auditor.AuditEvent("Privacy", null, ActionType.Update, HttpContext.User.Identity.Name, "Updated Customer", customer);
                _logger.LogInformation("Privacy", null, ActionType.Update, $"Updated Customer {customer.FirstName}", null);

                Payment pay = new Payment()
                {
                    Amount = new Random().Next(10000, 50000)
                };
                _auditor.AuditEvent<Payment>("Privacy", null, ActionType.Create, HttpContext.User.Identity.Name, $"Created Transaction {pay.Amount}", pay);
                _logger.LogInformation("Privacy", null, ActionType.Create, "Created Transaction Succefully", null);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("Privacy", "", ActionType.Execute, nameof(ActionType.View), ex);
            }


            return View();
}

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
public IActionResult Error()
{
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
    }
}
