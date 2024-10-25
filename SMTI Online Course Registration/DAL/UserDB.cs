using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using SMTI_Online_Course_Registration.DAL;
using SMTI_Online_Course_Registration.BLL;

namespace SMTIOnlineCourseRegistration.DAL
{
    public static class UserDB
    {
        // Method to get a user by UserCode
        public static User GetUserByCode(string userCode)
        {
            User user = null;
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                string sql = "SELECT * FROM Users WHERE UserCode = @UserCode";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UserCode", userCode);

                //conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new User
                    {
                        UserCode = reader["UserCode"].ToString(),
                        Password = reader["Password"].ToString()
                    };
                }
                else 
                {
                    user = null;
                }
                conn.Close();
                conn.Dispose();
            }

            return user;
        }

        // Method to get all Users
        public static List<User> GetAllRecords()
        {
            List<User> listU = new List<User>();
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {

                SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Users", conn);
                SqlDataReader reader = cmdSelectAll.ExecuteReader();
                User user;
                while (reader.Read())
                {
                    user = new User();
                    user.UserCode = reader["UserCode"].ToString();
                    user.Password = reader["Password"].ToString();
                    listU.Add(user);
                }
            }
            return listU;


        }

        // Method to validate user credentials
        public static bool ValidateUser(string userCode, string password)
        {
            User user = GetUserByCode(userCode);
            return user != null && user.Password == password;
        }
    }
}
