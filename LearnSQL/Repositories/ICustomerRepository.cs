using LearnSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSQL.Repositories
{
    public interface ICustomerRepository
    {
        public Customer GetCustomerById(int id);

        public Customer GetCustomerByName(string name);

        public List<Customer> GetAllCustomers();

        public List<Customer> GetLimitedCustomers(string offset, string limit);

        public bool AddNewCustomer(Customer customer);

        public bool UpdateCustomer(Customer customer);

        public List<CustomerCountry> GetCountOfCustomersByCountry();

        public List<CustomerSpender> GetTopSpenders();

        public List<CustomerGenre> GetMostPopularGenreForChosenCustomer(Customer customer);

    }
}
