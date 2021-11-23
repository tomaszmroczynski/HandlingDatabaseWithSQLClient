using LearnSQL.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSQL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private static readonly string _connectionString = @"Server=.\TOMAS;Database=Chinook;User Id=pletwal;Password=qwerty;Trusted_Connection=false;";

        /// <summary>
        /// A method that returns customer with selected id
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>Customer with selected Id</returns>
        public Customer GetCustomerById(int id)
        {
            var customer = new Customer();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string sql = $"select * from Customer where CustomerId={id}";
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer = new Customer(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[11].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.ToString());
                }
                return customer;
            };
        }

        /// <summary>
        /// A method that search customer in database by first name
        /// </summary>
        /// <param name="name">Customer first anme</param>
        /// <returns>Customer by name</returns>
        public Customer GetCustomerByName(string name)
        {
            var customer = new Customer();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string sql = $"select * from Customer where FirstName like @name";
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.ExecuteNonQuery();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer = new Customer(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[11].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.ToString());
                }
                return customer;
            };
        }
        /// <summary>
        /// A mathod that search database by all existing customers
        /// </summary>
        /// <returns>List of all customers</returns>
        public List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string sql = "select * from Customer";
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customers.Add(new Customer(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[11].ToString()));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return customers;
            }
        }
        /// <summary>
        /// A method that search  customers in database limited to begin row and  number of rows to be shown
        /// </summary>
        /// <param name="offset">Begining row for search</param>
        /// <param name="limit">Rows to be displayed</param>
        /// <returns>Limited list of customers</returns>
        public List<Customer> GetLimitedCustomers(string offset, string limit) 
        {
            var customers = new List<Customer>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string sql = $"select * from Customer order by CustomerId OFFSET @offset rows fetch next @limit rows only;";
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                            cmd.Parameters.AddWithValue("@offset", int.Parse(offset));
                            cmd.Parameters.AddWithValue("@limit", int.Parse(limit));
                            cmd.ExecuteNonQuery();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customers.Add(new Customer(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[11].ToString()));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.ToString());
                }
                return customers;
            }
        }

        /// <summary>
        /// A method that adds new customer
        /// </summary>
        /// <param name="customer">An instance of customer</param>
        /// <returns>succes of failure of addition</returns>
        public bool AddNewCustomer(Customer customer)
        {               
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    try
                    {
                        string sql = $"INSERT INTO Customer (  FirstName, LastName, Country, PostalCode, Phone, Email) VALUES('{customer.FirstName}','{customer.LastName}','{customer.Country}','{customer.PostalCode}','{customer.PhoneNumber}', '{customer.Email}')";
                        connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connection)) 
                    {
                        cmd.Parameters.AddWithValue("@Firstname", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    return false;
                    }                 
                };
            }

        /// <summary>
        /// A method that updates existing customer
        /// </summary>
        /// <param name="customer">An instance of customer with parameters to be udated</param>
        /// <returns>Success or failure of updating process</returns>
        public bool UpdateCustomer(Customer customer) 
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string sql = $"update Customer  SET  FirstName = @FirstName, LastName = @LastName, Country = @Country, PostalCode = @PostalCode, Phone = @PhoneNumber, Email = @Email    WHERE CustomerId = @Id";                  
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@Firstname", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        cmd.Parameters.AddWithValue("@Id", customer.Id);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }           
            };
        }
        /// <summary>
        /// A method that search database for Countires with most customers in descending order
        /// </summary>
        /// <returns>List of customers by contry</returns>
        public List<CustomerCountry> GetCountOfCustomersByCountry()
        {
            List<CustomerCountry> customerCountry = new List<CustomerCountry>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string sql = $"SELECT Country, COUNT(*) from Customer GROUP BY Country ORDER BY COUNT(Country) Desc";
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        { 
                            while (reader.Read())
                            {
                                customerCountry.Add(new CustomerCountry(reader[0].ToString(), int.Parse(reader[1].ToString())));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());    
                }
                return customerCountry;
            };
        }
            /// <summary>
            /// A method that search databse for most spending customers
            /// </summary>
            /// <returns>List of customers by spending</returns>
            public List<CustomerSpender> GetTopSpenders()
            {
                List<CustomerSpender> customerCountry = new List<CustomerSpender>();
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                try
                {
                    string sql = $"SELECT Customer.CustomerId, Customer.FirstName, Customer.LastName, SUM(Invoice.Total) from Customer LEFT JOIN Invoice ON Customer.CustomerID = Invoice.CustomerID GROUP BY Customer.CustomerId, Customer.FirstName, Customer.LastName ORDER BY SUM(Invoice.Total) Desc";
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                customerCountry.Add(new CustomerSpender(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), double.Parse(reader[3].ToString())));
                            }
                        }
                    }
                }
                catch (Exception ex)
                    {
                    Console.WriteLine(ex.ToString());
                    }
                return customerCountry;
                };
            }
        /// <summary>
        /// A method that search database for customers favourite genre
        /// </summary>
        /// <param name="customer">An instance of customer</param>
        /// <returns>Selected customer's favourite genre</returns>
        public List<CustomerGenre> GetMostPopularGenreForChosenCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                List<CustomerGenre> customerGenre = new List<CustomerGenre>();
                try
                {
                    string sql = $"select TOP(1) WITH TIES GId, GName, count(GId) as Counter from(select t.GenreId as GId, g.Name as GName from Track t inner join Genre g on t.GenreId = g.GenreId where t.TrackId in (select TrackId from InvoiceLine where InvoiceId in (select InvoiceId  from Invoice where CustomerId = @Id))) as v group by GId, GName order by Counter desc";
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", customer.Id);
                        cmd.ExecuteNonQuery();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customerGenre.Add(new CustomerGenre(int.Parse(reader[0].ToString()), reader[1].ToString(), int.Parse(reader[2].ToString())));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return customerGenre;
            }
        }
    }
}

