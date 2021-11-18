using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSQL.Models
{
    public class CustomerCountry
    {
        public CustomerCountry(string name, int customerId)
        {
            Name = name;
            CustomerId = customerId;
        }
        public string Name { get; set; }

        public int CustomerId { get; set; }


    }
}
