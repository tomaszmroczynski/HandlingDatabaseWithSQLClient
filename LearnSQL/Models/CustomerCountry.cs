using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSQL.Models
{
    /// <summary>
    /// A class used to display country with most customers
    /// </summary>
    public class CustomerCountry
    {
        public CustomerCountry(string countryName, int count  )
        {
            CountryName = countryName;
            Count = count;     
        }
        public string CountryName { get; set; }
        public int Count { get; set; }
        public override string ToString()
        {
            return $"{CountryName} | {Count}";
        }
    }
}
