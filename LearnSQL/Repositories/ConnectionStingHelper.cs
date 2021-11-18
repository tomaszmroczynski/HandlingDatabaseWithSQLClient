using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LearnSQL.Repositories
{
    public class ConnectionStingHelper
    {
        public static string GetConnectionString()
        {

            return @"Server=.\;Database=Chinook;Integrated Security=true;";

            //SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            //connectionStringBuilder.DataSource = ".\\";
            //connectionStringBuilder.InitialCatalog = "Chinook";
            //connectionStringBuilder.IntegratedSecurity = true;
            //var test = connectionStringBuilder.ConnectionString;
            //return test;


        }


    }
}
