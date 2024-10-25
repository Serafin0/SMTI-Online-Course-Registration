using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMTI_Online_Course_Registration.DAL;

namespace SMTI_Online_Course_Registration.BLL
{
    public class Student
    {
        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        // Method to get student by student number
        public Student GetStudentByNumber(int studentNumber) => StudentDB.GetRecordByNumber(studentNumber);

        // Method to get all students
        public List<Student> GetAllStudents() => StudentDB.GetAllRecords();
    }
}