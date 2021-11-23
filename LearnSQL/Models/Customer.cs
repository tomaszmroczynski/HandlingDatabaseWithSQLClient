﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSQL.Models
{
    /// <summary>
    /// A class that contains customer instance data with variable constructors 
    /// </summary>
    public class Customer
    {
        public Customer(int id)
        {
            Id = id;
        }
        public Customer()
        {

        }
        public Customer(int id, string firstName, string lastName, string country, string postalCode, string phoneNumber, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            PostalCode = postalCode;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public Customer( string firstName, string lastName, string country, string postalCode, string phoneNumber, string email)
        {        
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            PostalCode = postalCode;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Id} | {FirstName} {LastName} | {Country} | {PostalCode} | {PhoneNumber} | {Email}";
        }

    }
}
