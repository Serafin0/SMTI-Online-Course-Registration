using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMTI_Online_Course_Registration.DAL
{
    public class UtilityDB
    {
        // Method to return an active database connection
        public static SqlConnection GetDBConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;
            conn.Open();
            return conn;
        }
    }
}