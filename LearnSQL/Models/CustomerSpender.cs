using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSQL.Models
{
    public class CustomerSpender

        //Customer.CustomerId, Customer.FirstName, Customer.LastName, SUM(Invoice.Total)
    {
        public CustomerSpender(int customerId, string firstName, string lastName, double sumInvoice)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            SumInvoice = sumInvoice;

        }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double SumInvoice { get; set; }

    }
}
