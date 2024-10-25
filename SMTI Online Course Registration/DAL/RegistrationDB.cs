using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using SMTI_Online_Course_Registration.BLL;
using SMTI_Online_Course_Registration.DAL;

namespace SMTIOnlineCourseRegistration.DAL
{
    public static class RegistrationDB
    {
        // Method to register a student for a course
        public static void RegisterCourse(Registration registration)
        {
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                string sql = "INSERT INTO Registrations (StudentNumber, CourseNumber) VALUES (@StudentNumber, @CourseNumber)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@StudentNumber", registration.StudentNumber);
                cmd.Parameters.AddWithValue("@CourseNumber", registration.CourseNumber);

                
                cmd.ExecuteNonQuery();
            }
        }

        // Method to get courses registered by a student
        public static List<Course> GetCoursesByStudentNumber(int studentNumber)
        {
            List<Course> courses = new List<Course>();
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                string sql = "SELECT c.* FROM Courses c JOIN Registrations r ON c.CourseNumber = r.CourseNumber WHERE r.StudentNumber = @StudentNumber";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);

                
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

        // Method to count courses registered by a student
        public static int CountCoursesRegistered(int studentNumber)
        {
            int count = 0;
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                string sql = "SELECT COUNT(*) FROM Registrations WHERE StudentNumber = @StudentNumber";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);

                
                count = (int)cmd.ExecuteScalar();
            }
            return count;
        }
    }
}
