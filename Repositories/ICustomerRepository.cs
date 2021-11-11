using LearningSQLClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSQLClient.Repositories
{
    public interface ICustomerRepository
    {
        public Superheroes GetCustomer(string id);

        public List<Superheroes> GetAllCustomers();

        public bool AddNewCustomer(Superheroes customer);

        public bool DeleteCustomer(string id);
   }
}
