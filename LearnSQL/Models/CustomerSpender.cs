using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSQL.Models
{
    /// <summary>
    /// A class used to display most spending customers
    /// </summary>
    public class CustomerSpender

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
        public override string ToString()
        {
            return $"{CustomerId} | {FirstName} | {LastName} | {SumInvoice} ";
        }

    }
}
