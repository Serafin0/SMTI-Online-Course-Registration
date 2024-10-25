using System;
using System.Collections.Generic;
using System.Web.UI;
using SMTI_Online_Course_Registration.BLL;
using SMTI_Online_Course_Registration.DAL;
using SMTIOnlineCourseRegistration.DAL;

namespace SMTI_Online_Course_Registration.GUI
{
    public partial class ListStudentsAndCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Fetch all students and bind them to the GridView
                List<Student> students = StudentDB.GetAllRecords(); // Fetch students
                gvStudents.DataSource = students;
                gvStudents.DataBind();

                // Fetch all courses and bind them to the GridView
                List<Course> courses = CourseDB.GetAllRecords(); // Fetch courses
                gvCourses.DataSource = courses;
                gvCourses.DataBind();

                // Fetch all users and bind them to the GridView
                List<User> users = UserDB.GetAllRecords(); // Fetch users 
                gvUsers.DataSource = users;
                gvUsers.DataBind();
            }
        }
    }
}
