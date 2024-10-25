using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using SMTI_Online_Course_Registration.BLL;

namespace SMTI_Online_Course_Registration.DAL
{
    public class StudentDB
    {
        // Method to get student by student number
        public static Student GetRecordByNumber(int studentNumber)
        {
            Student student = null;
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                string sql = "SELECT * FROM Students WHERE StudentNumber = @StudentNumber";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    student = new Student
                    {
                        StudentNumber = (int)reader["StudentNumber"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                }
            }
            return student;
        }

        // Method to get all students
        public static List<Student> GetAllRecords()
        {
            List<Student> listS = new List<Student>();
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                
                SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Students", conn);
                SqlDataReader reader = cmdSelectAll.ExecuteReader();
                Student student;
                while (reader.Read())
                {
                    student = new Student();
                    student.StudentNumber = Convert.ToInt32(reader["StudentNumber"]); // Fix this line
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.Email = reader["Email"].ToString();
                    listS.Add(student);
                }
            }
            return listS;


        }
    }
}