using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMTIOnlineCourseRegistration.DAL;

namespace SMTI_Online_Course_Registration.BLL
{
    public class Course
    {
        public string CourseNumber { get; set; }
        public string CourseTitle { get; set; }
        public int TotalHour { get; set; }

        // Method to get all courses
        public List<Course> GetAllCourses() => CourseDB.GetAllRecords();

    }
}