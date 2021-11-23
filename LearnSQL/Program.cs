
using LearnSQL.Models;
using LearnSQL.Repositories;
using System;
using System.Collections.Generic;

namespace LearnSQL
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var customers = new CustomerRepository().GetAllCustomers();
            DisplayCustomers(customers);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Chose id of customer to display");
            Console.WriteLine("---------------------------------");
            string choice = Console.ReadLine();
            var customer = new CustomerRepository().GetCustomerById(Int32.Parse(choice));
            DisplayCustomer(customer);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Chose first name of customer to display");
            Console.WriteLine("---------------------------------");
            choice = Console.ReadLine();
            customer = new CustomerRepository().GetCustomerByName(choice);
            DisplayCustomer(customer);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Chose from which CustomerId to start display");
            Console.WriteLine("---------------------------------");
            string offset = Console.ReadLine();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Chose how many Customers to  display");
            Console.WriteLine("---------------------------------");
            string limit = Console.ReadLine();
            customers = new CustomerRepository().GetLimitedCustomers(offset, limit);
            DisplayCustomers(customers);
            customer = new Customer("Anna", "Reszko", "zanzibar", "00-506", "23434244", "blabla@balbal.com");
            var isCustomerAdded = new CustomerRepository().AddNewCustomer(customer);
            DisplayCustomer(customer);
            customer = new Customer(1, "Anna", "Reszko", "zanzibar", "00-506", "23434244", "blabla@balbal.com");
            var isCustomerUpdated = new CustomerRepository().UpdateCustomer(customer);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Following customer was modified");
            Console.WriteLine("---------------------------------");
            DisplayCustomer(customer);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Pick Id of customer you want to display");
            Console.WriteLine("---------------------------------");
            string id = Console.ReadLine();
            customer = new CustomerRepository().GetCustomerById(Int32.Parse(id));
            DisplayCustomer(customer);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Count of Customers by country");
            Console.WriteLine("---------------------------------");
            var countries = new CustomerRepository().GetCountOfCustomersByCountry();
            DisplayCountries(countries);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Top spenders");
            Console.WriteLine("---------------------------------");
            var spenders = new CustomerRepository().GetTopSpenders();
            DisplayTopSpenders(spenders);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Most populer genre for  selected customer");
            Console.WriteLine("---------------------------------");
            customer = new Customer(10);
            var favouriteGenre = new CustomerRepository().GetMostPopularGenreForChosenCustomer(customer);
            DisplayMostPopularGenre(favouriteGenre);
        }
        /// <summary>
        /// A method to display results of database search methods
        /// </summary>
        /// <param name="customer">A customer to display</param>
        static void DisplayCustomer(Customer customer)
        {
                Console.WriteLine(customer.ToString());
        }
        /// <summary>
        /// A method to display results of database search methods
        /// </summary>
        /// <param name="customers">A list customers to display</param>
        static void DisplayCustomers(List<Customer> customers)
        {
            foreach (var item in customers)
            {
                Console.WriteLine(item.ToString());
            }
        }
        /// <summary>
        /// A method to display results of database search methods
        /// </summary>
        /// <param name="countries">A list countries to display</param>
        static void DisplayCountries(List<CustomerCountry> countries)
        {
            foreach (var item in countries)
            {
                Console.WriteLine(item.ToString());
            }
        }
        /// <summary>
        /// A method to display results of database search methods
        /// </summary>
        /// <param name="spenders">A list most spenders</param>
        static void DisplayTopSpenders(List<CustomerSpender> spenders)
        {
            foreach (var item in spenders)
            {
                Console.WriteLine(item.ToString());
            }
        }
        /// <summary>
        /// A method to display results of database search methods
        /// </summary>
        /// <param name="customerGenre">A list of  favourite genre</param>
        static void DisplayMostPopularGenre(List<CustomerGenre> customerGenre)
        {
            foreach (var item in customerGenre)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}

