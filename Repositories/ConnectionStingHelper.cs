using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace LearningSQLClient.Repositories
{
    public class ConnectionStingHelper
    {
        public static string GetConnectionString()
        {

            //return "Server=DESKTOP-DPPS64K;Database=SuperheroesDB;Integrated Security=true;"

            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "DESKTOP-DPPS64K";
            connectionStringBuilder.InitialCatalog = "SuperheroesDB";
            connectionStringBuilder.IntegratedSecurity = true;
            return connectionStringBuilder.ConnectionString;


        }


    }
}
