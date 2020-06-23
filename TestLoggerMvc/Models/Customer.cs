using System;
using System.Collections.Generic;
using Apen;

namespace TestLoggerMvc.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Contact Contact { get; set; }
        public Age Age { get; set; }
    }
    public class Contact
    {
        public string Email { get; set; }
        public IList<string> Phone { get; set; }
    }
    public class Age
    {
        public DateTime DOB { get; set; }
        public int Days
        {
            get
            {
                return DOB.Subtract(DateTime.Today).Days;
            }
        }
        public string Month
        {
            get
            {
                return DOB.ToString("MMM");
            }
        }
    }
    public class Payment : Auditable
    {
        public decimal Amount { get; set; }
    }
}