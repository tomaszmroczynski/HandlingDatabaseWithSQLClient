using LearningSQLClient.Models;
using LearningSQLClient.Repositories;
using System;
using System.Collections.Generic;

namespace LearningSQLClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
        }

        static void TestSelectAll(ICustomerRepository repository)
        {

        }
        static void TestSelect(ICustomerRepository repository)
        {

        }

        static void PrintCustomers(IEnumerable<Superheroes> customers)
        {
            foreach (var customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        static void PrintCustomer(Superheroes customer)
        {
            Console.WriteLine($"---{ customer.CustomerID} {customer.ContactName} {customer.CompanyName} {}")
        }

    }
}
