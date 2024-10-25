using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMTIOnlineCourseRegistration.DAL;

namespace SMTI_Online_Course_Registration.BLL
{
    public class Registration
    {
        public int RegistrationId { get; set; }
        public int StudentNumber { get; set; }
        public string CourseNumber { get; set; }

        // Method to register a student for a course
        public void RegisterCourse(Registration registration) => RegistrationDB.RegisterCourse(registration);

        // Method to get courses registered by a student
        public List<Course> GetCoursesByStudentNumber(int studentNumber) => RegistrationDB.GetCoursesByStudentNumber(studentNumber);

        // Method to count courses registered by a student
        public int CountCoursesRegistered(int studentNumber) => RegistrationDB.CountCoursesRegistered(studentNumber);

    }
}