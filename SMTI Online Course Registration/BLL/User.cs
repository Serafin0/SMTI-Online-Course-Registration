using SMTI_Online_Course_Registration.DAL;
using SMTIOnlineCourseRegistration.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMTI_Online_Course_Registration.BLL
{
    public class User
    {
        public string UserCode { get; set; }  // Property for UserCode
        public string Password { get; set; }   // Property for Password

        // Method to validate user credentials
        public static bool ValidateUser(string userCode, string password)
        {
            return UserDB.ValidateUser(userCode, password);
        }

        // Method to get all User
        public List<User> GetAllUsers() => UserDB.GetAllRecords();
    }
}