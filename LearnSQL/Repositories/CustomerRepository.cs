using LearnSQL.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSQL.Repositories
{
    public class CustomerRepository
    {
        private static readonly string _connectionString = @"Server=.\TOMAS;Database=Chinook;User Id=pletwal;Password=qwerty;Trusted_Connection=false;";

        public Customer GetCustomerById(int id)
        {
            var customer = new Customer();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string sql = $"select * from Customer where CustomerId={id}";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        customer = new Customer(int.Parse(r[0].ToString()), r[1].ToString(), r[2].ToString(), r[7].ToString(), r[8].ToString(), r[9].ToString(), r[11].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
                return customer;
            };
        }

        public Customer GetCustomerByName(string name)
        {
            var customer = new Customer();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string sql = $"select * from Customer where FirstName like '{name}%'";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        customer = new Customer(int.Parse(r[0].ToString()), r[1].ToString(), r[2].ToString(), r[7].ToString(), r[8].ToString(), r[9].ToString(), r[11].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
                return customer;
            };
        }

        public List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string sql = "select * from Customer";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        customers.Add(new Customer(int.Parse(r[0].ToString()), r[1].ToString(), r[2].ToString(), r[7].ToString(), r[8].ToString(), r[9].ToString(), r[11].ToString()));
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
                return customers;
            }
        }
        public List<Customer> GetLimitedCustomers(string offset, string limit)
        {
            var customers = new List<Customer>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string sql = $"select * from Customer order by CustomerId OFFSET {offset} rows fetch next {limit} rows only;";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        customers.Add(new Customer(int.Parse(r[0].ToString()), r[1].ToString(), r[2].ToString(), r[7].ToString(), r[8].ToString(), r[9].ToString(), r[11].ToString()));
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
                return customers;
            }
        }
        public bool AddNewCustomer(Customer customer){
                
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    try
                    {
                        string sql = $"INSERT INTO Customer (  FirstName, LastName, Country, PostalCode, Phone, Email) VALUES('{customer.FirstName}','{customer.LastName}','{customer.Country}','{customer.PostalCode}','{customer.PhoneNumber}', '{customer.Email}')";
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        var r = cmd.ExecuteReader();
                    //while (r.Read())
                    //{
                    //    customer = new Customer( r[1].ToString(), r[2].ToString(), r[7].ToString(), r[8].ToString(), r[9].ToString(), r[11].ToString());
                    //}
                    return true;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.ToString());
                    return false;
                    }
                    finally
                    {

                        connection.Close();
                        
                    }
                    
                };
            }


        public bool UpdateCustomer(string choice, string id, string updatedString )
        {
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                //FirstName, LastName, Country, PostalCode, Phone, Email
                try
                {
                    var customer = new Customer();
                    string sql = null;
                     switch (choice)
                    {
                        case "1":
                             sql = $"update Customer  SET FirstName = '{updatedString}'  WHERE CustomerId = {id}";
                            break;

                        case "2":
                             sql = $"update Customer  SET LastName = '{updatedString}'  WHERE CustomerId = {id}";
                            break;
                        case "3": 
                            sql = $"update Customer  SET Country = '{updatedString}'  WHERE CustomerId = {id}";
                            break;
                        case "4": 
                            sql = $"update Customer  SET PostalCode = '{updatedString}'  WHERE CustomerId = {id}";
                            break;
                        case "5": 
                            sql = $"update Customer  SET Phone = '{updatedString}'  WHERE CustomerId = {id}";
                            break;
                        case "6": 
                            sql = $"update Customer  SET Email = '{updatedString}'  WHERE CustomerId = {id}";
                            break;
                        default:
                           
                            break;
                    }
                    
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        customer = new Customer(int.Parse(r[0].ToString()), r[1].ToString(), r[2].ToString(), r[7].ToString(), r[8].ToString(), r[9].ToString(), r[11].ToString());
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.ToString());
                    return false;
                }
                finally
                {
                    connection.Close();
                }
                
            };
        }

        public List<CustomerCountry> GetCountOfCustomersByCountry()
        {
            List<CustomerCountry> customerCountry = new List<CustomerCountry>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                try
                {
                    string sql = $"SELECT Country, COUNT(*) from Customer GROUP BY Country ORDER BY COUNT(Country) Desc";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    var r = cmd.ExecuteReader();

                    while (r.Read())
                    {
                        customerCountry.Add(new CustomerCountry(r[0].ToString(), int.Parse(r[1].ToString()) ));
                       
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.ToString());
                    
                }
                finally
                {

                    connection.Close();

                }
                return customerCountry;

            };



        }
        
            public List<CustomerSpender> GetTopSpenders()
        {
            List<CustomerSpender> customerCountry = new List<CustomerSpender>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                //string sql = $"SELECT Customer.CustomerId, Customer.FirstName, Customer.LastName, SUM(Invoice.Total) from Customer LEFT JOIN Invoice ON Customer.CustomerID = Invoice.CustomerID GROUP BY Customer.CustomerId, Customer.FirstName, Customer.LastName ORDER BY SUM(Invoice.Total) Desc";

                try
                {
                    string sql = $"SELECT Customer.CustomerId, Customer.FirstName, Customer.LastName, SUM(Invoice.Total) from Customer LEFT JOIN Invoice ON Customer.CustomerID = Invoice.CustomerID GROUP BY Customer.CustomerId, Customer.FirstName, Customer.LastName ORDER BY SUM(Invoice.Total) Desc";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    var r = cmd.ExecuteReader();

                    while (r.Read())
                    {
                        customerCountry.Add(new CustomerSpender(int.Parse(r[0].ToString()), r[1].ToString(), r[2].ToString(), double.Parse(r[3].ToString())));

                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.ToString());

                }
                finally
                {

                    connection.Close();

                }
                return customerCountry;

            };



        }
    }
    }

