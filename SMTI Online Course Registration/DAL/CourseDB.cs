using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using SMTI_Online_Course_Registration.DAL;
using SMTI_Online_Course_Registration.BLL;

namespace SMTIOnlineCourseRegistration.DAL
{
    public static class CourseDB
    {
        // Method to get all courses
        public static List<Course> GetAllRecords()
        {
            List<Course> courses = new List<Course>();
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                string sql = "SELECT * FROM Courses";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    courses.Add(new Course
                    {
                        CourseNumber = reader["CourseNumber"].ToString(),
                        CourseTitle = reader["CourseTitle"].ToString(),
                        TotalHour = (int)reader["TotalHour"]
                    });
                }
            }
            return courses;
        }


    }
}


