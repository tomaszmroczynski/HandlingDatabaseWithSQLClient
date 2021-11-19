
using LearnSQL.Models;
using LearnSQL.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace LearnSQL
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //var customers = new CustomerRepository().GetAllCustomers();
            //DisplayCustomers(customers);
            //Console.WriteLine("---------------------------------");
            //Console.WriteLine("Chose id of customer to display");
            //Console.WriteLine("---------------------------------");
            //string choice = Console.ReadLine();
            //var customer = new CustomerRepository().GetCustomerById(Int32.Parse(choice));
            //DisplayCustomer(customer);
            //Console.WriteLine("---------------------------------");
            //Console.WriteLine("Chose first name of customer to display");
            //Console.WriteLine("---------------------------------");
            //choice = Console.ReadLine();
            //customer = new CustomerRepository().GetCustomerByName(choice);
            //DisplayCustomer(customer);
            //Console.WriteLine("---------------------------------");
            //Console.WriteLine("Chose from which CustomerId to start display");
            //Console.WriteLine("---------------------------------");
            //string offset = Console.ReadLine();
            //Console.WriteLine("---------------------------------");
            //Console.WriteLine("Chose how many Customers to  display");
            //Console.WriteLine("---------------------------------");
            //string limit = Console.ReadLine();
            //customers = new CustomerRepository().GetLimitedCustomers(offset, limit);
            //DisplayCustomers(customers);
            //customer = new Customer("Anna", "Reszko", "zanzibar", "00-506", "23434244", "blabla@balbal.com");
            //var isCustomerAdded = new CustomerRepository().AddNewCustomer(customer);
            //DisplayCustomer(customer);
            //Console.WriteLine("---------------------------------");
            //Console.WriteLine("Which value would you like to modify");
            //Console.WriteLine("---------------------------------");
            //Console.WriteLine("1 - FirstName | 2 - LastName | 3 - Country | 4 - PostalCode | 5 - Phone | 6 - Email");
            //Console.WriteLine("---------------------------------");
            //choice = Console.ReadLine();
            //Console.WriteLine("---------------------------------");
            //Console.WriteLine("Chose Customer to be modified by Id");
            //Console.WriteLine("---------------------------------");
            //string id = Console.ReadLine();
            //Console.WriteLine("---------------------------------");
            //Console.WriteLine("Type new value");
            //Console.WriteLine("---------------------------------");
            //string updatedString = Console.ReadLine();
            //var isCustomerUpdated = new CustomerRepository().UpdateCustomer(choice, id, updatedString);
            //customer = new CustomerRepository().GetCustomerById(Int32.Parse(id));
            //Console.WriteLine("---------------------------------");
            //Console.WriteLine("Following customer was modified");
            //Console.WriteLine("---------------------------------");
            //DisplayCustomer(customer);
            var countries = new CustomerRepository().GetCountOfCustomersByCountry();
            DisplayCountries(countries);
            var spenders = new CustomerRepository().GetTopSpenders();
            DisplayTopSpenders(spenders);
        }

        static void DisplayCustomer(Customer customer)
        {

                Console.WriteLine(customer.ToString());
  
        }

        static void DisplayCustomers(List<Customer> customers)
        {
            foreach (var item in customers)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static void DisplayCountries(List<CustomerCountry> countries)
        {
            foreach (var item in countries)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static void DisplayTopSpenders(List<CustomerSpender> spenders)
        {
            foreach (var item in spenders)
            {
                Console.WriteLine(item.ToString());
            }
        }


    }


}

